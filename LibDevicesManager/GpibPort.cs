using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public class IviPort
    {
        public IMessage DeviceIO { get; set; }
        public IMessage deviceIO;
        public IVisaSession ivs;
        public static ResourceManager rm;
        private string resourceName;

        public IviPort (string resourceName)
        {
            this.resourceName = resourceName;
            Open();
        }
        private void Open()
        {
            if (rm == null)
            {
                rm = new ResourceManager();
            }
            ivs = rm.Open(resourceName, AccessMode.NO_LOCK, 0, "");
            deviceIO = new FormattedIO488().IO;
            deviceIO = (IMessage)ivs;
        }
    }
    public class GpibPort
    {
        public int GpibAddress { get; set; }

        /// <summary>
        /// Текст сообщения о результате выполнения методов, имеющих тип возвращаемого значения <see cref="Result"/>
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return exceptionMessage;
            }
        }
        public static List<string> Resources
        {
            get
            {
                return GetAllPorts();
            }
        }
        public static List<ConnectedResource> ConnectedResources;
        private int gpibAddress;

        public IMessage DeviceIO { get; set; }
        private IMessage deviceIO;
        private IVisaSession ivs;
        private ResourceManager rm;
        //private static string[] resourses;
        private static List<string> resourses;
        private string resourceName = string.Empty;
        private static string exceptionMessage = string.Empty;
        //private string resultMessage = string.Empty;
        //private string[] resourses;
        #region Constructors

        public GpibPort()
        {
            //FindAndInitFirstGpibPort();
        }
        public GpibPort(int gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            Init(gpibAddress);
        }
        public GpibPort(string portName)
        {
            Init(portName);
        }

        #endregion Constructors

        #region PublicMethods
        public static Result ConnectResource (string resourceName)
        {
            Result result = Result.Failure;
            //TODO: добавить проверку корректности resourceName?
            if (ConnectedResources == null)
            {
                ConnectedResources = new List<ConnectedResource>();
            }
            if (ConnectedResources.Count != 0)
            {
                //TODO: FindIndexInConnectedResources
                //int index = FindIndexInConnectedResources(resourceName);
                int index = -1;
                if (index >= 0)
                {
                    ConnectedResources[index].CountConnections++;
                    return Result.Success;
                }
            }
            ConnectedResource port = new ConnectedResource(resourceName);
            result = port.Open();
            return result;
        }
        public static Result DisconnectResource(string portName)
        {
            Result result = Result.Failure;
            if (ConnectedResources != null && ConnectedResources.Count != 0)
            {
                int index = -1;
                // TODO: int index = FindIndexInConnectedResources(portName);
                if (index >= 0)
                {
                    result = ConnectedResources[index].Close();
                    if (ConnectedResources[index].CountConnections == 0)
                    {
                        ConnectedResources.RemoveAt(index);
                    }
                    return result;
                }
            }
            return result;
        }
        public static List<string> GetAllPorts()
        {
            string[] allResources;
            if (resourses == null)
            {
                resourses = new List<string>();
            }
            resourses.Clear();
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
                                resourses.Add(resource.Substring(0, resource.Length - 7));
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
            return resourses;
        }
        public static List<string> GetGpibPorts()
        {
            List<string> allPorts = new List<string>();
            List<string> gpibPorts = new List<string>();
            allPorts = GetAllPorts();
            foreach (string port in allPorts)
            {
                if (port.StartsWith("GPIB"))
                {
                    gpibPorts.Add(port);
                }
            }
            return gpibPorts;
        }
        public static List<string> GetUSBPorts()
        {
            List<string> allPorts = new List<string>();
            List<string> usbPorts = new List<string>();
            allPorts = GetAllPorts();
            foreach (string port in allPorts)
            {
                if (port.StartsWith("USB"))
                {
                    usbPorts.Add(port);
                }
            }
            return usbPorts;
        }

        public Result ReadString(out string stringReaded)
        {
            return ReadString(deviceIO, out stringReaded);
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
            if (rm != null)
            {
                Marshal.FinalReleaseComObject(rm);
            }
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
        #endregion PublicMethods

        #region PrivateMethods
        private void FindAndInitFirstGpibPort()
        {
            List<string> gpibPorts = GetGpibPorts();
            if (gpibPorts != null && gpibPorts.Count > 0)
                resourceName = $"{gpibPorts[0]}::INSTR";
            if (rm == null)
            {
                try
                {
                    rm = new ResourceManager();
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                }
            }
            if (rm != null)
            {
                try
                {
                    ivs = rm.Open(resourceName, AccessMode.NO_LOCK, 0, "");
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                    Marshal.FinalReleaseComObject(rm);
                }
            }
            if (ivs != null)
            {
                try
                {
                    deviceIO = new FormattedIO488().IO;
                    deviceIO = (IMessage)ivs;
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка: {e.Message}";
                    Close();
                }
            }
        }
        public Result Init(string portName)
        {
            resourceName = portName + "::INSTR";
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
                    ivs = rm.Open(resourceName, AccessMode.NO_LOCK, 0, "");
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
        private void Init(int gpibAddress)
        {
            resourceName = $"GPIB0::{gpibAddress}::INSTR"; //ToDo: изменить строку на полученную от FindRsrc("?*")
            if (rm == null)
            {
                try
                {
                    rm = new ResourceManager();
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                }
            }
            if (rm != null)
            {
                try
                {
                    ivs = rm.Open(resourceName, AccessMode.NO_LOCK, 0, "");
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка открытия порта: {e.Message}";
                    Marshal.FinalReleaseComObject(rm);
                }
            }
            if (ivs != null)
            {
                try
                {
                    deviceIO = new FormattedIO488().IO;
                    deviceIO = (IMessage)ivs;
                }
                catch (Exception e)
                {
                    exceptionMessage = $"Ошибка: {e.Message}";
                    Close();
                }
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
        #endregion PrivateMethods

        #region NotUsed
        /*
        private Result CheckBus0()
        {
            Result result = Result.Failure;
            if (rm == null)
            {
                try
                {
                    rm = new ResourceManager();
                }
                catch (Exception e)
                {
                    exeptionMessage = $"Ошибка открытия порта: {e.Message}";
                    return Result.Exception;
                }
            }
            try
            {
                resourses = rm.FindRsrc("?*");
                foreach (string r in resourses)
                {
                    Console.WriteLine(r);
                }
                result = Result.Success;
            }
            catch
            {
                Marshal.FinalReleaseComObject(rm);
                result = Result.Exception;
            }
            finally
            {
                if (rm != null)
                {
                    Marshal.FinalReleaseComObject(rm);
                }
            }
            return result;
        }
        */
        #endregion NotUsed
    }

    public class ConnectedUSBPort
    {
        public GpibPort Port;
        public int CountConnections;
        public string DeviceInfo;
        public string Resource;


        public ConnectedUSBPort()
        {
            CountConnections = 0;
            DeviceInfo = string.Empty;
            Resource = string.Empty;
        }

        public Result Open(string resourceName)
        {
            Result result = Result.Failure;
            if (Port != null)
            {
                //TODO:
            }
            if (Port == null)
            {
                Port = new GpibPort(resourceName);
                CountConnections++;
            }
            return result;
        }
        public Result Close()
        {
            CountConnections--;
            if (CountConnections == 0)
            {
                Port.Close();
            }
            return Result.Success;
        }
    }
    public class ConnectedResource
    {
        public int CountConnections;
        public string ResourceName;
        public string DeviceInfo;
        public GpibPort Port;
        //public IMessage DeviceIO { get; set; }
        //private IMessage deviceIO;
        //private IVisaSession ivs;
        //private ResourceManager rm;
        public ConnectedResource(string resourceName) {
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
                Port = new GpibPort();
                result = Port.Init(ResourceName);
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
    }
}
