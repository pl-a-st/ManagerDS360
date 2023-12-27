using Ivi.Visa.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    internal class GpibPort
    {
        public int GpibAddress { get; set; }

        /// <summary>
        /// Текст сообщения о результате выполнения методов, имеющих тип возвращаемого значения <see cref="Result"/>
        /// </summary>
        public string ExeptionMessage
        {
            get
            {
                return exeptionMessage;
            }
            set
            {
                exeptionMessage = value;
            }
        }
        private int gpibAddress;

        public IMessage DeviceIO { get; set; }
        private IMessage deviceIO;
        private IVisaSession ivs;
        private ResourceManager rm;
        private static string[] resourses;
        private string resourseName = string.Empty;
        private string exeptionMessage = string.Empty;
        //private string resultMessage = string.Empty;
        //private string[] resourses;
        #region Constructors

        public GpibPort()
        {
            gpibAddress = 22;
            Init();
        }
        public GpibPort(int gpibAddress)
        {
            this.gpibAddress = gpibAddress;
            Init();
        }
        
        #endregion Constructors

        private void CheckBus0()
        {
            if (rm == null)
            {
                rm = new ResourceManager();
            }
            try
            {
                resourses = rm.FindRsrc("?*");
                foreach (string r in resourses)
                {
                    Console.WriteLine(r);
                }
            }
            catch
            {
                Marshal.FinalReleaseComObject(rm);
            }
            finally
            {
                if (rm != null)
                {
                    Marshal.FinalReleaseComObject(rm);
                }
            }
        }
        private void Init()
        {
            resourseName = $"GPIB0::{gpibAddress}::INSTR"; //ToDo: изменить строку на полученную от FindRsrc("?*")
            if (rm == null)
            {
                rm = new ResourceManager();
            }
            try
            {
                ivs = rm.Open(resourseName, AccessMode.NO_LOCK, 0, "");
            }
            catch (Exception e)
            {
                exeptionMessage = $"Ошибка открытия порта: {e.Message}";
                Marshal.FinalReleaseComObject(rm);
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
                    exeptionMessage = $"Ошибка: {e.Message}";
                    Close();
                }
            }
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
            if (deviceIO != null)
            {
                try
                {
                    deviceIO.WriteString(command);
                    return Result.Success;
                }
                catch (Exception e)
                {
                    exeptionMessage = $"Ошибка: {e.Message}";
                    return Result.Exception;
                }
            }
            return Result.Failure;
        }
        public string ReadString()
        {
            string str = string.Empty;
            str = ReadString(deviceIO);
            return str;
        }

        private string ReadChar(IMessage deviceIO)
        {
            string str = string.Empty;
            if (deviceIO != null)
            {
                try
                {
                    str = deviceIO.ReadString(1);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка: " + e.Message);
                    //str = "\n";
                }
            }
            return str;
        }
        private string ReadString(IMessage deviceIO)
        {
            string str = string.Empty;
            string ch = string.Empty;
            do
            {
                ch = ReadChar(deviceIO);
                if (ch == "\n" || ch == "\r")
                {
                    continue;
                }
                str += ch;
            }
            while (ch != string.Empty && ch != "\n");
            return str;

        }

        #region NotUsed

        #endregion NotUsed
    }
}
