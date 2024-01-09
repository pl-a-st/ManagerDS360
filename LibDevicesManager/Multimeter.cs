using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public enum MeasureType
    {
        AC,
        DC
    }
    public enum PhysicalParameter
    {
        U,
        I
    }
    [Serializable]
    public abstract class Multimeter <T>: IMultimeter
    {
        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        public DeviceType DeviceType { get { return DeviceType.Multimeter; } }

        public MultimeterModel MultimeterModel { get { return multimeterModel; } set { multimeterModel = value; } }
        public string PortName
        {
            get
            {
                return portName;
            }
            set
            {
                portName = value;
            }
        }

        public MeasureType MeasureType { get { return measureType; } set { measureType = value; } }
        public PhysicalParameter PhysicalParameter { get { return physicalParameter; } set { physicalParameter = value; } }
        public int LowFrequencyLimit { get { return lowFrequencyLimit; }  set {lowFrequencyLimit = value; } }
        
        private MeasureType measureType = MeasureType.AC;
        private PhysicalParameter physicalParameter = PhysicalParameter.U;
        private int lowFrequencyLimit = 20;

        private MultimeterModel multimeterModel = MultimeterModel.Unknown;
        private string portName = "GPIB0::22";
        public Multimeter() { }
        public virtual Result SendSetting()
        {
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.SendSetting();
            }
                return Result.Failure;
        }
        public virtual Result Measure(out double value)
        {
            value = 0;
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Measure(out value);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                //TODO: прописать код
                return Result.Failure;
            }
            //TODO: прописать код
            return Result.Failure;
        }
        public virtual Result Receive(out string response)
        {
            response = string.Empty;
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Receive(out response);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                return Result.Failure; //TODO: Прописать код
            }
            return Result.Failure;
        }

        public virtual Result Send(string command)
        {
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Send(command);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                return Result.Failure; //Прописать код
            }
            return Result.Failure;
        }
    }
}
