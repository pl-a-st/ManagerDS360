using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
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
            FindAndInitFirstGpibPort();
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
            if (deviceIO != null)// todo не бывает null
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
        private void Init(string portName)
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
                result = ReadChar(deviceIO, out ch);
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
        private Result ReadChar(IMessage deviceIO, out string charReaded)
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
}
