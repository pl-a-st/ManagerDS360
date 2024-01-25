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

        public Result ConnectCOMPort(string portName)
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
                for (int i = 0; i < ConnectedCOMPort.Count; i++)
                {
                    if (ConnectedCOMPort[i].Port.PortName == portName) //TODO: добавить обрезку строк
                    {
                        ConnectedCOMPort[i].CountConnections++;
                        return Result.Success;
                    }
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
                    identificationString = ComPort.Receive(comPort.Port).Substring(0, identificationString.Length - 1);
                    if (IsItDS360(identificationString))
                    {
                        ConnectedCOMPort.Add(comPort);
                        ComPort.PortClear(comPort.Port);
                        return Result.Success;
                    }
                }
            }
            result = comPort.Close();
            //TODO: прописать Dispose?
            return Result.Failure;
        }
        public Result ConnectCOMPort(int portNumber)
        {
            string portName = $"COM{portNumber}";
            return ConnectCOMPort(portName);
        }
        public Result DisconnectCOMPort(string portName)
        {
            Result result = Result.Failure;
            if (ConnectedCOMPort != null && ConnectedCOMPort.Count != 0)
            {
                for (int i = 0; i < ConnectedCOMPort.Count; i++)
                {
                    if (ConnectedCOMPort[i].Port.PortName == portName) //TODO: добавить обрезку строк
                    {
                        result = ConnectedCOMPort[i].Close();
                        if (ConnectedCOMPort[i].CountConnections == 0)
                        {
                            ConnectedCOMPort.RemoveAt(i);
                            i--;
                        }
                        return result;
                    }
                }
            }
            return result;
        }
        public Result DisconnectCOMPort(int portNumber)
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
            Result result = CheckDS360Setting();
            if (result != Result.Success)
            {
                return result;
            }
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
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
        /// <summary>
        /// Переключает выходной сигнал генератора в состояние "ВКЛ./(ON)"
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении состояния выходного сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на включение.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result SetOutputSignalOn()
        {
            Result result = Result.Failure;
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
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
        /// <summary>
        /// Переключает выходной сигнал генератора в состояние "ВЫКЛ./(OFF)"
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении состояния выходного сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на выключение.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result SetOutputSignalOff()
        {
            Result result = Result.Failure;
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            result = ComPort.PortOpen(GeneratorModel, portName, out SerialPort port);
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
        /// <summary>
        /// Изменяет напряжение выходного сигнала генератора на значение, установленное в поле <see cref="AmplitudeRMS"/>
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на изменение сигнала.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result ChangeAmplitudeRMS()
        {
            Result result = Result.Failure;
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            if (CheckDS360Setting() != Result.Success)
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
        /// <summary>
        /// Изменяет частоту выходного сигнала генератора на значение, установленное в поле <see cref="AmplitudeRMS"/>
        /// </summary>
        /// <returns><br><see cref="Result.Success"/> при успешном изменении сигнала генератора</br>
        /// <br>или одно из оставшихся значений перечисления <see cref="Result"/> при возникновении ошибки во время передачи команды на изменение сигнала.</br>
        /// <br>При этом в поле <see cref="ResultMessage"/> будет записано подробное сообщение об ошибке.</br></returns>
        public Result ChangeFrequency()
        {
            Result result = Result.Failure;
            string portName = (IsComPortDefaultName) ? ComPortDefaultName : ComPortName;
            if (portName == "NONE")
            {
                resultMessage = "\nГенератор не найден";
                return Result.Failure;
            }
            if (CheckDS360Setting() != Result.Success)
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
            string command = "AMPL" + value + "VR";
            result = SendOutputControlCommand(port, command);
            return result;
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
            identificationString = GetDS360IdentificationString(portName);
            if (IsItDS360(identificationString))
            {
                deviceName = $"{portName}: DS360, s/n{GetSerialNumber(identificationString)}";
                generatorsList.Add(deviceName);

                return;
            }
            //ForTest - Удалить в финальной версии
            identificationString = GetDS360EIdentificationString(portName);
            if (IsItDS360E(identificationString))
            {
                deviceName = $"{portName}: DS360E, s/n{GetSerialNumber(identificationString)}";
                generatorsList.Add(deviceName);
                return;
            }
            //--ForTest
            //deviceName = $"{portName}: Unknown device";
            //generatorsList.Add(deviceName);
            return;
        }
        private static void PushDefaultGenerator(string portName)
        {
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
            identificationString = GetDS360EIdentificationString(portName);
            if (IsItDS360E(identificationString))
            {
                comPortDefaultName = $"{portName}: DS360E, s/n{GetSerialNumber(identificationString)}";
                return;
            }
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
