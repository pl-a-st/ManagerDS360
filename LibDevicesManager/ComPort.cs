using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace LibDevicesManager
{
    public enum Result
    {
        Success, Failure, Exception, ParamError, AcsessError, Canceled
    }
    public enum DeviceType
    {
        Generator,
        Multimeter
    }
    public enum DeviceModel
    {
        DS360,
        DS360Emulator,
        Agilent33220A,
        Agilent3458A,
        Agilent34401A
    }
    public static class ComPort
    {
        private static int baudRate = 9600;
        private static Parity parity = Parity.None;
        private static StopBits stopBits = StopBits.Two;
        private static bool dtrEnable = true;
        private static int readTimeout = 100;
        private static int writeTimeout = 100;
        private static List<string> portsNamesList;
        private static List<string> devicesNameList;

        /// <summary>
        /// Возвращает лист имён последовательных портов для текущего компьютера.
        /// </summary>
        /// <returns>Лист имён последовательных портов для текущего компьютера или null </returns>

        public static List<string> PortsNamesList
        {
            get
            {
                portsNamesList = SetAllComPortList();
                return portsNamesList;
            }
        }
        public static bool IsPortNameCorrect(string portName)
        {
            if (portName == null || portName == string.Empty || !portName.StartsWith("COM"))
            {
                return false;
            }
            string number = string.Empty;
            char[] chars = portName.ToCharArray();
            int firstDigitPosition = 3;
            int lastDigitPosition = 5;
            if (lastDigitPosition > (chars.Length - 1))
            {
                lastDigitPosition = chars.Length - 1;
            }
            if (lastDigitPosition < firstDigitPosition)
            {
                return false;
            }
            for (int i = firstDigitPosition; i <= lastDigitPosition; i++)
            {
                if (char.IsDigit(chars[i]))
                {
                    number += chars[i];
                }
            }
            int.TryParse(number, out int num);
            if (num < 1 || num > 256)
            {
                return false;
            }
            return true;
        }
        private static List<string> SetAllComPortList()
        {
            if (portsNamesList == null)
            {
                portsNamesList = new List<string>();
            }
            portsNamesList.Clear();
            string[] ports;
            try { ports = SerialPort.GetPortNames(); }
            catch (Exception ex)
            {
                return portsNamesList; //ToNEXT: ? добавить первый член NONE
            }
            foreach (string port in ports)
            {
                portsNamesList.Add(port);
            }
            return portsNamesList;
        }
        public static void PortClear(SerialPort port) // AAS: Этот метод надо переписать!
        {
            if (port.IsOpen)
            {
                string checkString = string.Empty;
                do
                {
                    checkString = Receive(port);
                }
                while (!checkString.StartsWith("Ошибка"));
            }
        }
        public static Result PortOpen(DeviceModel deviceModel, string portName, out SerialPort port) //AAS: добавить поддержку моделей Agilent
        {
            Result result = Result.Success;
            port = new SerialPort();
            int portNumber = GetPortNumberFromPortName(portName);
            if (portNumber == 0)
            {
                return Result.ParamError;
            }
            string comPortName = "COM" + portNumber;
            port.PortName = comPortName;
            if (deviceModel == DeviceModel.DS360)
            {
                SetPortSettingForDS360();
            }
            if (deviceModel == DeviceModel.DS360Emulator)
            {
                SetPortSettingForDS360Emulator();
            }
            if (deviceModel == DeviceModel.Agilent33220A)
            {
                SetPortSettingForAgilent33220A();
            }
            if (deviceModel == DeviceModel.Agilent34401A)
            {
                SetPortSettingForAgilent34401A();
            }
            if (deviceModel == DeviceModel.Agilent3458A)
            {
                SetPortSettingForAgilent3458А();
            }
            result = SetupPort(port);
            if (result != Result.Success)
            {
                return Result.Exception;
            }
            try
            {
                port.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                result = Result.AcsessError;
            }
            catch (IOException ex)
            {
                result = Result.Exception;
            }
            catch (InvalidOperationException ex)
            {
                result = Result.Exception;
            }
            /*if (result == Result.Success)
            {
                while (!port.IsOpen)
                {
                    Thread.Sleep(30);
                }
            }*/
            //Thread.Sleep(300);
            return result;
        }
        public static Result PortClose(SerialPort port)
        {
            Result result = Result.Success;
            try
            {
                port.Close();
            }
            catch (IOException ex) //ToNEXT: возможно надо обработать
            {
                result = Result.Exception;
            }
            return result;
        }
        public static Result Send(SerialPort port, string message)
        {
            if (message == null)
            {
                return Result.ParamError;
            }
            if (port != null && port.IsOpen)
            {
                //Thread.Sleep(300);
                try
                {
                    port.WriteLine(message);
                    return Result.Success;
                }
                catch (TimeoutException ex)
                {
                    //Обработать ошибку передачи
                    //ExceptionMessage = "Ошибка времени отправки пакета. " + ex.Message;
                    return Result.Exception;
                }
            }
            return Result.AcsessError;
        }
        public static string Receive(SerialPort port)
        {
            string receivedMessage = string.Empty;
            if (port != null && port.IsOpen)
            {
                //Thread.Sleep(300);
                try
                {
                    receivedMessage = port.ReadLine();
                }
                catch (TimeoutException ex)
                {
                    //ExceptionMessage = "Ошибка времени получения пакета. " + ex.Message;
                    return "Ошибка времени получения пакета";
                }
                catch (InvalidOperationException ex)
                {
                    return "Ошибка InvalidOperationException";
                }
            }
            return receivedMessage;
        }
        private static Result SetupPort(SerialPort port)
        {
            try
            {
                port.BaudRate = baudRate;
                port.Parity = parity;
                port.StopBits = stopBits;
                port.DtrEnable = dtrEnable;
                port.ReadTimeout = readTimeout;
                port.WriteTimeout = writeTimeout;
                return Result.Success;
            }
            catch (IOException ex)
            {
                return Result.Exception;
            }
        }
        public static void SetPortSettingForDS360()
        {
            baudRate = 9600;
            parity = Parity.None;
            stopBits = StopBits.Two;
            dtrEnable = true;
            readTimeout = 100;
            writeTimeout = 100;
        }
        private static void SetPortSettingForDS360Emulator()
        {
            baudRate = 9600;
            parity = Parity.None;
            stopBits = StopBits.One;
            dtrEnable = false;
            readTimeout = 500;
            writeTimeout = 500;
        }
        private static void SetPortSettingForAgilent34401A() //AAS: дописать по документации 34401A
        {
            baudRate = 9600;
            /*
            parity = Parity.None;
            stopBits = StopBits.One;
            dtrEnable = false;
            readTimeout = 500;
            writeTimeout = 500;
            */
        }
        private static void SetPortSettingForAgilent3458А() //AAS: дописать по документации 3458А
        {
            baudRate = 9600;
            /*
            parity = Parity.None;
            stopBits = StopBits.One;
            dtrEnable = false;
            readTimeout = 500;
            writeTimeout = 500;
            */
        }
        private static void SetPortSettingForAgilent33220A() //AAS: дописать по документации 33220A
        {
            baudRate = 9600;
            /*
            parity = Parity.None;
            stopBits = StopBits.One;
            dtrEnable = false;
            readTimeout = 500;
            writeTimeout = 500;
            */
        }
        public static int GetPortNumberFromPortName(string portName)
        {
            int portNumber = 0;
            if (!IsPortNameCorrect(portName))
            {
                return portNumber;
            }
            int firstDigitPosition = 3;
            int numberDigits = 3;
            if (firstDigitPosition + numberDigits > (portName.Length - 1))
            {
                numberDigits = portName.Length - firstDigitPosition;
            }
            portName = portName.Substring(firstDigitPosition, numberDigits);
            while (!char.IsDigit(portName[portName.Length - 1]))
            {
                portName = portName.Substring(0, portName.Length - 1);
            }
            int.TryParse(portName, out portNumber);
            return portNumber;
        }

        #region UnUsed
        public static List<string> DevicesNamesList
        {
            get
            {
                devicesNameList = SetDevicesNamesList();
                return devicesNameList;
            }
        }
        private static List<string> GetAllGeneratorsPorts()
        {
            List<string> generators = new List<string>();
            for (int i = 0; i < PortsNamesList.Count; i++)
            {
                if (DevicesNamesList[i].Contains("DS360")) //ToNEXT: добавить другие генераторы
                {
                    generators.Add(PortsNamesList[i]);
                }
            }
            return generators;
        }
        private static List<string> SetDevicesNamesList() //
        {
            if (devicesNameList == null)
            {
                devicesNameList = new List<string>();
            }
            devicesNameList.Clear();
            Result result = new Result();
            List<string> ports = PortsNamesList;
            foreach (string port in ports)
            {
                /*
                result = IsComPortDS360Emulator(port);
                if (result == Result.Success)
                {
                    devicesNameList.Add("DS360-Emulator");
                    continue;
                }
                */
                /*
                result = IsComPortDS360(port);
                if (result == Result.Success)
                {
                    devicesNameList.Add("DS360");
                    continue;
                }
                */
                // ToNEXT: добавить другие известные устройства
                devicesNameList.Add("Unknoun");
            }
            return devicesNameList;
        }
        public static string GetDeviceModel(string portName)
        {
            Result result = new Result();
            result = IsComPortDS360Emulator(portName);
            if (result == Result.Success)
            {
                return "DS360-Emulator";
            }
            result = IsComPortDS360(portName);
            if (result == Result.Success)
            {
                return "DS360";
            }
            return "Unknown";
        }
        private static Result IsComPortDS360(string portName)
        {
            Result result = Result.Success;
            //SetPortSettingForDS360();
            result = PortOpen(DeviceModel.DS360, portName, out SerialPort port);
            if (result != Result.Success)
            {
                port.Dispose();
                return result;
            }
            result = Send(port, "*IDN?");
            if (result == Result.Success)
            {
                string receivedMessage = Receive(port);
                if (!receivedMessage.Contains("DS360"))
                {
                    PortClose(port);
                    result = Result.Failure;
                    return result;
                }
            }
            result = PortClose(port);
            return result;
        }
        private static Result IsComPortDS360Emulator(string portName)
        {
            Result result = Result.Success;
            //SetPortSettingForDS360Emulator();
            result = PortOpen(DeviceModel.DS360Emulator, portName, out SerialPort port);
            if (result != Result.Success)
            {
                port.Dispose();
                return result;
            }
            result = Send(port, "*IDN?");
            if (result == Result.Success)
            {
                string receivedMessage = Receive(port);
                if (!receivedMessage.Contains("emu"))
                {
                    PortClose(port);
                    result = Result.Failure;
                    return result;
                }
            }
            result = PortClose(port);
            return result;
        }
        #endregion UnUsed
    }
}
