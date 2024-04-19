using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public class IviPort
    {
        public static List<string> Resources { get { return GetAllResources(); } }
        //public static List<ConnectedIviResource> ConnectedIviResources;
        //public IMessage DeviceIO { get; set; }
        public IMessage deviceIO;
        public IVisaSession ivs;
        public PortType PortType;
        private static ResourceManager rm;
        public static string defaultAdress;
        private string resourceName;
        private static List<string> resources;
        public static string exceptionMessage;

        public IviPort(string resourceName)
        {
            this.resourceName = resourceName;
            SetPortType();
            //Open();
        }
        private void SetPortType()
        {
            if (resourceName.StartsWith("USB"))
            {
                PortType = PortType.IviUsb;
            }
            if (resourceName.StartsWith("GPIB"))
            {
                PortType = PortType.IviGPIB;
            }
            if (resourceName.StartsWith("TCPIP"))
            {
                PortType = PortType.IviTCPIP;
            }
        }
        public Result Open()
        {
            //resourceName = portName + "::INSTR";
            if (rm == null)
            {
                try
                {
                    rm = new ResourceManager();
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                    return Result.Exception;
                }
            }
            if (rm != null)
            {
                try
                {
                    ivs = rm.Open(resourceName, AccessMode.NO_LOCK, 0, ""); //TODO: проверить работу на разных типах ресурсов 
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                    Marshal.FinalReleaseComObject(rm);
                    return Result.Exception;
                }
            }
            if (ivs != null)
            {
                try
                {
                    deviceIO = new FormattedIO488().IO;
                    deviceIO = (IMessage)ivs;
                    return Result.Success;
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка: {e.Message}";
                    Close();
                    return Result.Exception;
                }
            }
            return Result.Failure;
        }
        public void Close()
        {
            if (deviceIO != null)
            {
                deviceIO.Close();
            }
            if (ivs != null)
            {
                ivs.Close();
                Marshal.FinalReleaseComObject(deviceIO);
                Marshal.FinalReleaseComObject(ivs);
                deviceIO = null;
                ivs = null;

            }
            /*
            if (rm != null)
            {
                //Marshal.FinalReleaseComObject(rm);
            }
            */
        }
        public Result Send(string command)
        {
            if (deviceIO != null)// todo не бывает null, нужна другая проверка иначе метод выполняется 8 секунд
            {
                try
                {
                    deviceIO.WriteString(command);
                    return Result.Success;
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка: {e.Message}";
                    return Result.Exception;
                }
            }
            return Result.Failure;
        }
        public Result ReadString(out string stringReaded)
        {
            return ReadString(deviceIO, out stringReaded);
        }
        private Result ReadString(IMessage deviceIO, out string stringReaded)
        {
            Result result;
            stringReaded = string.Empty;
            string ch = string.Empty;
            do
            {
                result = ReadChar(deviceIO, out ch, attemptCount: 5);
                if (result != Result.Success)
                {
                    return result;
                }
                if (ch == "\n" || ch == "\r")
                {
                    continue;
                }
                stringReaded += ch;
            }
            while (ch != string.Empty && ch != "\n"); //Проверить необходимость первого условия 
            return Result.Success;
        }
        private Result ReadChar(IMessage deviceIO, out string charReaded, int attemptCount)
        {
            charReaded = string.Empty;
            if (deviceIO == null)
            {
                return Result.ParamError;
            }
            if (deviceIO != null)
            {
                try
                {
                    charReaded = deviceIO.ReadString(1);
                }
                catch (Exception e)
                {
                    if (attemptCount > 0)
                    {
                        return ReadChar(deviceIO, out charReaded, attemptCount - 1);
                    }
                    exceptionMessage = $"Ошибка: {e.Message}";
                    return Result.Exception;
                }
            }
            return Result.Success;
        }
        public static List<string> GetAllResources()
        {
            string[] allResources;
            if (resources == null)
            {
                resources = new List<string>();
            }
            resources.Clear();
            if (rm == null)
            {
                try
                {
                    rm = new ResourceManager();
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                    return resources;
                }
            }
            try
            {
                try
                {
                    allResources = rm.FindRsrc("?*");
                    if (allResources != null)
                    {
                        foreach (string resource in allResources)
                        {
                            if (resource.EndsWith("INSTR"))
                            {
                                resources.Add(resource.Substring(0, resource.Length));
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка: {e.Message}";
                }
            }
            catch (Exception e)
            {
                exceptionMessage = $"Ошибка: {e.Message}";
            }
            return resources;
        }
        public static bool IsResourceNameExist(string resourceName)
        {
            foreach (string resource in Resources)
            {
                if (resourceName == resource)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class ConnectedIviResource
    {
        public int CountConnections;
        public string ResourceName;
        public ConnectedIviResource(string resourceName)
        {
            CountConnections = 0;
            ResourceName = resourceName;
        }

    }
    public static class ConnectedIviDevices
    {
        public static List<ConnectedIviPort> connectedIviPorts;
        public static Result Connect(string resourceName, out ConnectedIviPort connectedIviPort)
        {
            if (connectedIviPorts == null)
            {
                connectedIviPorts = new List<ConnectedIviPort>();
            }
            if (IviPort.IsResourceNameExist(resourceName))
            {
                int index = GetItemIndex(resourceName);
                if (index < 0)
                {
                    connectedIviPort = new ConnectedIviPort(resourceName);
                    Result result = connectedIviPort.Open();
                    if (result == Result.Success)
                    {
                        connectedIviPorts.Add(connectedIviPort);
                        return result;
                    }
                    connectedIviPort.Close();
                    return result;
                }
                connectedIviPorts[index].CountConnections++;
                connectedIviPort = connectedIviPorts[index];
                return Result.Success;
            }
            connectedIviPort = null;
            return Result.ParamError;
        }
        public static Result Disconnect(string resourceName)
        {
            int index = GetItemIndex(resourceName);
            if (index < 0)
            {
                return Result.ParamError;
            }
            connectedIviPorts[index].CountConnections--;
            if (connectedIviPorts[index].CountConnections == 0)
            {
                return connectedIviPorts[index].Close();
            }
            return Result.Success;
        }
        public static int GetItemIndex(string resourceName)
        {
            int index = -1;
            if (connectedIviPorts == null || connectedIviPorts.Count == 0)
            {
                return index;
            }
            for (int i = 0; i < connectedIviPorts.Count; i++)
            {
                if (connectedIviPorts[i].ResourceName == resourceName)
                {
                    return i;
                }
            }
            return index;
        }
    }
    public class ConnectedIviPort
    {
        public int CountConnections;
        public string ResourceName;
        public string DeviceInfo;
        public string SerialNumber;
        public PortType PortType;
        public IviPort Port;
        public ConnectedIviPort(string resourceName)
        {
            CountConnections = 0;
            DeviceInfo = string.Empty;
            ResourceName = resourceName;
        }

        public Result Open()
        {
            Result result = Result.Failure;
            if (Port != null)
            {
                //TODO:
                return result;
            }
            if (Port == null)
            {
                Port = new IviPort(ResourceName);
                result = Port.Open();
            }
            if (result != Result.Success)
            {
                Port.Close();
                Port = null;
                return result;
            }
            CountConnections++;
            return result;
        }
        public Result Close()
        {
            CountConnections--;
            if (CountConnections == 0)
            {
                Port.Close();
                Port = null;
            }
            return Result.Success;
        }
        public Result Send(string command)
        {
            return Port.Send(command);
        }
        public Result ReadString(out string stringReaded)
        {
            return Port.ReadString(out stringReaded);
        }
        public int GetIndexFromConnected()
        {
            int index = -1;
            //TODO:
            return index;
        }
        public bool IsConnected()
        {
            if (CountConnections > 0)
            {
                return true;
            }
            return false;
        }
    }
    public class IviDevice : IDevice
    {
        public DeviceType DeviceType { get; set; }
        public string ResourceName { get; set; }
        public string SerialNumber;
        public string DeviceInfo;
        private ConnectedIviPort ConnectedPort;
        private bool isConnected;
        public IviDevice()
        {
            DeviceType = DeviceType.Unknown;
            isConnected = false;
        }
        public Result Connect()
        {
            Result result = ConnectedIviDevices.Connect(ResourceName, out ConnectedPort);
            if (SetDeviceInfo() != Result.Success)
            {
                Disconnect();
                return Result.Failure;
            }
            if (result == Result.Success)
            {
                isConnected = true;
            }
            return result;
        }
        public Result Disconnect()
        {

            Result result = ConnectedIviDevices.Disconnect(ResourceName);
            if (result == Result.Success)
            {
                isConnected = false;
            }
            return result;
        }
        public Result Receive(out string response)
        {
            Result result = Result.Failure;
            response = string.Empty;
            if (isConnected)
            {
                result = Connect();
                if (result != Result.Success)
                {
                    return result;
                }
            }
            result = ConnectedPort.ReadString(out response);
            return result;
        }

        public Result Send(string command)
        {
            Result result = Result.Failure;
            if (isConnected)
            { 
                result = Connect();
                if (result != Result.Success)
                {
                    return result;
                }
            }
            result = ConnectedPort.Send(command);
            return result;
        }

        private Result SetDeviceFields()
        {
            //TODO:
            return Result.Failure;
        }
        private static string GetSerialNumberFromDeviceInfo(string deviceInfo)
        {
            string sn = string.Empty;
            string substringMark = "s/n";
            int snStartPosition = deviceInfo.IndexOf(substringMark) + substringMark.Length;
            if (snStartPosition < 0)
            {
                return sn;
            }
            sn = deviceInfo.Substring(snStartPosition);
            return sn;
        }


    }
}
