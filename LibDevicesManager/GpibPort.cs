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

        private Result CheckBus0()
        {
            Result result = Result.Failure;
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
                    exeptionMessage = $"Ошибка: {e.Message}";
                    return Result.Exception;
                }
            }
            return Result.Success;
        }


        #region NotUsed

        #endregion NotUsed
    }
}
