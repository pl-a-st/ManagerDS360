﻿using Ivi.Visa.Interop;
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
        private ResourceManager rm;
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
        public static List<string> GetAllResources()
        {
            string[] allResources;
            if (resources == null)
            {
                resources = new List<string>();
            }
            resources.Clear();
            try
            {
                ResourceManager resourceManager = new ResourceManager();
                try
                {
                    allResources = resourceManager.FindRsrc("?*");
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
                    Marshal.FinalReleaseComObject(resourceManager);
                }
                finally
                {
                    Marshal.FinalReleaseComObject(resourceManager);
                }
            }
            catch (Exception e)
            {
                exceptionMessage = $"Ошибка: {e.Message}";
            }
            return resources;
        }
        /*
        public static List<string> _GetAllResources()
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
        */
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
        private void SetPortType()
        {
            if (resourceName.StartsWith("USB"))
            {
                PortType = PortType.IviUSB;
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

    }
    public static class ConnectedIviDevices
    {
        public static List<ConnectedIviDevice> connectedIviDevices;
        public static Result Connect(string resourceName, out ConnectedIviDevice connectedIviDevice) //TODO: возможно потребуется отличие new: isNewConnection
        {
            if (connectedIviDevices == null)
            {
                connectedIviDevices = new List<ConnectedIviDevice>();
            }
            if (IviPort.IsResourceNameExist(resourceName))
            {
                int index = GetItemIndex(resourceName);
                if (index < 0)
                {
                    connectedIviDevice = new ConnectedIviDevice(resourceName);
                    Result result = connectedIviDevice.Open();
                    if (result == Result.Success)
                    {
                        connectedIviDevices.Add(connectedIviDevice);
                        return result;
                    }
                    connectedIviDevice.Close();
                    return result;
                }
                connectedIviDevices[index].CountConnections++;
                connectedIviDevice = connectedIviDevices[index];
                return Result.Success;
            }
            connectedIviDevice = null;
            return Result.ParamError;
        }
        public static Result Disconnect(string resourceName)
        {
            int index = GetItemIndex(resourceName);
            if (index < 0)
            {
                return Result.ParamError;
            }
            if (connectedIviDevices[index].CountConnections == 1)
            {
                Result result = connectedIviDevices[index].Close();
                connectedIviDevices.RemoveAt(index);
                return result;
            }
            connectedIviDevices[index].CountConnections--;
            return Result.Success;
        }
        public static int GetItemIndex(string resourceName)
        {
            int index = -1;
            if (connectedIviDevices == null || connectedIviDevices.Count == 0)
            {
                return index;
            }
            for (int i = 0; i < connectedIviDevices.Count; i++)
            {
                if (connectedIviDevices[i].ResourceName == resourceName)
                {
                    return i;
                }
            }
            return index;
        }
    }
    public class ConnectedIviDevice
    {
        public int CountConnections;
        public string ResourceName { get { return resourceName; } }
        public string DeviceInfo { get { return deviceInfo; } }
        //public string SerialNumber { get { return serialNumber; } }
        //public PortType PortType;
        public IviPort Port;

        private string resourceName;
        private string deviceInfo;
        //private string serialNumber;
        public ConnectedIviDevice(string resourceName)
        {
            //CountConnections = 0;
            //DeviceInfo = string.Empty;
            this.resourceName = resourceName;
        }

        public Result Open()
        {
            Result result = Result.Failure;
            if (Port != null) //
            {
                //TODO:
                return result; //
            }
            if (Port == null)  //
            {
                Port = new IviPort(ResourceName);
                result = Port.Open();
                Task.Delay(100);
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
            CountConnections--; //проверить
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
        public void SetDeviceInfo(string deviceInfo)
        {
            this.deviceInfo = deviceInfo;
        }
        /* //NotUsed
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
        */
    }
    public class IviDevice : IDevice
    {
        public DeviceType DeviceType { get { return deviceType; } }
        public DeviceModel DeviceModel { get { return deviceModel; } }
        public PortType PortType { get { return portType; } set { SetPortType(); } }
        public string ResourceName { get; set; }
        public string SerialNumber { get { return serialNumber; } }
        public string DeviceInfo { get { return deviceInfo; } }
        private PortType portType;
        private DeviceType deviceType;
        private DeviceModel deviceModel;
        private string serialNumber;
        private string deviceInfo;
        private ConnectedIviDevice ConnectedIviDevice;
        private bool isConnected;
        public IviDevice() //TODO: оставить для дефлотных
        {
            deviceType = DeviceType.Unknown;
            deviceModel = DeviceModel.Unknown;
            isConnected = false;
        }
        public IviDevice(string resourceName)
        {
            ResourceName = resourceName;
            deviceType = DeviceType.Unknown;
            deviceModel = DeviceModel.Unknown;
            isConnected = false;
        }
        public IviDevice(string resourceName, DeviceModel deviceModel)
        {
            ResourceName = resourceName;
            deviceType = DeviceType.Unknown;
            this.deviceModel = deviceModel;
            isConnected = false;
        }
        public Result Connect()
        {
            Result result = ConnectedIviDevices.Connect(ResourceName, out ConnectedIviDevice); //Проверка корректности ResourceName проводится в этом методе
            if (result != Result.Success)
            {
                return result;
            }
            isConnected = true;
            if (SetDeviceFields() != Result.Success)
            {
                Disconnect();
                isConnected = false;
                return Result.Failure;
            }
            ConnectedIviDevice.SetDeviceInfo(deviceInfo);
            return result;
        }
        public Result Disconnect()
        {
            Result result = ConnectedIviDevices.Disconnect(ResourceName);
            if (result == Result.Success) //TODO
            {
                isConnected = false;
            }
            return result;
        }
        public Result Receive(out string response)
        {
            Result result = Result.Failure;
            response = string.Empty;
            if (!isConnected)
            {
                result = Connect();
                if (result != Result.Success)
                {
                    return result;
                }
            }
            result = ConnectedIviDevice.ReadString(out response);
            return result;
        }
        public Result Send(string command)
        {
            Result result = Result.Failure;
            if (!isConnected)
            {
                result = Connect();
                if (result != Result.Success)
                {
                    return result;
                }
            }
            result = ConnectedIviDevice.Send(command);
            return result;
        }
        #region PrivateMethods
        private Result SetDeviceFields() //PortType, DeviceModel,
        {
            Result result = Result.Failure;
            string response = string.Empty;
            SetPortType();
            if (portType == PortType.IviUSB)
            {
                result = Send("*IDN?");
                if (result != Result.Success)
                {
                    return result;
                }
                result = Receive(out response);
                if (result != Result.Success)
                {
                    return result;
                }
                IdentifyDevice(response);
            }
            if (portType == PortType.IviGPIB)
            {
                result = Send("*IDN?"); //TODO проверить
                if (result != Result.Success)
                {
                    return result;
                }
                result = Receive(out response);
                if (result != Result.Success)
                {
                    result = Send("*ID?");
                    if (result != Result.Success)
                    {
                        return result;
                    }
                    result = Receive(out response);
                    if (result != Result.Success)
                    {
                        return result;
                    }
                }
                IdentifyDevice(response);
            }
            if (portType == PortType.IviTCPIP)
            {
                //TODO
            }
            if (DeviceModel == DeviceModel.Unknown)
            {
                return Result.Failure;
            }
            //TODO: GetSerialNumber, SetDeviceInfo
            return Result.Success;
        }
        private void SetPortType()
        {
            if (ResourceName.StartsWith("USB"))
            {
                portType = PortType.IviUSB;
            }
            if (ResourceName.StartsWith("GPIB"))
            {
                portType = PortType.IviGPIB;
            }
            if (ResourceName.StartsWith("TCPIP"))
            {
                portType = PortType.IviTCPIP;
            }
        }
        private static string[] ConvertResourceNameToArray(string resourceName)
        {
            string[] stringSeparator = { "::" };
            string[] str = resourceName.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);
            return str;
        }
        private Result IdentifyDevice(string response)
        {
            Result result = Result.ParamError; //TODO заменить на UnKnoun?
            //deviceModel = DeviceModel.Unknown;
            const string response33220A = "Agilent Technologies,33220A";
            const string response33210A = "Agilent Technologies,33210A";
            const string response3458A = "HP3458A";
            const string responseDS360 = "StanfordResearchSystems,DS360,";
            if (response.StartsWith(response33220A))
            {
                deviceModel = DeviceModel.Agilent33220A;
                deviceType = DeviceType.Generator;
                result = Result.Success;
            }
            if (response.StartsWith(response33210A))
            {
                deviceModel = DeviceModel.Agilent33210A;
                deviceType = DeviceType.Generator;
                result = Result.Success;
            }
            if (response.StartsWith(response3458A))
            {
                deviceModel = DeviceModel.Agilent3458A;
                deviceType = DeviceType.Multimeter;
                result = Result.Success;
            }
            if (response.StartsWith(responseDS360)) //TODO: проверить
            {
                deviceModel = DeviceModel.DS360;
                deviceType = DeviceType.Generator;
                result = Result.Success;
            }
            SetSerialNumber(response);
            SetDeviceInfo();
            return result;
        }
        private void SetSerialNumber(string response)
        {
            if (portType == PortType.IviUSB)
            {
                string[] subString = ConvertResourceNameToArray(ResourceName);
                if (subString != null && subString.Length > 3)
                {
                    serialNumber = subString[3];
                    return;
                }
            }
            if (deviceModel == DeviceModel.Agilent3458A || deviceModel == DeviceModel.Unknown)
            {
                serialNumber = string.Empty;
                return;
            }
            if (deviceModel == DeviceModel.DS360)
            {
                string[] subString = response.Split(',');
                serialNumber = subString[2];
                return;
            }
        }
        private void SetDeviceInfo()
        {
            string port = string.Empty;
            string model = string.Empty;
            if (portType == PortType.IviUSB)
            {
                port = ResourceName.Substring(startIndex: 0, length: 4);
            }
            if (portType == PortType.IviGPIB)
            {
                string[] substring = ConvertResourceNameToArray(ResourceName);
                port = $"{substring[0]}/{substring[1]}";
            }
            if (portType == PortType.IviTCPIP)
            {
                //TODO
            }
            model = DeviceModel.ToString();
            deviceInfo = $"{port}: {model}, sn{serialNumber}";
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
        #endregion PrivateMethods
    }
}
