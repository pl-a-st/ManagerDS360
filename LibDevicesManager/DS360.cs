using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Тестовое обновление

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
        Sine, Square, SineSine, SineSquare //ToNEXT: , WhiteNoise, PinkNoise
    }
    public enum ToneBFunctionType
    {
        Sine, Square
    }
    public enum OutputType
    {
        Unbalanced
    }
    public enum OutputImpedance
    {
        HiZ
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
                    //SetGeneratorsPortAsDefaultComPort();
                    comPortDefaultName = "NONE";
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
        public OutputType OutputType
        {
            get
            {
                return outputType;
            }
            set
            {
                outputType = value;
            }
        }
        public OutputImpedance OutputImpedance
        {
            get
            {
                return outputImpedance;
            }
            set
            {
                outputImpedance = value;
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
        private OutputType outputType;
        private OutputImpedance outputImpedance;

        //Добавить Оффсет в двухтоновый конструктор
        #region Constructors
        //Конструкторы для SingleSignal
        public DS360Setting()
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = 0;
            this.frequency = 0;
            this.offset = 0;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(double amplitudeRMS, double frequency)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = 0;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, double amplitudeRMS, double frequency)
        {
            this.comPortName = portName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = 0;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = 0;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency)
        {
            this.comPortName = portName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = 0;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(double amplitudeRMS, double frequency, double offset)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = offset;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, double amplitudeRMS, double frequency, double offset)
        {
            this.comPortName = portName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = offset;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency, double offset)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = offset;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency, double offset)
        {
            this.comPortName = portName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = offset;
            this.frequencyB = 0;
            this.amplitudeRMSToneB = 0;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        //Новые конструкторы для TwoTone
        public DS360Setting(double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.SineSine;
            this.amplitudeRMS = amplitudeRMS_A;
            this.frequency = frequency_A;
            this.offset = 0;
            this.frequencyB = frequency_B;
            this.amplitudeRMSToneB = amplitudeRMS_B;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(FunctionType functionType, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS_A;
            this.frequency = frequency_A;
            this.offset = 0;
            this.frequencyB = frequency_B;
            this.amplitudeRMSToneB = amplitudeRMS_B;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B)
        {
            this.comPortName = portName;
            this.functionType = FunctionType.SineSine;
            this.amplitudeRMS = amplitudeRMS_A;
            this.frequency = frequency_A;
            this.offset = 0;
            this.frequencyB = frequency_B;
            this.amplitudeRMSToneB = amplitudeRMS_B;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, FunctionType functionType, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B)
        {
            this.comPortName = portName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS_A;
            this.frequency = frequency_A;
            this.offset = 0;
            this.frequencyB = frequency_B;
            this.amplitudeRMSToneB = amplitudeRMS_B;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        public DS360Setting(string portName, FunctionType functionType, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B, double offset)
        {
            this.comPortName = portName;
            this.functionType = functionType;
            this.amplitudeRMS = amplitudeRMS_A;
            this.frequency = frequency_A;
            this.offset = offset;
            this.frequencyB = frequency_B;
            this.amplitudeRMSToneB = amplitudeRMS_B;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
        }
        #endregion Constructors

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
        public Result CheckDS360Setting(DS360Setting setting, out string message)
        {
            double frequencyMin = 0.01;
            double frequencyMax = 200 * 1000;
            double frequencyBMin = 0.1;
            double frequencyBMax = 5 * 1000;
            //Проверка на корректность параметров
            if (setting.FunctionType == FunctionType.Sine || setting.FunctionType == FunctionType.Square || setting.FunctionType == FunctionType.SineSine || setting.FunctionType == FunctionType.SineSquare)
            {
                if (setting.Frequency < frequencyMin || setting.Frequency > frequencyMax)
                {
                    message = "\nЧастота должна быть в пределах 0.01 ... 200000 Гц";
                    return Result.ParamError;
                }
            }
            if (setting.FunctionType == FunctionType.SineSquare)
            {
                if (setting.FrequencyB < frequencyBMin || setting.FrequencyB > frequencyBMax)
                {
                    message = "\nЧастота второго сигнала должна быть в пределах 0,1 ... 5000 Гц";
                    return Result.ParamError;
                }
            }
            //Амплитуда
            FunctionType[] functionTypeArray = new FunctionType[] { FunctionType.Sine, FunctionType.Square, FunctionType.SineSine, FunctionType.SineSquare };
            double[] minVoltageRMS = new double[] { 4, 5, 3, 3 };
            double[] maxVoltageRMS = new double[] { 14.14, 20.00, 14.14, 14.14 };
            for (int i = 0; i < minVoltageRMS.Length; i++)
            {
                minVoltageRMS[i] /= 1000000;
            }
            if (setting.outputType == OutputType.Unbalanced && setting.OutputImpedance == OutputImpedance.HiZ)
            {
                for (int i = 0; i < functionTypeArray.Length; i++)
                {
                    if (setting.FunctionType == functionTypeArray[i])
                    {
                        if (setting.AmplitudeRMS < minVoltageRMS[i] || setting.AmplitudeRMS > maxVoltageRMS[i])
                        {
                            message = $"\nАмплитуда должна быть в пределах {minVoltageRMS[i]} ... {maxVoltageRMS[i]} Вольт";
                            return Result.ParamError;
                        }
                        if (setting.FunctionType == FunctionType.SineSine || setting.FunctionType == FunctionType.SineSquare)
                        {
                            if (setting.AmplitudeRMSToneB < minVoltageRMS[i] || setting.AmplitudeRMSToneB > maxVoltageRMS[i])
                            {
                                message = $"\nАмплитуда должна быть в пределах {minVoltageRMS[i]} ... {maxVoltageRMS[i]} Вольт";
                                return Result.ParamError;
                            }
                            if ((setting.AmplitudeRMS + setting.AmplitudeRMSToneB) > maxVoltageRMS[i])
                            {
                                message = $"\nСумма амплитуд должна быть в пределах {minVoltageRMS[i]} ... {maxVoltageRMS[i]} Вольт";
                                return Result.ParamError;
                            }
                        }
                        break;
                    }
                }
            }
            //Дописать для других значений OutputType и OutputImpedance

            //Смещение


            message = "Успешно";
            return Result.Success;
        }
        public Result SendDS360Setting(DS360Setting setting)
        {
            //Прописать проверку корректности параметров setting
            //Прописать отправку настроек
            //прописать считывание с генератора настроек и сравнение с переданными значениями
            //дать команду на включение сигнала.
            return Result.Success;
        }
        private static string AgRoundTostring(double volume, int significantDigits, int maxDecimalPlaces)
        {
            string resultString = string.Empty;
            double digits = Math.Pow(10, significantDigits - Math.Ceiling(Math.Log10(volume)));
            int zeros = digits.ToString().Length - 1;
            double res = Math.Round(volume * digits) / digits;
            if (digits > 1)
            {
                if (zeros > maxDecimalPlaces)
                {
                    resultString = res.ToString($"F{maxDecimalPlaces}");
                }
                if (zeros <= maxDecimalPlaces)
                {
                    resultString = res.ToString($"F{zeros}");
                }
            }
            if (digits <= 1)
            {
                resultString = Convert.ToString(res);
            }
            return resultString;
        }
        private static double AgRoundToDouble(double volume, int significantDigits, int maxDecimalPlaces)
        {
            string resultString = AgRoundTostring(volume, significantDigits, maxDecimalPlaces);
            Double.TryParse(resultString, out double result);
            return result;
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

        private bool IsFrequencyCorrect(double value)
        {
            //Вписать округление до значащих?
            //...
            if (value < 0)
            {
                return false;
            }
            return true;
        }
        #region UnUsed
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
        #endregion UnUsed
    }
}
