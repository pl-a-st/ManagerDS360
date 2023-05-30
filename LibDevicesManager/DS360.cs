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
        /*
        private ToneBFunctionType FunctionBType
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
        */
        //
        private static string comPortDefaultName;
        private string comPortName;
        private string serialNumber;
        private FunctionType functionType;
        //private ToneBFunctionType functionTypeB;
        private double amplitudeRMS;
        private double amplitudeRMSToneB;
        private double frequency;
        private double frequencyB;
        private double offset;
        private OutputType outputType;
        private OutputImpedance outputImpedance;
        private string resultMessage;
        // Верин: Очень похоже на глобальные константы, точно можно вынести в приватные поля класса
        private double frequencyMin = 0.01;
        private double frequencyMax = 200 * 1000;
        private double frequencyBMin = 0.1;
        private double frequencyBMax = 5 * 1000;
        private FunctionType[] functionTypeArray = new FunctionType[] { FunctionType.Sine, FunctionType.Square, FunctionType.SineSine, FunctionType.SineSquare };
        private double[] minVoltageRMSUnbalancedHiZ = new double[] { 4, 5, 3, 3 };
        private double[] maxVoltageRMSUnbalancedHiZ = new double[] { 14.14, 20.00, 14.14, 14.14 };
        private const double minVoltagePikUnbalancedHiZ = 0.000005;
        private const double maxVoltagePikUnbalancedHiZ = 20;
        private const double minTwoToneRatio = 0.001;
        private const double maxTwoToneRatio = 1000;
        #region Constructors
        //Конструкторы для SingleSignal
        public DS360Setting()
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = 1.000;
            this.frequency = 1000;
            this.offset = 0;
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
            this.outputType = OutputType.Unbalanced;
            this.outputImpedance = OutputImpedance.HiZ;
            //resultMessage = "1";
        }
        public DS360Setting(double amplitudeRMS, double frequency)
        {
            this.comPortName = ComPortDefaultName;
            this.functionType = FunctionType.Sine;
            this.amplitudeRMS = amplitudeRMS;
            this.frequency = frequency;
            this.offset = 0;
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
            this.frequencyB = 10000;
            this.amplitudeRMSToneB = 1;
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
        private bool IsSignalPeriodical()
        {
            if (FunctionType == FunctionType.Sine)
                return true;
            if (FunctionType == FunctionType.Square)
                return true;
            if (FunctionType == FunctionType.SineSine)
                return true;
            if (FunctionType == FunctionType.SineSquare)
                return true;
            return false;
        }
        private bool IsTwoToneSignal()
        {
            if (FunctionType == FunctionType.SineSine)
                return true;
            if (FunctionType == FunctionType.SineSquare)
                return true;
            return false;
        }
        private Result CheckFrequency()
        {

            Result result = Result.Success;
            if (IsSignalPeriodical())
            {
                if (Frequency < frequencyMin || Frequency > frequencyMax)
                {
                    resultMessage += "\nЧастота должна быть в пределах 0.01 ... 200000 Гц";
                    result = Result.ParamError;
                }
            }
            if (FunctionType == FunctionType.SineSine)
            {
                if (FrequencyB < frequencyMin || FrequencyB > frequencyMax)
                {
                    resultMessage += "\nЧастота второго сигнала должна быть в пределах 0.01 ... 200000 Гц";
                    result = Result.ParamError;
                }
            }
            if (FunctionType == FunctionType.SineSquare)
            {
                if (FrequencyB < frequencyBMin || FrequencyB > frequencyBMax)
                {
                    resultMessage += "\nЧастота второго сигнала должна быть в пределах 0,1 ... 5000 Гц";
                    result = Result.ParamError;
                }
            }
            return result;
        }
        private double GetPikSignal()
        {
            double volumePik = AmplitudeRMS;
            if (FunctionType == FunctionType.Sine)
            {
                volumePik = AmplitudeRMS * Math.Sqrt(2);
            }
            if (FunctionType == FunctionType.Square)
            {
                volumePik = AmplitudeRMS;
            }
            if (FunctionType == FunctionType.SineSine)
            {
                volumePik = AmplitudeRMS * Math.Sqrt(2) + AmplitudeRMSToneB * Math.Sqrt(2);
            }
            if (FunctionType == FunctionType.SineSquare)
            {
                volumePik = AmplitudeRMS * Math.Sqrt(2) + AmplitudeRMSToneB;
            }
            return volumePik;
        }
        private Result CheckTwoToneRatio()
        {
            Result result = Result.Success;
            if (!IsTwoToneSignal())
            {
                return result;
            }
            double pikToneA = AmplitudeRMS * Math.Sqrt(2);
            double pikToneB = AmplitudeRMSToneB;
            if (FunctionType == FunctionType.SineSine)
            {
                pikToneB *= Math.Sqrt(2);
            }
            double twoToneRatio = pikToneA / pikToneB;
            if (twoToneRatio < minTwoToneRatio || twoToneRatio > maxTwoToneRatio)
            {
                resultMessage += $"\nСоотношение амплитуд Тона 1 и Тона 2 должно быть в пределах {minTwoToneRatio} ... {maxTwoToneRatio}";
                result = Result.ParamError;
            }
            return result;
        }
        private Result CheckOffset(double amplitudePik)
        {
            Result result = Result.Success;
            if (OutputType != OutputType.Unbalanced)
            {
                return result;
            }
            double absOffset = Math.Abs(Offset);
            double maxOffset = Math.Abs(maxVoltagePikUnbalancedHiZ - amplitudePik);
            if (maxOffset > 200 * Math.Abs(amplitudePik))
            {
                maxOffset = 200 * Math.Abs(amplitudePik);
            }
            if (absOffset > (maxOffset))
            {
                resultMessage += $"\nПри заданной амплитуде абсолютное значение смещения сигнала не может превышать {AgRoundToDouble(maxOffset, 3, 6)} В";
                result = Result.ParamError;
            }
            return result;
        }
        private Result CheckVoltage()
        {
            Result result = Result.Success;
            if (IsTwoToneSignal())
            {
                result = CheckTwoToneRatio();
            }
            double amplitudePik = GetPikSignal();
            if (OutputType == OutputType.Unbalanced && OutputImpedance == OutputImpedance.HiZ)
            {
                if (amplitudePik > maxVoltagePikUnbalancedHiZ || amplitudePik < minVoltagePikUnbalancedHiZ)
                {
                    resultMessage += $"\nАмплитуда сигнала (ПИК) должна быть в пределах {minVoltagePikUnbalancedHiZ:F6} ... {maxVoltagePikUnbalancedHiZ} В";
                    result = Result.ParamError;
                }
            }
            //Дописать для других значений OutputType и OutputImpedance
            if (CheckOffset(amplitudePik) != Result.Success)
            {
                result = Result.ParamError;
            }
            return result;
        }
        public Result CheckDS360Setting()
        {
            resultMessage = string.Empty;
            Result result = CheckFrequency();
            if (CheckVoltage() != Result.Success)
            {
                result = Result.ParamError;
            }
            if (!ComPort.IsPortNameCorrect(ComPortName))
            {
                resultMessage += "\nЗадано некорректное имя Com-порта";
                result = Result.ParamError;
            }
            if (result == Result.Success)
            {
                resultMessage = "\nВсе парараметры корректны";
            }
            return result;
        }
        public Result SendDS360Setting()
        {
            Result result = this.CheckDS360Setting();
            if (result != Result.Success)
            {
                //resultMessage += "\nПараметры верны";
                return result;
            }
            //Прописать отправку настроек
            //прописать считывание с генератора настроек и сравнение с переданными значениями
            //дать команду на включение сигнала.
            //FunctionType = FunctionType.SineSine;
            resultMessage += "\nОтсутствует связь с генератором";
            return Result.Failure;
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
