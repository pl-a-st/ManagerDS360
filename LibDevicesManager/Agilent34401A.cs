using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    [Serializable]
    public class Agilent34401A : Multimeter<Agilent34401A>
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
        //public MultimeterModel MultimeterModel { get { return MultimeterModel.Agilent34401A; } }
        #endregion PublicFields

        #region PrivateFields
        private static string comPortDefaultName;
        private bool isComPortDefaultName = true;
        private string comPortName;
        private int comPortNumber;
        private string resultMessage;
        private static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        private static bool isDebugMode = false; //ToDel

        #endregion PrivateFields
        public Agilent34401A()
        {
            MultimeterModel = MultimeterModel.Agilent34401A;
        }

        #region PublicMethods

        public Result Send(string command)
        {
            throw new NotImplementedException(); //ToDo
        }

        public string Receive()
        {
            throw new NotImplementedException(); //ToDo
        }
        #endregion PublicMethods

    }
}
