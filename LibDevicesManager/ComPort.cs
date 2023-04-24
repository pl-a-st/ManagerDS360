using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LibDevicesManager
{
    public enum Result
    {
        Success, Failure, Exception, ParamError, AcsessError
    }
    public static class ComPort
    {
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
                if (port == "COM1111") //ToDEL
                {
                    devicesNameList.Add("NONE");
                    continue;
                }
                // /*
                result = IsComPortDS360Emulator(port);
                if (result == Result.Success)
                {
                    devicesNameList.Add("DS360-Emulator");
                    continue;
                }
                //*/
                result = IsComPortDS360(port);
                if (result == Result.Success)
                {
                    devicesNameList.Add("DS360");
                    continue;
                }


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
        private static Result Send(SerialPort port, string message)
        {
            if (message == null)
            {
                return Result.ParamError;
            }
            if (port != null && port.IsOpen)
            {
                Thread.Sleep(100);
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
        private static string Receive(SerialPort port)
        {
            string receivedMessage = string.Empty;
            if (port != null && port.IsOpen)
            {
                Thread.Sleep(100);
                try
                {
                    receivedMessage = port.ReadLine();
                    //receivedMessage = port.ReadExisting();
                }
                catch (TimeoutException ex)
                {
                    //ExceptionMessage = "Ошибка времени получения пакета. " + ex.Message;
                    return "Ошибка времени получения пакета";
                }
            }
            return receivedMessage;
        }
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
        public static void TestARD(SerialPort port) //ToDEL
        {
            SetupPortDS360Emulator(port);
            port.Open();
            Send(port, "151");
            string message = Receive(port);
            Console.WriteLine(message);
        }
        private static Result SetupPortDS360(SerialPort port)
        {
            try
            {
                port.BaudRate = 9600;
                port.Parity = Parity.None;
                port.StopBits = StopBits.Two;
                port.DtrEnable = true;
                port.ReadTimeout = 100;
                port.WriteTimeout = 100;
                return Result.Success;
            }
            catch (IOException ex)
            {
                return Result.Exception;
            }
        }

        private static Result SetupPortDS360Emulator(SerialPort port)
        {
            try
            {
                port.BaudRate = 9600;
                //port.Parity = Parity.None;
                //port.StopBits = StopBits.One;
                //port.DtrEnable = true;
                port.ReadTimeout = 100;
                port.WriteTimeout = 100;
                return Result.Success;
            }
            catch (IOException ex)
            {
                return Result.Exception;
            }
        }
        private static Result IsComPortDS360(string portName)
        {
            Result result = Result.Success;
            if (portName == null || portName == string.Empty || !portName.StartsWith("COM"))
            {
                return Result.ParamError;
            }
            SerialPort port = new SerialPort(portName);
            if (SetupPortDS360(port) != Result.Success)
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
            if (result != Result.Success)
            {
                port.Dispose();
                return result;
            }
            result = Send(port, "*IDN?");
            if (result == Result.Success)
            {
                string receivedMessage = Receive(port);
                Console.WriteLine(receivedMessage);
                if (!receivedMessage.Contains("DS360"))
                {
                    result = Result.Failure;
                }
            }
            try
            {
                port.Close();
            }
            catch (IOException ex) { } //ToNEXT: возможно надо обработать
            return result;
        }
        private static Result IsComPortDS360Emulator(string portName)
        {

            Result result = Result.Success;
            if (portName == null || portName == string.Empty || !portName.StartsWith("COM"))
            {
                return Result.ParamError;
            }
            SerialPort port = new SerialPort(portName);
            //TestARD(port);
            result = SetupPortDS360Emulator(port);
            if (result != Result.Success)
            {
                return Result.Exception;
            }
            //Thread.Sleep(5000);
            //port.Open();
            ///*
            try
            {
                port.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
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
            if (result != Result.Success)
            {
                port.Dispose();
                return result;
            }
            //Thread.Sleep(100);
            //*/
            result = Send(port, "*IDN?");
            if (result == Result.Success)
            {
                //Thread.Sleep(100);
                string receivedMessage = Receive(port);
                Console.WriteLine(receivedMessage);             //ToDEL
                if (!receivedMessage.Contains("emu"))
                {
                    result = Result.Failure;
                    if (receivedMessage.Contains("Ошибка"))
                    {
                        result = Result.Exception;
                    }
                }
            }
            try
            {
                port.Close();
            }
            catch (IOException ex) //ToNEXT: возможно надо обработать
            {
                result = Result.Exception;
                port.Dispose();
            }
            return result;
        }
    }
}
