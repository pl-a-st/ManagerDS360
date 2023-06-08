﻿using System;
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
        Success, Failure, Exception, ParamError, AcsessError
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
        public static List<string> DevicesNamesList
        {
            get
            {
                devicesNameList = SetDevicesNamesList();
                return devicesNameList;
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
        private static List<string> SetDevicesNamesList()
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
        public static List<string> GetAllGeneratorsPorts()
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
        public static Result PortOpen(string portName, out SerialPort port)
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
                    return "InvalidOperationException";
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
        private static void SetupPortDS360()
        {
            baudRate = 9600;
            parity = Parity.None;
            stopBits = StopBits.Two;
            dtrEnable = true;
            readTimeout = 100;
            writeTimeout = 100;
        }
        private static void SetupPortDS360Emulator()
        {
            baudRate = 9600;
            parity = Parity.None;
            stopBits = StopBits.One;
            dtrEnable = false;
            readTimeout = 100;
            writeTimeout = 100;
        }
        private static Result IsComPortDS360(string portName)
        {
            Result result = Result.Success;
            SetupPortDS360();
            result = PortOpen(portName, out SerialPort port);
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
            SetupPortDS360Emulator();
            result = PortOpen(portName, out SerialPort port);
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
        /*
        private static Result _Send(SerialPort port, string message)
        {
            if (message == null)
            {
                return Result.ParamError;
            }
            if (port != null && port.IsOpen)
            {
                message += "\n";
                char[] chars = message.ToCharArray();
                try
                {
                    //port.WriteLine(message);
                    port.Write(chars, 0, chars.Length);
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
        */
        /*
        private static string _Receive(SerialPort port)
        {
            string receivedMessage = string.Empty;
            char charToRead;
            if (port != null && port.IsOpen)
            {
                try
                {
                    //receivedMessage = port.ReadLine();
                    //receivedMessage = port.ReadExisting();
                    while (port.BytesToRead> 0)
                    {
                        charToRead = (char)port.ReadChar();
                        if (charToRead == '\n')
                        {
                            return receivedMessage;
                        }
                        receivedMessage += charToRead;
                    }
                }
                catch (TimeoutException ex)
                {
                    //ExceptionMessage = "Ошибка времени получения пакета. " + ex.Message;
                    return "Ошибка времени получения пакета";
                }
            }
            return receivedMessage;
        }
        */
    }
}
