using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa.Interop;

namespace LibDevicesManager
{
    [Serializable]
    public class Agilent3458A : Multimeter<Agilent3458A>
    {
        #region PublicFields

        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        //public DeviceType DeviceType { get { return DeviceType.Multimeter; } }

        /// <summary>
        /// Модель устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceModel </returns>
        //public MultimeterModel MultimeterModel { get { return MultimeterModel.Agilent3458A; } }
        public int AddressGPIB;
        public string PortName
        {
            get { return portName; }
        }
        public static List<string> ListAllAgilent3458APorts
        {
            get
            {
                return listAllAgilent3458APorts;
            }
        }
        /// <summary>
        /// Текст сообщения о результате выполнения методов, имеющих тип возвращаемого значения <see cref="Result"/>
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return resultMessage;
            }
            set
            {
                resultMessage = value;
            }
        }
        #endregion PublicFields

        #region PrivateFields
        private int adressGPIB = 22;
        private string portName;
        private static List<string> listAllAgilent3458APorts;
        //private static string comPortDefaultName;
        //private bool isComPortDefaultName = true;
        //private string comPortName;
        //private int comPortNumber;
        private string resultMessage = string.Empty;
        private static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        private const double powerLineFrequency = 50;
        //private static bool isDebugMode = false; //ToDel
        private GpibPort multimeter;
        #endregion PublicFields

        #region Constructors
        public Agilent3458A()
        {
            MultimeterModel = MultimeterModel.Agilent3458A;
            string portName = string.Empty;
            FindFirstAgilent3458APort(out portName);
            multimeter = new GpibPort(portName);
            this.portName = portName;
        }
        public Agilent3458A(string portName)
        {
            MultimeterModel = MultimeterModel.Agilent3458A;
            multimeter = new GpibPort(portName);
            this.portName = portName;
        }

        #endregion Constructors

        #region PublicMethods
        public static List<string> FindAllAgilent3458A()
        {
            Result result = Result.Failure;
            List<string> ports = GpibPort.GetGpibPorts();
            List<string> portsAgilent3458A = new List<string>();
            if (ports != null)
            {
                foreach (string port in ports)
                {
                    if (FindAgilent3458AOnPort(port) == Result.Success)
                    {
                        portsAgilent3458A.Add(port);
                    }
                }
            }
            return portsAgilent3458A;
        }
        public static Result FindAgilent3458AOnPort(string portName)
        {
            Result result = Result.Failure;
            GpibPort device = new GpibPort(portName);
            result = device.Send("ID?");
            if (result != Result.Success)
            {
                device.Close();
                return result;
            }
            string response = string.Empty;
            result = device.ReadString(out response);
            if (result != Result.Success)
            {
                device.Close();
                return result;
            }
            if (response != "HP3458A")
            {
                device.Close();
                return Result.Failure;
            }
            device.Close();
            return Result.Success;
        }
        public static Result FindFirstAgilent3458APort(out string port)
        {
            List<string> portsAgilent3458A = FindAllAgilent3458A();
            if (portsAgilent3458A != null && portsAgilent3458A.Count > 0)
            {
                port = portsAgilent3458A[0];
                return Result.Success;
            }
            port = string.Empty;
            return Result.Failure;
        }

        public override Result SendSetting()
        {
            Result result = SendMeasureFunction();
            if (result != Result.Success)
            {
                return result;
            }

            result = SendLowFrequencyLimit();
            if (result != Result.Success)
            {
                return result;
            }
            //TODO: дописать проверку правильности установок настроек?
            return result;
        }
        public Result SetACBandwidth(double frequencyLow, double frequencyHigh)
        {
            return multimeter.Send($"ACBAND {frequencyLow}, {frequencyHigh}");
        }
        private Result SendMeasureFunction()
        {
            Result result = Result.Failure;
            string command = string.Empty;
            if (MeasureType == MeasureType.AC && PhysicalParameter == PhysicalParameter.U)
            {
                command = "ACV";
            }
            if (MeasureType == MeasureType.AC && PhysicalParameter == PhysicalParameter.I)
            {
                command = "ACI";
            }
            if (MeasureType == MeasureType.DC && PhysicalParameter == PhysicalParameter.U)
            {
                command = "DCV";
            }
            if (MeasureType == MeasureType.DC && PhysicalParameter == PhysicalParameter.I)
            {
                command = "DCI";
            }
            result = multimeter.Send(command);
            return result;
        }
        private Result SendLowFrequencyLimit()
        {
            int nplc = 1;
            if (InputSignalMinFrequency < 100 && InputSignalMinFrequency > 0)
            {
                nplc = (int) Math.Round(powerLineFrequency / InputSignalMinFrequency*2);
            }
            string command = "NPLC " + nplc; 
            return multimeter.Send(command);
        }
        public override Result Send(string command)
        {
            if (multimeter == null)
            {
                return Result.Failure;
            }
            return multimeter.Send(command);
        }

        public override Result Receive(out string response)
        {
            response = string.Empty;
            if (multimeter == null)
            {
                return Result.Failure;
            }
            return multimeter.ReadString(out response);
        }
        public override Result Measure(out double value, int averages = 1)
        {
            value = 0;
            if (multimeter == null)
            {
                return Result.Failure;
            }
            if (averages < 1)
            {
                return Result.ParamError;
            }
            string response;
            double sum = 0;
            for (int i = 1; i <= averages; i++)
            {
                Result result = multimeter.ReadString(out response);
                if (result != Result.Success)
                {
                    return result;
                }
                response = response.Replace(".", decimalSeparator);
                if (!Double.TryParse(response, out value))
                {
                    return Result.Failure;
                }
                sum += value;
            }
            value = sum / averages;
            return Result.Success;
        }
        #endregion PublicMethods
    }
}
