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
        private static string comPortDefaultName;
        private bool isComPortDefaultName = true;
        private string comPortName;
        private int comPortNumber;
        private string resultMessage = string.Empty;
        private static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        private static bool isDebugMode = false; //ToDel
        private GpibPort multimeter;
        #endregion PublicFields

        #region Constructors
        public Agilent3458A()
        {
            MultimeterModel = MultimeterModel.Agilent3458A;
            multimeter = new GpibPort(AddressGPIB);

        }

        #endregion Constructors

        #region PublicMethods

        public override Result SendSetting()
        {
            Result result = SendMeasureType();
            if (result != Result.Success)
            {
                return result;
            }
            result = SendPhysicalParameter();
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
        private Result SendMeasureType()
        {
            Result result = Result.Failure;
            if (MeasureType == MeasureType.AC)
            {
                string command = ""; //TODO: дописать КОМАНДУ
                result = multimeter.Send(command);
            }
            if (MeasureType == MeasureType.DC)
            {
                string command = ""; //TODO: дописать КОМАНДУ
                result = multimeter.Send(command);
            }
            return result;
        }
        private Result SendPhysicalParameter()
        {
            Result result = Result.Failure;
            if (PhysicalParameter == PhysicalParameter.U)
            {
                string command = ""; //TODO: дописать КОМАНДУ
                result = multimeter.Send(command);
            }
            if (PhysicalParameter == PhysicalParameter.I)
            {
                string command = ""; //TODO: дописать КОМАНДУ
                result = multimeter.Send(command);
            }
            return result;
        }
        private Result SendLowFrequencyLimit()
        {
            string command = ""; //TODO: дописать КОМАНДУ
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
        public override Result Measure(out double value)
        {
            value = 0;
            if (multimeter == null)
            {
                return Result.Failure;
            }
            string response;
            Result result = multimeter.ReadString(out response);
            if (result != Result.Success)
            {
                return result;
            }
            if (Double.TryParse(response, out value))
            {
                return Result.Success;
            }
            return Result.Failure;
        }
        #endregion PublicMethods
    }
}
