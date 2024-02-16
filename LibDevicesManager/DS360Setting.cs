using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibDevicesManager
{
    #region Enums
    enum DS360Errors
    {

    }
    public enum FunctionType
    {
        Sine, Square, SineSine, SineSquare //ToDo: , WhiteNoise, PinkNoise
    }
    public enum ToneBFunctionType
    {
        Sine, Square
    }
    public enum OutputMode
    {
        Analog, Digital
    }
    public enum OutputType
    {
        Unbalanced //ToDo: , Balanced
    }
    public enum OutputImpedance
    {
        HiZ //ToDo: , 50_Om, 150_Om, 600_Om
    }
    #endregion Enums
    [Serializable]
    public class DS360Setting
    {
        #region PublicFields

        /// <summary>
        /// Задаёт или возвращает имя Com-порта для использования по умолчанию
        /// </summary>
        /// <value><strong><see langword="NONE"/></strong> - означает, что имя Com-порта не назначено</value>
        public static string ComPortDefaultName
        {
            get
            {
                return GetComPortDefaultName();
            }
            set
            {
                SetComPortDefaultName(value);
            }
        }

        /// <summary>
        /// Задаёт или возвращает использование имени COM-порта по умолчанию.
        /// </summary>
        /// <value><br><strong><see langword="true"/></strong> - будет использовано имя COM-порта, заданное в поле <see cref="ComPortDefaultName"/></br>
        /// <br><strong><see langword="false"/></strong> - будет использовано имя COM-порта, заданное в поле <see cref="ComPortName"/></br>
        /// </value> 
        public bool IsComPortDefaultName
        {
            get
            {
                return isComPortDefaultName;
            }
            set
            {
                isComPortDefaultName = value;
            }
        }

        /// <summary>
        /// Задаёт или возвращает имя Com-порта
        /// </summary>
        /// <returns>Имя Com-порта</returns>
        /// <value>Допустимые значения от  COM1 до COM256</value>
        public string ComPortName //Проверить использование IsComPortDefaultName
        {
            get
            {
                if (comPortName == null || comPortName == string.Empty || IsComPortDefaultName)
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
                    comPortNumber = (ComPort.GetPortNumberFromPortName(value));
                }
            }
        }

        /// <summary>
        /// Задаёт номер Com-порта
        /// </summary>
        /// <value>Допустимые значения от 1 до 256</value>
        public int ComPortNumber
        {
            set
            {
                SetComPortNumber(value);
            }
        }

        public static List<ConnectedCOMPort> ConnectedCOMPort;

        /// <summary>
        /// Модель генератора
        /// </summary>
        /// <returns>одно из значений перечисления DeviceModel </returns>
        public GeneratorModel GeneratorModel { get { return GeneratorModel.DS360; } }
        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        public DeviceType DeviceType { get { return DeviceType.Generator; } }
        /// <summary>
        /// Задаёт или возвращает тип функции выходного сигнала.
        /// </summary>
        /// <returns>Тип функции выходного сигнала.</returns>
        /// <value><br><strong><see langword="Sine"/></strong> - тип функции: "Синус"</br>
        /// <br><strong><see langword="Square"/></strong> - тип функции: "Квадрат"</br>
        /// <br><strong><see langword="SineSine"/></strong> - тип функции: "Синус" для первого тона и "Синус" для второго тона</br>
        /// <br><strong><see langword="SineSquare"/></strong> - тип функции: "Синус" для первого тона и "Квадрат" для второго тона</br>
        /// </value> 
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
        /// <summary>
        /// Задаёт или возвращает СКЗ амплитуды сигнала в вольтах (СКЗ амплитуды первого тона для двухтонального сигнала).
        /// </summary>
        /// <returns>СКЗ амплитуды сигнала в вольтах (СКЗ амплитуды первого тона для двухтонального сигнала).</returns>
        /// <value>Допустимые значения от 0.000005 до 20 </value>
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
        /// <summary>
        /// Задаёт или возвращает СКЗ амплитуды второго тона сигнала в вольтах (для двухтонального сигнала).
        /// </summary>
        /// <returns>СКЗ амплитуды второго тона сигнала в вольтах (для двухтонального сигнала).</returns>
        /// <value>Допустимые значения амплитуды от 0.000005 до 20 </value>
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

        /// <summary>
        /// Задаёт или возвращает частоту сигнала в Гц (частоту первого тона для двухтонального сигнала).
        /// </summary>
        /// <returns>Частоту сигнала в Гц (частоту первого тона для двухтонального сигнала).</returns>
        /// <value>Допустимые значения частоты от 0.01 до 200000 </value>
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

        /// <summary>
        /// Задаёт или возвращает частоту второго тона сигнала в Гц (для двухтонального сигнала).
        /// </summary>
        /// <returns>частоту второго тона сигнала в Гц (для двухтонального сигнала).</returns>
        /// <value><br>Допустимые значения частоты:</br>
        /// <br>при форме второго тона сигнала "Синус" - от 0.01 до 200000 </br>
        /// <br>при форме второго тона сигнала "Квадрат" - от 0.1 до 5000 </br></value>
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

        /// <summary>
        /// Задаёт или возвращает значение напряжения постоянной составляющей сигнала в Вольт.
        /// </summary>
        /// <returns>Значение напряжения постоянной составляющей сигнала </returns>
        /// <value><br>Допустимые значения смещения: от -20 до 20</br></value>
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
        public OutputMode OutputMode
        {
            get
            {
                return outputMode;
            }
            set
            {
                outputMode = value;
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

        public static int CountCalls = 0;
        #endregion PublicFields

        #region PrivateFields
        private static string comPortDefaultName;
        private bool isComPortDefaultName = false;
        private string comPortName;
        private int comPortNumber;
        private FunctionType functionType;
        private double amplitudeRMS;
        private double amplitudeRMSToneB;
        private double frequency;
        private double frequencyB;
        private double offset;
        private OutputMode outputMode = OutputMode.Analog;
        private OutputType outputType = OutputType.Unbalanced;
        private OutputImpedance outputImpedance = OutputImpedance.HiZ;
        private bool outputEnableState = false;
        private string resultMessage;
        private static List<string> generatorsList;
        private const double frequencyMin = 0.01;
        private const double frequencyMax = 200 * 1000;
        private const double frequencyBMin = 0.1;
        private const double frequencyBMax = 5 * 1000;
        private const double minVoltagePikUnbalancedHiZ = 0.000005;
        private const double maxVoltagePikUnbalancedHiZ = 20;
        private const double minTwoToneRatio = 0.001;
        private const double maxTwoToneRatio = 1000;
        private static string decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
        private static bool isDebugMode = false; //ToDel

        private static List<double> errorList = new List<double>()
        { 4.881, 4.871, 4.484, 4.474, 4.424, 4.333, 4.057, 4.037, 4.007, 3.619, 3.388, 3.378, 3.348, 3.318, 2.041, 1.761, 1.751, 1.731, 1.701, 1.382, 1.372, 1.322, 1.312, 1.115, 0.9869, 0.9805, 0.9775, 0.9745, 0.9741, 0.9725, 0.9715, 0.9677, 0.9613, 0.9396, 0.9366, 0.9356, 0.9336, 0.9306, 0.8765, 0.8735, 0.8705, 0.8386, 0.8376, 0.8346, 0.8316, 0.7972, 0.7908, 0.7844, 0.7795, 0.778, 0.7765, 0.7755, 0.7735, 0.7705, 0.7386, 0.7376, 0.7346, 0.7326, 0.7316, 0.6775, 0.6745, 0.6725, 0.6715, 0.6366, 0.6336, 0.5947, 0.5883, 0.5819, 0.5785, 0.5755, 0.5745, 0.5715, 0.5396, 0.5366, 0.5356, 0.5336, 0.5306, 0.4765, 0.4755, 0.4735, 0.4705, 0.4386, 0.4376, 0.4346, 0.4326, 0.4316, 0.3986, 0.3922, 0.3854, 0.3775, 0.3745, 0.3725, 0.3715, 0.3356, 0.3336, 0.3306, 0.2795, 0.2755, 0.2735, 0.2705, 0.2386, 0.2376, 0.2346, 0.2326, 0.2316, 0.2089, 0.2025, 0.1961, 0.1897, 0.1833, 0.1765, 0.1755, 0.1735, 0.1705, 0.1376, 0.1346, 0.1326, 0.1316, 0.09995, 0.09965, 0.09955, 0.09935, 0.09933, 0.09905, 0.09805, 0.09677, 0.09654, 0.0956, 0.0955, 0.09549, 0.0953, 0.095, 0.09294, 0.09293, 0.09183, 0.09173, 0.09165, 0.09143, 0.09123, 0.09113, 0.09037, 0.08985, 0.08945, 0.08915, 0.08909, 0.08653, 0.0858, 0.0857, 0.0854, 0.0852, 0.0851, 0.08163, 0.08133, 0.08103, 0.07985, 0.07975, 0.07945, 0.07925, 0.07915, 0.0758, 0.0757, 0.0754, 0.0752, 0.07193, 0.07163, 0.07153, 0.07133, 0.06995, 0.06965, 0.06955, 0.06935, 0.06905, 0.0659, 0.0656, 0.0655, 0.0653, 0.065, 0.06183, 0.06173, 0.06143, 0.06113, 0.05965, 0.05955, 0.05935, 0.05905, 0.05604, 0.0559, 0.0556, 0.0553, 0.055, 0.05183, 0.05173, 0.05143, 0.05123, 0.05113, 0.05067, 0.04945, 0.04925, 0.04915, 0.0457, 0.0454, 0.0452, 0.0451, 0.04193, 0.04163, 0.04153, 0.04103, 0.03995, 0.03955, 0.03935, 0.03767, 0.0359, 0.0356, 0.0355, 0.0353, 0.035, 0.03173, 0.03143, 0.03123, 0.02985, 0.02975, 0.02945, 0.02925, 0.02915, 0.0258, 0.0257, 0.0254, 0.0252, 0.0251, 0.02193, 0.02163, 0.02153, 0.02133, 0.02103, 0.02048, 0.01985, 0.01975, 0.01945, 0.01915, 0.01664, 0.0158, 0.0157, 0.0154, 0.0152, 0.0151, 0.01408, 0.01237, 0.01193, 0.01152, 0.01103, 0.01024, 0.009996, 0.00999, 0.009985, 0.009984, 0.009979, 0.009973, 0.009967, 0.009961, 0.009955, 0.00995, 0.009944, 0.009938, 0.009932, 0.009926, 0.00992, 0.009915, 0.009909, 0.009903, 0.009897, 0.009891, 0.00988, 0.009874, 0.009868, 0.009862, 0.009861, 0.009856, 0.009845, 0.009839, 0.009833, 0.009831, 0.009827, 0.009821, 0.00981, 0.009804, 0.009798, 0.009792, 0.009786, 0.009775, 0.009769, 0.009763, 0.009757, 0.009751, 0.009746, 0.00974, 0.009734, 0.009728, 0.009722, 0.009716, 0.009711, 0.009705, 0.009699, 0.009693, 0.009687, 0.009676, 0.00967, 0.009664, 0.009658, 0.009652, 0.009641, 0.009635, 0.009629, 0.009623, 0.009617, 0.009606, 0.0096, 0.009594, 0.009588, 0.009582, 0.009571, 0.009565, 0.009559, 0.009553, 0.009547, 0.009536, 0.00953, 0.009524, 0.009518, 0.009512, 0.009501, 0.009495, 0.009489, 0.009483, 0.009472, 0.009466, 0.009464, 0.00946, 0.009454, 0.009448, 0.009431, 0.009425, 0.009419, 0.009413, 0.009404, 0.009402, 0.009396, 0.00939, 0.009384, 0.009378, 0.009367, 0.009361, 0.009355, 0.009349, 0.009343, 0.009332, 0.009326, 0.00932, 0.009314, 0.009308, 0.009297, 0.009291, 0.009285, 0.009279, 0.009262, 0.009256, 0.00925, 0.009244, 0.009227, 0.009221, 0.009216, 0.009215, 0.009209, 0.009192, 0.009186, 0.00918, 0.009174, 0.009157, 0.009151, 0.009145, 0.009139, 0.009122, 0.009116, 0.00911, 0.009093, 0.009087, 0.009081, 0.009075, 0.009058, 0.009052, 0.009047, 0.009046, 0.00904, 0.009027, 0.009023, 0.009017, 0.009011, 0.009005, 0.008988, 0.008982, 0.008976, 0.00897, 0.00896, 0.008953, 0.008947, 0.008941, 0.008935, 0.008918, 0.008912, 0.008906, 0.008883, 0.008881, 0.008877, 0.008871, 0.008848, 0.008842, 0.008841, 0.008836, 0.008821, 0.008813, 0.008811, 0.008807, 0.008801, 0.008778, 0.008772, 0.008766, 0.008749, 0.008743, 0.008737, 0.008731, 0.008714, 0.008708, 0.008704, 0.008702, 0.008679, 0.008673, 0.008667, 0.008644, 0.008638, 0.008632, 0.008609, 0.008603, 0.008597, 0.008574, 0.008568, 0.008562, 0.008539, 0.008533, 0.008527, 0.008504, 0.008498, 0.008484, 0.008474, 0.008469, 0.008463, 0.008448, 0.008444, 0.00844, 0.008434, 0.008428, 0.008424, 0.008405, 0.008399, 0.008393, 0.00837, 0.008364, 0.008358, 0.008335, 0.008329, 0.008323, 0.0083, 0.008294, 0.008265, 0.008259, 0.00823, 0.008224, 0.008195, 0.008192, 0.008189, 0.00816, 0.008154, 0.008125, 0.008119, 0.008097, 0.008096, 0.00809, 0.008067, 0.008061, 0.008057, 0.008055, 0.008037, 0.008026, 0.00802, 0.008007, 0.007991, 0.007985, 0.007956, 0.00795, 0.007936, 0.007921, 0.007886, 0.007871, 0.007851, 0.007841, 0.007816, 0.007811, 0.007781, 0.007752, 0.007746, 0.007717, 0.007682, 0.00768, 0.007647, 0.007612, 0.007577, 0.007542, 0.007484, 0.007474, 0.007444, 0.007443, 0.007424, 0.007414, 0.007408, 0.007373, 0.007338, 0.007168, 0.007097, 0.007067, 0.007057, 0.007037, 0.007007, 0.006912, 0.006891, 0.006861, 0.006851, 0.006831, 0.006801, 0.006656, 0.006494, 0.006464, 0.006454, 0.006404, 0.0064, 0.006144, 0.006087, 0.006077, 0.006047, 0.006027, 0.006017, 0.005891, 0.005888, 0.005861, 0.005851, 0.005831, 0.005801, 0.005632, 0.005494, 0.005454, 0.005434, 0.005404, 0.005376, 0.00512, 0.005087, 0.005077, 0.005047, 0.005027, 0.005017, 0.004881, 0.004871, 0.004864, 0.004841, 0.004608, 0.004484, 0.004474, 0.004444, 0.004414, 0.004352, 0.004096, 0.004067, 0.004057, 0.004037, 0.004007, 0.003891, 0.003851, 0.00384, 0.003831, 0.003801, 0.00376, 0.003584, 0.003494, 0.003464, 0.003434, 0.003404, 0.003328, 0.003087, 0.003072, 0.003047, 0.003017, 0.002881, 0.002871, 0.002841, 0.002821, 0.002816, 0.002811, 0.00256, 0.002484, 0.002474, 0.002444, 0.002414, 0.002304, 0.002097, 0.002067, 0.002057, 0.002048, 0.002037, 0.002007, 0.001881, 0.001841, 0.001821, 0.001811, 0.001792, 0.001536, 0.001484, 0.001474, 0.001444, 0.001424, 0.001414, 0.00128, 0.001067, 0.001057, 0.001037, 0.001024, 0.001007, 0.000891, 0.000861, 0.000851, 0.000831, 0.000801, 0.000768, 0.000512, 0.000494, 0.000464, 0.000454, 0.000434, 0.000256, 8.7E-05, 7.7E-05, 2.7E-05, 1.7E-05 };// ToDo в ресурсы

        #endregion PrivateFie

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

        #region PublicMethods

        public static Result ConnectCOMPort(string portName)
        {
            Result result = Result.Failure;
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            if (ConnectedCOMPort == null)
            {
                ConnectedCOMPort = new List<ConnectedCOMPort>();
            }
            if (ConnectedCOMPort.Count != 0)
            {
                int index = FindIndexInConnectedComPort(portName);
                if (index >= 0)
                {
                    ConnectedCOMPort[index].CountConnections++;
                    return Result.Success;
                }
            }
            ConnectedCOMPort comPort = new ConnectedCOMPort();
            result = comPort.Open(portName);
            if (result != Result.Success)
            {
                return result;
            }
            string command = "*IDN?";
            string identificationString = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                result = ComPort.Send(comPort.Port, command);
                if (result == Result.Success)
                {
                    Thread.Sleep(300);
                    identificationString = ComPort.Receive(comPort.Port);
                    identificationString = identificationString.Substring(0, identificationString.Length - 1);
                    if (IsItDS360(identificationString))
                    {
                        comPort.DeviceInfo += $" DS360, s/n{GetSerialNumber(identificationString)}";
                        ConnectedCOMPort.Add(comPort);
                        ComPort.PortClear(comPort.Port);
                        return Result.Success;
                    }
                }
            }
            result = comPort.Close();
            return Result.Failure;
        }
        public static Result ConnectCOMPort(int portNumber)
        {
            string portName = $"COM{portNumber}";
            return ConnectCOMPort(portName);
        }
        public static Result DisconnectCOMPort(string portName)
        {
            Result result = Result.Failure;
            if (ConnectedCOMPort != null && ConnectedCOMPort.Count != 0)
            {
                int index = FindIndexInConnectedComPort(portName);
                if (index >= 0)
                {
                    result = ConnectedCOMPort[index].Close();
                    if (ConnectedCOMPort[index].CountConnections == 0)
                    {
                        ConnectedCOMPort.RemoveAt(index);
                    }
                    return result;
                }
            }
            return result;
        }
        public static Result DisconnectCOMPort(int portNumber)
        {
            string portName = $"COM{portNumber}";
            return DisconnectCOMPort(portName);
        }

        /// <summary>
        /// Производит поиск подключенных к компъютеру генераторов DS360.
        /// </summary>
        /// <param name="needRefreshGeneratorsList"> Необходимость опроса Com-портов.</param>
        /// <value><br><see langword="true"/> - будет произведён новый опрос портов.</br> 
        /// <br><see langword="false"/>  - опрос портов производиться не будет, список генераторов будет сформирован из списка ранее найденных устройств  </br>
        /// <br>Если не удалось найти ни одного подключенного генератора, будет сформирован массив, состоящий из одной строки: "Генераторы не обнаружены"</br></value>
        /// <returns>Массив имён подключенных к компъютеру генераторов DS360 </returns>
        public static string[] FindAllDS360(bool needRefreshGeneratorsList = true)
        {
            if (generatorsList == null)
            {
                generatorsList = new List<string>();
            }
            if (needRefreshGeneratorsList)
            {
                generatorsList.Clear();
            }
            if (!needRefreshGeneratorsList)
            {
                return generatorsList.ToArray();
            }
            List<string> ports = ComPort.PortsNamesList;
            if (ports == null)
            {
                generatorsList.Clear();
            }
            if (ports != null)
            {
                Task[] tasksPushGeneratorList = new Task[ports.Count];
                int taskNum;
                for (int i = 0; i < ports.Count; i++)
                {
                    taskNum = i;
                    string portName = ports[taskNum];
                    tasksPushGeneratorList[taskNum] = Task.Run(() => PushGeneratorsList(portName));
                }
                Task.WaitAll(tasksPushGeneratorList);
            }
            if (generatorsList.Count == 0)
            {
                generatorsList.Add("Генераторы не обнаружены");
            }
            return generatorsList.ToArray();
        }
        /// <summary>
        /// Производит поиск первого подключенного к компъютеру генератора DS360.
        /// </summary>
        /// <param name="needRefreshGeneratorsList">Необходимость опроса Com-портов.</param>
        /// <value><br><see langword="true"/> - будет произведён новый опрос портов.</br> 
        /// <br><see langword="false"/>  - опрос портов производиться не будет, поиск генераторов будет произведён в списке ранее найденных устройств  </br></value>
        /// <returns>Имя подключенного генератора (или строка "Генераторы не обнаружены" если не удалось найти ни один генератор)</returns>
        public static void SetFirstDS360AsDefault(bool needRefreshGeneratorsList = true)
        {
            if (generatorsList == null)
            {
                generatorsList = new List<string>();
            }
            if (needRefreshGeneratorsList) // М.б надо всегда обновлять?!
            {
                generatorsList.Clear();
            }
            string firstFoundGenerator = string.Empty;
            if (generatorsList.Count != 0)
            {
                if (generatorsList[0] != "NONE" && generatorsList[0] != "Генераторы не обнаружены")
                {
                    comPortDefaultName = generatorsList[0];
                }
            }
            List<string> ports = ComPort.PortsNamesList;
            if (ports == null)
            {
                generatorsList.Clear();
            }
            if (ports != null)
            {
                string portName = string.Empty;
                Task[] tasksPushDefaultGenerator = new Task[ports.Count];
                for (int i = 0; i < ports.Count; i++)
                {
                    portName = ports[i];
                    tasksPushDefaultGenerator[i] = new Task(() => PushDefaultGenerator(portName));
                }
                Task checkGeneratorDefault = Task.Run(() => CheckGeneratorDefault(tasksPushDefaultGenerator));
                checkGeneratorDefault.Wait();
            }
            if (IsComPortDefaultNameEmpty())
            {
                generatorsList.Add("Генераторы не обнаружены");
            }
            return;
        }
        /// <summary>
        /// Проверяет корректность введённых параметров сигнала
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешной проверке параметров сигнала</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при выходе параметров сигнала за допустимые пределы.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result CheckDS360Setting()
        {
            resultMessage = string.Empty;
            Result result = CheckFrequency();
            if (CheckVoltage() != Result.Success)
            {
                result = Result.ParamError;
            }
            if (!IsComPortDefaultName && !ComPort.IsPortNameCorrect(ComPortName))
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

        /// <summary>
        /// Передаёт введённые параметры сигнала в генератор
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении параметров выходного сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки при передаче параметров сигнала.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result SendDS360Setting()
        {
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            int index = FindIndexInConnectedComPort(portName);
            if (index >= 0)
            {
                return SendSettingToConnectedComPort(portName);
            }
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return result;
            }
            result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОтсутствует связь с генератором";
                return result;
            }
            //ПОСЛЕ открытия порта нужна пауза!!!! 
            if (GetOutputEnableState(port) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка проверки состояния выходного сигнала";
                return Result.Failure;
            }
            if (SetPrimeryOutputSetting(port) != Result.Success)
            {
                return Result.Failure;
            }
            if (IsSignalPeriodical() && !IsTwoToneSignal())
            {
                result = SendDS360SettingForSingleSignale(port);
            }
            if (IsSignalPeriodical() && IsTwoToneSignal())
            {
                result = SendDS360SettingForTwoToneSignale(port);
            }
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка передачи параметра в генератор";
                return result;
            }
            if (SetOutputSignalEnable(port, outputEnableState) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка включения выходного сигнала";
                return Result.Failure;
            }
            resultMessage = "\nПараметры успешно переданы в генератор";
            ComPort.PortClose(port);
            return result;
        }
        public Result SendSettingToConnectedComPort(string portName)
        {
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return Result.ParamError;
            }
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            int index = FindIndexInConnectedComPortOrConnect(portName);
            if (index < 0)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClear(ConnectedCOMPort[index].Port);
            if (GetOutputEnableState(ConnectedCOMPort[index].Port) != Result.Success)
            {
                resultMessage = "\nОшибка проверки состояния выходного сигнала";
                return Result.Failure;
            }
            if (SetPrimeryOutputSetting(ConnectedCOMPort[index].Port) != Result.Success)
            {
                return Result.Failure;
            }
            if (IsSignalPeriodical() && !IsTwoToneSignal())
            {
                result = SendDS360SettingForSingleSignale(ConnectedCOMPort[index].Port);
            }
            if (IsSignalPeriodical() && IsTwoToneSignal())
            {
                result = SendDS360SettingForTwoToneSignale(ConnectedCOMPort[index].Port);
            }
            if (result != Result.Success)
            {
                resultMessage = "\nОшибка передачи параметра в генератор";
                return result;
            }
            if (SetOutputSignalEnable(ConnectedCOMPort[index].Port, outputEnableState) != Result.Success)
            {
                resultMessage = "\nОшибка включения выходного сигнала";
                return Result.Failure;
            }
            resultMessage = "\nПараметры успешно переданы в генератор";
            return result;
        }

        /// <summary>
        /// Переключает выходной сигнал генератора в состояние "ВКЛ./(ON)"
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении состояния выходного сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на включение.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result SetOutputSignalOn()
        {
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            int index = FindIndexInConnectedComPort(portName);
            if (index >= 0)
            {
                return SetOutputSignalOnToConnectedComPort(portName);
            }
            Result result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОтсутствует связь с генератором";
                return result;
            }
            ComPort.PortClear(port);
            if (SetOutputSignalEnable(port, true) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClose(port);
            return Result.Success;
        }
        public Result SetOutputSignalOnToConnectedComPort(string portName)
        {
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            int index = FindIndexInConnectedComPortOrConnect(portName);
            if (index < 0)
            {
                resultMessage = "\nОшибка подключения генератора";
                return Result.Failure;
            }
            ComPort.PortClear(ConnectedCOMPort[index].Port);
            if (SetOutputSignalEnable(ConnectedCOMPort[index].Port, true) != Result.Success)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            return Result.Success;
        }
        /// <summary>
        /// Переключает выходной сигнал генератора в состояние "ВЫКЛ./(OFF)"
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении состояния выходного сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на выключение.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result SetOutputSignalOff()
        {
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            int index = FindIndexInConnectedComPort(portName);
            if (index >= 0)
            {
                return SetOutputSignalOffToConnectedComPort(portName);
            }
            Result result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОтсутствует связь с генератором";
                return result;
            }
            ComPort.PortClear(port);
            if (SetOutputSignalEnable(port, false) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClose(port);
            return Result.Success;
        }
        public Result SetOutputSignalOffToConnectedComPort(string portName)
        {
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            int index = FindIndexInConnectedComPortOrConnect(portName);
            if (index < 0)
            {
                resultMessage = "\nОшибка подключения генератора";
                return Result.Failure;
            }
            ComPort.PortClear(ConnectedCOMPort[index].Port);
            if (SetOutputSignalEnable(ConnectedCOMPort[index].Port, false) != Result.Success)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            return Result.Success;
        }
        /// <summary>
        /// Изменяет напряжение выходного сигнала генератора на значение, установленное в поле <see cref="AmplitudeRMS"/>
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на изменение сигнала.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result ChangeAmplitudeRMS()
        {
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            int index = FindIndexInConnectedComPort(portName);
            if (index >= 0)
            {
                return ChangeAmplitudeRMSToConnectedComPort(portName);
            }
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return Result.ParamError;
            }
            result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОтсутствует связь с генератором";
                return result;
            }
            ComPort.PortClear(port);
            if (SendAmplitudeRMS(port) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClose(port);
            return Result.Success;
        }
        public Result ChangeAmplitudeRMSToConnectedComPort(string portName)
        {
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return Result.ParamError;
            }
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            int index = FindIndexInConnectedComPortOrConnect(portName);
            if (index < 0)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClear(ConnectedCOMPort[index].Port);
            if (SendAmplitudeRMS(ConnectedCOMPort[index].Port) != Result.Success)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            return Result.Success;
        }
        /// <summary>
        /// Изменяет частоту выходного сигнала генератора на значение, установленное в поле <see cref="AmplitudeRMS"/>
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на изменение сигнала.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result ChangeFrequency()
        {
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            int index = FindIndexInConnectedComPort(portName);
            if (index >= 0)
            {
                return ChangeFrequencyToConnectedComPort(portName);
            }
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return Result.ParamError;
            }
            result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОтсутствует связь с генератором";
                return result;
            }
            ComPort.PortClear(port);
            if (SendFrequency(port) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClose(port);
            return Result.Success;
        }
        public Result ChangeFrequencyToConnectedComPort(string portName)
        {
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return Result.ParamError;
            }
            if (!ComPort.IsPortNameCorrect(portName))
            {
                return Result.ParamError;
            }
            int index = FindIndexInConnectedComPortOrConnect(portName);
            if (index < 0)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            ComPort.PortClear(ConnectedCOMPort[index].Port);
            if (SendFrequency(ConnectedCOMPort[index].Port) != Result.Success)
            {
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            return Result.Success;
        }

        #endregion PublicMethods

        #region SetGeneratorsSetting
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
        private Result SendDS360SettingForSingleSignale(SerialPort port)
        {
            Result result = Result.Success;
            if (SendFunctionType(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи типа сигнала";
            }
            if (SendFrequency(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи частоты сигнала";
            }
            if (SendAmplitudeRMS(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи амплитуды сигнала";
            }
            if (SendOffset(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи смещения сигнала";
            }
            return result;
        }
        private Result SendDS360SettingForTwoToneSignale(SerialPort port)
        {
            Result result = Result.Success;
            if (SendFunctionType(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи типа сигнала";
            }
            if (SendTwoToneMode(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи режима двухтонального сигнала";
            }
            if (SendFrequencyToneA(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи частоты 1-го тона сигнала";
            }
            if (SendFrequencyToneB(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи частоты 2-го тона сигнала";
            }
            if (SendAmplitudeToneA(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи амплитуды 1-го тона сигнала";
            }
            if (SendAmplitudeToneB(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи амплитуды 2-го тона сигнала";
            }
            if (SendOffset(port) != Result.Success)
            {
                result = Result.Failure;
                resultMessage += "\nОшибка передачи смещения сигнала";
            }
            return result;
        }
        private Result SendFunctionType(SerialPort port)
        {
            Result result = Result.Failure;
            string value = string.Empty;
            if (FunctionType == FunctionType.Sine)
            {
                value = "0";
            }
            if (FunctionType == FunctionType.Square)
            {
                value = "1";
            }
            if (IsTwoToneSignal())
            {
                value = "4";
            }
            string command = "FUNC" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendTwoToneMode(SerialPort port)
        {
            Result result = Result.Failure;
            string value = string.Empty;
            if (FunctionType == FunctionType.SineSine)
            {
                value = "0";
            }
            if (FunctionType == FunctionType.SineSquare)
            {
                value = "1";
            }
            if (!IsTwoToneSignal())
            {
                return Result.ParamError;
            }
            string command = "TTMD" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendFrequency(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(Frequency, 6, 3);
            string command = "FREQ" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendFrequencyToneA(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(Frequency, 6, 3);
            string command = "TTAF" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendFrequencyToneB(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(FrequencyB, 6, 3);
            if (FunctionType == FunctionType.SineSquare)
            {
                value = AgRoundTostring(FrequencyB, 2, 3);
            }
            string command = "TTBF" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendAmplitudeRMS(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(AmplitudeRMS, 4, 6);
            value = CorrectErroInPhysicalGenerator(value); // Todo Учет ошибки в генераторе 
            string command = "AMPL" + value + "VR";
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private static string CorrectErroInPhysicalGenerator(string value)
        {
            double.TryParse(value.Replace(".", ","), out double num);
            if (errorList.Contains(num))
            {
                int charCount = value.Length;
                int powNum = (int)Math.Ceiling(Math.Log10(num));
                if ((charCount + powNum) < 6)
                {
                    return CorrectCharlCount(value, num);
                }
                char lastChar = value[value.Length - 1];
                int lastNum = int.Parse(lastChar.ToString());
                if (lastNum == 9)
                {
                    lastNum--;
                }
                else
                {
                    lastNum++;
                }
                value = value.Remove(value.Length - 1) + lastNum;
            }
            return value;
        }

        private static string CorrectCharlCount(string value, double num)
        {
            int charCount = value.Length;
            int powNum = (int)Math.Ceiling(Math.Log10(num));

            while ((charCount + powNum) < 5)
            {
                return CorrectCharlCount(value+"0", num);
            }
            return value + "1";
        }

        private Result SendAmplitudeToneA(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(AmplitudeRMS, 4, 6);
            string command = "TTAA" + value + "VR";
            result = SendOutputControlCommand(port, command);
            if (result != Result.Success)
            {
                Thread.Sleep(100);
                result = SendOutputControlCommand(port, command);
            }
            return result;
        }
        private Result SendAmplitudeToneB(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundTostring(AmplitudeRMSToneB, 4, 6);
            string command = "TTBA" + value + "VR";
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SendOffset(SerialPort port)
        {
            Result result = Result.Failure;
            string value = AgRoundOffsetTostring(); //TEST
            string command = "OFFS" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result GetOutputEnableState(SerialPort port)
        {
            Result result = Result.Failure;
            ComPort.PortClear(port);
            string query = "OUTE?";
            result = SendCommandToDS360(port, query);
            if (result != Result.Success)
            {
                return result;
            }
            string receivedValue = ReceiveMessageFromeDS360(port);
            outputEnableState = (receivedValue == "1") ? true : false;
            return result;
        }
        private Result SetOffsetToZero(SerialPort port)
        {
            Result result = Result.Failure;
            string value = "0"; //TEST
            string command = "OFFS" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SetPrimeryOutputSetting(SerialPort port)
        {
            ComPort.PortClear(port);
            if (SetOutputSignalEnable(port, false) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            if (SetModifyFunctionEnable(port, false) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            if (SetOutputType(port, outputType) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            if (SetOutputImpedance(port, outputImpedance) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            if (SetOffsetToZero(port) != Result.Success)
            {
                ComPort.PortClose(port);
                resultMessage = "\nОшибка связи с генератором";
                return Result.Failure;
            }
            return Result.Success;
        }
        private Result SetModifyFunctionEnable(SerialPort port, bool modifyFunctionEnable = false)
        {
            Result result = Result.Failure;
            string value = "1";
            if (modifyFunctionEnable == false)
            {
                value = "0";
            }
            string command = "MENA" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SetOutputSignalEnable(SerialPort port, bool outputEnable = true)
        {
            Result result = Result.Failure;
            string value = "1";
            if (outputEnable == false)
            {
                value = "0";
            }
            string command = "OUTE" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SetOutputType(SerialPort port, OutputType outputType)
        {
            Result result = Result.Failure;
            string value = "0";
            if (outputType == OutputType.Unbalanced)
            {
                value = "0";
            }
            string command = "OUTM" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        private Result SetOutputImpedance(SerialPort port, OutputImpedance outputImpedance)
        {
            Result result = Result.Failure;
            string value = "3";
            if (outputImpedance == OutputImpedance.HiZ)
            {
                value = "3";
            }
            string command = "TERM" + value;
            result = SendOutputControlCommand(port, command);
            return result;
        }
        #endregion SetGeneratorsSetting

        #region CommunicateWithDS360
        private Result SendOutputControlCommand(SerialPort port, string command)
        {
            Result result = Result.Failure;
            string value = command.Substring(4, command.Length - 4);
            string query = command.Substring(0, 4) + "?";
            if (query == "AMPL?" || query == "TTAA?" || query == "TTBA?")
            {
                query += "VR";
                value = value.Substring(0, value.Length - 2);
            }
            result = SendCommandToDS360(port, command);
            if (result != Result.Success)
            {
                return result;
            }
            result = SendCommandToDS360(port, query);
            if (result != Result.Success)
            {
                return result;
            }
            //Возможно нужен Таймаут!!!

            string receivedValue = ReceiveMessageFromeDS360(port);
            if (!CompareValues(receivedValue, value))
            {
                result = Result.Failure;
            }
            //test
            DebugCompareMissage(query, result, value, receivedValue);
            CountCalls++;
            //test
            return result;
        }
        private Result SendCommandToDS360(SerialPort port, string command)
        {
            Result result = Result.Failure;
            if (port == null || !port.IsOpen)
            {
                return Result.ParamError;
            }
            result = ComPort.Send(port, command);
            return result;
        }
        private string ReceiveMessageFromeDS360(SerialPort port)
        {
            if (port == null || !port.IsOpen)
            {
                return string.Empty;
            }
            string receivedMessage = ComPort.Receive(port);
            receivedMessage = receivedMessage.Substring(0, receivedMessage.Length - 1);
            return receivedMessage;
        }
        private static string GetSerialNumber(string identificationString)
        {
            string[] subString = identificationString.Split(',');
            string serialNumber = subString[2];
            return serialNumber;
        }
        private static string GetDS360IdentificationString(string comPortName)
        {
            string command = "*IDN?";
            Result result = ComPort.PortOpen(GeneratorModel.DS360, comPortName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                return string.Empty;
            }
            Thread.Sleep(300);
            //ComPort.PortClear(port);
            result = ComPort.Send(port, command);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                return string.Empty;
            }
            Thread.Sleep(300);
            string identificationString = ComPort.Receive(port);
            identificationString = identificationString.Substring(0, identificationString.Length - 1);
            ComPort.PortClose(port);
            return identificationString;
        }
        private static string GetDS360EIdentificationString(string comPortName)
        {
            string command = "*IDN?";
            Result result = ComPort.PortOpen(GeneratorModel.DS360Emulator, comPortName, out SerialPort port);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                return string.Empty;
            }
            Thread.Sleep(300);
            //ComPort.PortClear(port);
            result = ComPort.Send(port, command);
            if (result != Result.Success)
            {
                ComPort.PortClose(port);
                return string.Empty;
            }
            string identificationString = ComPort.Receive(port);
            identificationString = identificationString.Substring(0, identificationString.Length - 1);
            ComPort.PortClose(port);
            return identificationString;
        }
        private static void PushGeneratorsList(string portName) //Изменить имя
        {
            string deviceName = string.Empty;
            string identificationString = string.Empty;
            if (ConnectedCOMPort != null && ConnectedCOMPort.Count != 0)
            {
                int index = FindIndexInConnectedComPort(portName);
                if (index >= 0)
                {
                    deviceName = ConnectedCOMPort[index].DeviceInfo;
                    generatorsList.Add(deviceName);
                    return;
                }
            }
            identificationString = GetDS360IdentificationString(portName);
            if (IsItDS360(identificationString))
            {
                deviceName = $"{portName}: DS360, s/n{GetSerialNumber(identificationString)}";
                generatorsList.Add(deviceName);
                return;
            }

            //ForTest - Удалить в финальной версии
            /*
            identificationString = GetDS360EIdentificationString(portName);
            if (IsItDS360E(identificationString))
            {
                deviceName = $"{portName}: DS360E, s/n{GetSerialNumber(identificationString)}";
                generatorsList.Add(deviceName);
                return;
            }
            */
            //--ForTest
            //deviceName = $"{portName}: Unknown device";
            //generatorsList.Add(deviceName);
            return;
        }
        private static void PushDefaultGenerator(string portName)
        {
            if (ConnectedCOMPort != null && ConnectedCOMPort.Count > 0)
            {
                comPortDefaultName = ConnectedCOMPort[0].DeviceInfo;
                return;
            }
            string identificationString = string.Empty;
            identificationString = GetDS360IdentificationString(portName);
            if (IsItDS360(identificationString))
            {
                comPortDefaultName = $"{portName}: DS360, s/n{GetSerialNumber(identificationString)}";
                return;
            }
            if (!IsComPortDefaultNameEmpty())
            {
                return;
            }
            //TODO: Добавить остальные генераторы

            //ForTest - Удалить в финальной версии
            /*
            identificationString = GetDS360EIdentificationString(portName);
            if (IsItDS360E(identificationString))
            {
                comPortDefaultName = $"{portName}: DS360E, s/n{GetSerialNumber(identificationString)}";
                return;
            }
            */
            //--ForTest
            return;
        }
        private static bool IsComPortDefaultNameEmpty()
        {
            if (comPortDefaultName == null || comPortDefaultName == string.Empty)
            {
                return true;
            }
            if (comPortDefaultName == "NONE" || comPortDefaultName == "Генераторы не обнаружены")
            {
                return true;
            }
            return false;
        }
        private static void CheckGeneratorDefault(Task[] findTasks)
        {
            comPortDefaultName = "NONE";
            bool isAllTasksComleted;
            foreach (Task task in findTasks)
            {
                task.Start();
            }
            do
            {
                isAllTasksComleted = true;
                foreach (Task task in findTasks)
                {
                    if (task.Status != TaskStatus.RanToCompletion)
                    {
                        isAllTasksComleted = false;
                    }
                }
            }
            while (comPortDefaultName == "NONE" && !isAllTasksComleted);
            Task.WaitAll(findTasks);
        }
        #endregion CommunicateWithDS360

        #region SecondaryMethods
        private static int FindIndexInConnectedComPort(string portName)
        {
            if (ConnectedCOMPort == null)
            {
                ConnectedCOMPort = new List<ConnectedCOMPort>();
            }
            int index = -1;
            if (ConnectedCOMPort.Count != 0)
            {
                for (int i = 0; i < ConnectedCOMPort.Count; i++)
                {
                    if (ComPort.GetPortNumberFromPortName(ConnectedCOMPort[i].Port.PortName) == ComPort.GetPortNumberFromPortName(portName))
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        private int FindIndexInConnectedComPortOrConnect(string portName)
        {
            int index = FindIndexInConnectedComPort(portName);
            if (index == -1)
            {
                Result result = ConnectCOMPort(portName);
                if (result != Result.Success)
                {
                    resultMessage = "\nОтсутствует связь с генератором";
                    return index;
                }
                index = 0;
            }
            return index;
        }
        private static Result SetComPortDefaultName(string portName)
        {
            if (ComPort.IsPortNameCorrect(portName))
            {
                comPortDefaultName = portName;
                return Result.Success;
            }
            return Result.ParamError;
        }
        private static string GetComPortDefaultName()
        {
            if (comPortDefaultName == null || comPortDefaultName == string.Empty || comPortDefaultName == "Генераторы не обнаружены")
            {
                comPortDefaultName = "NONE";
            }
            return comPortDefaultName;
        }
        private void SetComPortNumber(int comPortNumber)
        {
            if (comPortNumber < 1 || comPortNumber > 256)
                return;
            this.comPortNumber = comPortNumber;
            this.comPortName = $"COM{comPortNumber}";
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
        private void DebugMessage(string str1, string str2)
        {
            if (isDebugMode)
            {
                MessageBox.Show(str1, str2, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void DebugCompareMissage(string query, Result result, string value, string receivedValue)
        {
            //test
            if (isDebugMode)
            {
                string paramName = query;
                string title = (result == Result.Success) ? "Успешно" : "Ошибка";
                string message = $"{paramName}\nSend: {value}\nReceive: {receivedValue}";
                DebugMessage(message, title);
            }
            //--test
        }
        private bool CompareValues(string value1, string value2)
        {
            if (!AgTryParse(value1, out double double1))
            {
                return false;
            }
            if (!AgTryParse(value2, out double double2))
            {
                return false;
            }
            if (double1 == double2)
            {
                return true;
            }
            return false;
        }
        private static bool AgTryParse(string stringValue, out double value)
        {
            if (double.TryParse(stringValue, out value))
            {
                return true;
            }
            stringValue = stringValue.Replace(".", decimalSeparator);
            if (double.TryParse(stringValue, out value))
            {
                return true;
            }
            return false;
        }
        private static string AgRoundTostring(double volume, int significantDigits, int maxDecimalPlaces)
        {
            if (volume == 0)
            {

            }
            string resultString = string.Empty;
            double dig = 0;
            if (volume != 0)
            {
                dig = Math.Ceiling(Math.Log10(volume));
            }
            double digits = Math.Pow(10, significantDigits - dig);
            double result = 0;
            if (digits != 0)
            {
                result = Math.Round(volume * digits) / digits;
            }
            int zeros = digits.ToString().Length - 1;
            if (digits > 1)
            {
                if (zeros > maxDecimalPlaces)
                {
                    resultString = result.ToString($"F{maxDecimalPlaces}");
                }
                if (zeros <= maxDecimalPlaces)
                {
                    resultString = result.ToString($"F{zeros}");
                }
            }
            if (digits <= 1)
            {
                resultString = Convert.ToString(result);
            }
            resultString = resultString.Replace(',', '.');
            return resultString;
        }
        private string AgRoundOffsetTostring()
        {
            string value = AgRoundTostring(Offset, 3, 5);
            double amplitudePik = GetPikSignal();
            string amplString = AgRoundTostring(amplitudePik, 4, 6);
            AgTryParse(amplString, out double amplitude);
            AgTryParse(value, out double offset);
            if (amplitude + Math.Abs(offset) > 0.01259)
            {
                value = AgRoundTostring(offset, 3, 4);
                AgTryParse(value, out offset);
            }
            if (amplitude + Math.Abs(offset) > 0.1259)
            {
                value = AgRoundTostring(offset, 3, 3);
                AgTryParse(value, out offset);
            }
            if (amplitude + Math.Abs(offset) > 1.259)
            {
                value = AgRoundTostring(offset, 3, 2);
                AgTryParse(value, out offset);
            }
            return value;
        }
        private static double AgRoundToDouble(double volume, int significantDigits, int maxDecimalPlaces)
        {
            string resultString = AgRoundTostring(volume, significantDigits, maxDecimalPlaces);
            resultString = resultString.Replace(',', '.');
            AgTryParse(resultString, out double result);
            return result;
        }
        private static bool IsItGenerator(string deviceModel)
        {
            if (deviceModel == "DS360" || deviceModel == "DS360-Emulator")
            {
                return true;
            }
            return false;
        }
        private static bool IsItDS360(string identificationString)
        {
            if (identificationString.StartsWith("StanfordResearchSystems,DS360,"))
            {
                return true;
            }
            return false;
        }
        private static bool IsItDS360E(string identificationString)
        {
            if (identificationString.StartsWith("StanfordResearchSystems,DS360E,"))
            {
                return true;
            }
            return false;
        }
        #endregion SecondaryMethods

        #region UnUsed

        /*
        public static string[] _FindAllDS360(bool needRefreshGeneratorsList = true) //Старая версия FindAllDS360()
        {
            if (generatorsList == null)
            {
                generatorsList = new List<string>();
            }
            if (needRefreshGeneratorsList)
            {
                generatorsList.Clear();
            }
            if (!needRefreshGeneratorsList)
            {
                return generatorsList.ToArray();
            }
            List<string> ports = ComPort.PortsNamesList;
            if (ports == null)
            {
                generatorsList.Clear();
            }
            if (ports != null)
            {
                Task[] tasksPushGeneratorList = new Task[ports.Count];
                int taskNum;
                for (int i = 0; i < ports.Count; i++)
                {
                    taskNum = i;
                    string portName = ports[taskNum];
                    tasksPushGeneratorList[taskNum] = Task.Run(() => PushGeneratorsList(portName));
                }
                Task.WaitAll(tasksPushGeneratorList);
            }
            if (generatorsList.Count == 0)
            {
                generatorsList.Add("Генераторы не обнаружены");
            }
            return generatorsList.ToArray();
        }
        */

        /*
        private void SetComPortNameToDefault()
        {
            ComPortName = ComPortDefaultName;
        }
        private static string[] GetDevicesArray()
        {
            List<string> ports = ComPort.PortsNamesList;
            string[] devices = new string[ports.Count];
            for (int i = 0; i < ports.Count; i++)
            {
                devices[i] = $"{ports[i]}: {ComPort.GetDeviceModel(ports[i])}";
            }
            return devices;
        }
        private static string[] GetComPortNameArray()
        {
            string[] portNames;
            try
            {
                portNames = SerialPort.GetPortNames();
            }
            catch (Win32Exception)
            {
                portNames = new string[] { "Com-порты не обнаружены" };
            }
            if (portNames == null || portNames.Length == 0)
            {
                portNames = new string[] { "Com-порты не обнаружены" };
            }
            return portNames;
        }
        private static string[] GetGeneratorsArray()
        {
            List<string> ports = ComPort.PortsNamesList;
            List<string> generatorsList = new List<string>();
            string deviceName = string.Empty;
            //

            for (int i = 0; i < ports.Count; i++)
            {
                deviceName = ComPort.GetDeviceModel(ports[i]);
                if (IsItGenerator(deviceName))
                {
                    //deviceName = $"{ports[i]}: {deviceName} s/n{GetSerialNumber(ports[i])}";
                    deviceName = $"{ports[i]}: {deviceName}";
                    generatorsList.Add(deviceName);
                }
            }
            if (generatorsList.Count == 0)
            {
                generatorsList.Add("Генераторы не обнаружены");
            }
            string[] generators = new string[generatorsList.Count];
            for (int i = 0; i < generatorsList.Count; i++)
            {
                generators[i] = generatorsList[i];
            }
            return generators;
        }
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
        private static List<string> GetComPortList()
        {
            List<string> portsNamesList = ComPort.PortsNamesList;
            return portsNamesList;
        }
        */
        /*
        private static string _GetSerialNumber(string portName)
        {
            string identificationString = GetDS360IdentificationString(portName);
            if (identificationString == string.Empty && identificationString == null)
            {
                return string.Empty;
            }
            string[] subString = identificationString.Split(',');
            string serialNumber = subString[2];
            return serialNumber;
        }*/
        #endregion UnUsed
    }
}
