using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public class Multimeter : IMultimeter
    {
        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        public DeviceType DeviceType { get { return DeviceType.Multimeter; } }

        public DeviceModel DeviceModel { get { return deviceModel; } set { deviceModel = value; } }

        private DeviceModel deviceModel = DeviceModel.Unknown;
        public Multimeter() { }
        public Result SendSetting()
        {
            return Result.Failure;
        }
        public double Measure()
        {
            double value = 0;
            return value;
        }
        public string Receive()
        {
            if (deviceModel == DeviceModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A();
                return multimeter.Receive();
            }
            if (deviceModel == DeviceModel.Agilent34401A)
            {
                return string.Empty; //Прописать код
            }
            return string.Empty;
        }

        public Result Send(string command)
        {
            if (deviceModel == DeviceModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A();
                return multimeter.Send(command);
            }
            if (deviceModel == DeviceModel.Agilent34401A)
            {
                return Result.Failure; //Прописать код
            }
            return Result.Failure;
        }
    }
}
