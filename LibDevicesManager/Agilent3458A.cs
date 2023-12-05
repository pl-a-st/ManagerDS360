using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa.Interop;

namespace LibDevicesManager
{
    [Serializable]
    public class Agilent3458A 
    {
        #region PublicFields

        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        public DeviceType DeviceType { get { return DeviceType.Multimeter; } }

        /// <summary>
        /// Модель устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceModel </returns>
        public DeviceModel DeviceModel { get { return DeviceModel.Agilent3458A; } }
        public int AddressGPIB;
        #endregion PublicFields

        #region PrivateFields
        private int adressGPIB;
        private static string comPortDefaultName;
        private bool isComPortDefaultName = true;
        private string comPortName;
        private int comPortNumber;
        private string resultMessage;
        private static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        private static bool isDebugMode = false; //ToDel
        #endregion PublicFields

        #region Constructors
        public Agilent3458A()
        {

        }
        #endregion Constructors

        #region PublicMethods

        #endregion PublicMethods
    }
}
