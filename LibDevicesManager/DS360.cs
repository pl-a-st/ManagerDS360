using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    enum DS360Errors
    {

    }
    public enum DeviceType
    {
        Generator
    }
    public enum DeviceModel
    {
        DS360, DS360Emulator, Agilent
    }
    public enum FunctionType
    {
        Sine, Square, WhiteNoise, PinkNoise, TwoTone
    }
    public enum ToneBFunctionType
    {
        Sine, Square
    }
    [Serializable]
    public class DS360Setting
    {
        public static string ComPortDefaultName
        {
            get
            {
                if (comPortDefaultName == null || comPortDefaultName == string.Empty)
                {
                    SetGeneratorsPortAsDefaultComPort();
                }
                return comPortDefaultName;
            }
            set
            {
                if (ComPort.IsPortNameCorrect(value))
                {
                    comPortDefaultName = value;
                }
            }
        }
        public string ComPortName
        {
            get
            {
                if (comPortName == null || comPortName == string.Empty)
                {
                    return ComPortDefaultName;
                }
                return comPortName;
            }
            set
            {
                if (ComPort.IsPortNameCorrect(value))
                {
                    comPortName = value;
                }
            }
        }
        public DeviceModel Model { get { return DeviceModel.DS360; } }
        public DeviceType DeviceType { get { return DeviceType.Generator; } }
        public string SerialNumber { get; } //Прописать получение серийного номера
        public FunctionType FunctionType
        {
            get
            {
                return functionType;
            }
            set
            {
                functionType = value;
            }
        }
        public ToneBFunctionType FunctionBType
        {
            get
            {
                return functionTypeB;
            }
            set
            {
                functionTypeB = value;
            }
        }
        public double AmplitudeRMS
        {
            get
            {
                return amplitudeRMS;
            }
            set
            {
                amplitudeRMS = value;
            }
        }
        public double AmplitudeRMSToneB
        {
            get
            {
                return amplitudeRMSToneB;
            }
            set
            {
                amplitudeRMSToneB = value;
            }
        }
        public double Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }
        public double FrequencyB
        {
            get
            {
                return frequencyB;
            }
            set
            {
                frequencyB = value;
            }
        }
        public double Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = value;
            }
        }


        //
        private static string comPortDefaultName;
        private string comPortName;
        private string serialNumber;
        private FunctionType functionType;
        private ToneBFunctionType functionTypeB;
        private double amplitudeRMS;
        private double amplitudeRMSToneB;
        private double frequency;
        private double frequencyB;
        private double offset;
        #region Constructors
        //Конструкторы для SingleSignal
        public DS360Setting() { }
        public DS360Setting(double amplitudeRMS, double frequency) { }
        public DS360Setting(string portName, double amplitudeRMS, double frequency) { }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency) { }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency) { }
        public DS360Setting(double amplitudeRMS, double frequency, double offset) { }
        public DS360Setting(string portName, double amplitudeRMS, double frequency, double offset) { }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency, double offset) { }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency, double offset) { }
        //Конструкторы для TwoTone
        public DS360Setting(double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B) { }
        public DS360Setting(double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B, ToneBFunctionType functionType) { }
        public DS360Setting(string portName, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B) { }
        public DS360Setting(string portName, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B, ToneBFunctionType functionType) { }
        #endregion Constructors

        private static string SetGeneratorsPortAsDefaultComPort()
        {
            string portName = string.Empty;
            string[] devices = GetDevicesArray();
            foreach (string device in devices)
            {
                if (device.Contains("DS360")) //ToNEXT: Добавить другие типы генераторов
                {
                    portName = device;
                    break;
                }
            }
            return portName;
        }
        private string SetComPortName(string portName)
        {
            if (Array.IndexOf(GetDevicesArray(), portName) >= 0)
            {
                return portName;
            }
            return string.Empty; //Дописать
        }
        private string GetComPortName()
        {

            return string.Empty; //Дописать
        }

        public Result SetComPortDefaultName(string portName)
        {
            if (ComPort.IsPortNameCorrect(portName))
            {
                comPortDefaultName = portName;
                return Result.Success;
            }
            return Result.ParamError;
        }
        public string GetComPortDefaultName(string portName)
        {
            if (Array.IndexOf(GetDevicesArray(), portName) > 0)
            {
                return portName;
            }
            //...
            return portName;
        }
        public static List<string> GetComPortList()
        {
            List<string> portsNamesList = ComPort.PortsNamesList;
            return portsNamesList;
        }
        public static string[] GetDevicesArray()
        {
            List<string> ports = ComPort.PortsNamesList;
            string[] devices = new string[ports.Count];
            for (int i = 0; i < ports.Count; i++)
            {
                devices[i] = $"{ports[i]}: {ComPort.GetDeviceModel(ports[i])}";
            }
            return devices;
        }
        public Result SendDS360Setting(DS360Setting setting)
        {
            return Result.Success;
        }
        //Методы ниже перевести в приват
        private string GetSerialNumber()
        {
            string serialNumber = string.Empty;
            //...
            return serialNumber;
        }

        #region SetGeneratorsSetting
        private void SendFrequency(double frequency)
        {
            //...
        }
        private double ReceiveFrequency()
        {
            double frequency = 0;
            //...
            return frequency;
        }
        private Result SetGeneratorsFrequency(double frequency)
        {
            //...
            return Result.Success;
        }
        #endregion SetGeneratorsSetting
    }
}
