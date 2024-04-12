using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LibDevicesManager;
using Ivi.Visa.Interop;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;

namespace ForLibDevicesTestOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FOR TEST ONLY");
            //ТЕСТОВАЯ ЧАСТЬ

            //проверка FindAllAgilent33220A
            /*
            List<string> devices = Agilent33220A.FindAllAgilent33220A();
            foreach (string device in devices)
            {
                Console.WriteLine(device);
            }

            string deviceInfo = "USB0: Agilent 33220A, s/nMY44031938";
            Console.WriteLine(Agilent33220A.GetSerialNumberFromDeviceInfo(deviceInfo));
            */

            //проверка разбиения строки
            /*
            string str = "USB0::0x0957::0x0407::MY44027128";
            string usb = string.Empty;
            string sn = string.Empty;
            Agilent33220A.GetDeviceInfo(str, out usb, out sn);
            Console.WriteLine($"{usb}:Agilent 33220A, s/n{sn}");
            */

            //Проверка VISA-IVI-USB
            /*
            ResourceManager rm = new ResourceManager();
            string[] resourses = rm.FindRsrc("?*");

            try
            {
                resourses = rm.FindRsrc("?*");
                Console.WriteLine("Ресурсы:");
                foreach (string r in resourses)
                {
                    Console.WriteLine(r);
                }
            }
            catch
            {
                Marshal.FinalReleaseComObject(rm);
            }
            finally
            {
                if (rm != null)
                {
                    Marshal.FinalReleaseComObject(rm);
                }
            }
            */
            /*
            Result result = Result.Failure;
            GpibPort device = new GpibPort("USB0::0x0957::0x0407::MY44031938");
            result = device.Send("*IDN?");
            if (result != Result.Success)
            {
                device.Close();
            }
            string response = string.Empty;
            result = device.ReadString(out response);
            if (result != Result.Success)
            {
                device.Close();
            }
            Console.WriteLine(response);
            result = device.Send("FREQ 700");
            device.Close();
            */
            //Проверка новых методов ConnectCOMPort() DisconnectCOMPort();
            /*
            DS360Setting[] generators = new DS360Setting[10];
            for (int i = 0; i <  generators.Length; i++)
            {
                generators[i] = new DS360Setting();
                generators[i].ComPortName = "COM4";
            }
            int countConnected = 0;
            foreach (DS360Setting generator in generators)
            {
                if (generator.ConnectCOMPort(generator.ComPortName) != Result.Success)
                {
                    Console.WriteLine($"Ошибка подключения к ComPort. Генератор {countConnected}");
                }
                countConnected++;
            }
            foreach (DS360Setting generator in generators)
            {
                if (generator.DisconnectCOMPort(generator.ComPortName) != Result.Success)
                {
                    Console.WriteLine($"Ошибка отключения от ComPort.  Генератор {countConnected}");
                }
                countConnected--;
            }
            */
            //Проверка DS360 (почему отваливается COM)
            /*
            string portName = "COM4";
            string command = "*IDN?";
            string response = string.Empty;
            SerialPort ds360 = new SerialPort();
            int steps = 0;
            ComPort.PortOpen(GeneratorModel.DS360, portName, out ds360);
            ds360.DiscardInBuffer();
            ds360.DiscardOutBuffer();
            Random rnd = new Random();
            for (int i = 0; true; i++)
            {

                if (ComPort.Send(ds360, command) != Result.Success)
                    break;

                Console.WriteLine(ComPort.Receive(ds360));
                double value = Math.Round((0.1 + 0.01 * rnd.Next(-5, 5)),8);
                string comand = ("AMPL" + value + "VR").Replace(",", ".");
                if (ComPort.Send(ds360, comand) != Result.Success)
                    break;
                if (ComPort.Send(ds360, "AMPL?VR") != Result.Success)
                    break;
                string result = ComPort.Receive(ds360).Replace(".", ",").Replace(@"\r", "");
                Console.WriteLine(result);
                double newValue = 0;
                double.TryParse(result, out newValue);
                if (newValue != value)
                    break;
                steps++;
                Thread.Sleep(60000);
            }
            ComPort.PortClose(ds360);
            Console.WriteLine($"Число шагов: {steps}");
            */

            //Проверка настроек мультиметра Agilent3458A
            /*
            Agilent3458A multimeter = new Agilent3458A();
           // multimeter.LowFrequencyLimit = 100;
            multimeter.MeasureType = MeasureType.DC;
            multimeter.PhysicalParameter = PhysicalParameter.U;
            multimeter.SendSetting();
            //multimeter.Send("ACBAND 20");
            multimeter.Send("NPLC?");
            multimeter.Receive(out string response);
            Console.WriteLine(response);
            Console.WriteLine("===");
            Console.ReadKey();
            multimeter.Send("NPLC 1");
            multimeter.Send("NPLC?");
            multimeter.Receive(out  response);
            Console.WriteLine(response);
            */
            /*
            Console.WriteLine("10 измерений:");
            double value = 0;
            for (int i = 0; i < 5; i++)
            {
                if (multimeter.Measure(out value) == Result.Success)
                {
                    Console.WriteLine(value);
                }
            }
            Console.WriteLine("Press any key to continue whis ACBAND = 1 Hz");
            Console.ReadKey();
            multimeter.Send("ACBAND 1, 2");
            multimeter.Send("ACBAND?");
            multimeter.Receive(out response);
            Console.WriteLine(response);
            Console.WriteLine("10 измерений:");
            multimeter.LowFrequencyLimit = 100;
            multimeter.SendSetting();
            for (int i = 0; i < 10; i++)
            {
                if (multimeter.Measure(out value) == Result.Success)
                {
                    Console.WriteLine(value);
                }
            }
            */
            //Проверка настроек мультиметра
            /*
            Multimeter multimeter = new Multimeter();
            Multimeter.MultimeterModel = MultimeterModel.Agilent3458A;
            //multimeter.Send("ACI");
            Console.WriteLine("continue whis NPLC = 0");
            multimeter.LowFrequencyLimit = 0;
            multimeter.PhysicalParameter = PhysicalParameter.U;
            multimeter.MeasureType = MeasureType.AC;
            multimeter.SendSetting();
            
            Console.WriteLine("Press any key to continue whis NPLC = 20");
            Console.ReadKey();
            multimeter.LowFrequencyLimit = 20;
            multimeter.SendSetting();
            Console.WriteLine("Press any key to continue whis NPLC = 100");
            Console.ReadKey();
            multimeter.LowFrequencyLimit = 100;
            multimeter.SendSetting();
            Console.WriteLine("Press any key to continue whis NPLC = 1000");
            Console.ReadKey();
            multimeter.LowFrequencyLimit = 1000;
            multimeter.SendSetting();
            */
            //Проверил как будет работать SerialPort в виде поля. Работает)
            /*
            SerialPort ds360 = new SerialPort();
            ComPort.SetPortSettingForDS360();
            ds360.PortName = "COM5";
            try
            {
                ds360.Open();
            }
            catch (UnauthorizedAccessException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            ds360.WriteLine("FREQ200");
            try
            {
                ds360.Close();
            }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }

            Console.WriteLine("Press any key to continue");
            //Console.ReadKey();
            ds360 = new SerialPort();
            ds360.PortName = "COM5";
            try
            {
                ds360.Open();
            }
            catch (UnauthorizedAccessException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            ds360.WriteLine("FREQ400");
            try
            {
                ds360.Close();
            }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            Console.WriteLine("Press any key to continue");
            //Console.ReadKey();
            ds360.PortName = "COM1";
            try
            {
                ds360.Open();
            }
            catch (UnauthorizedAccessException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            ds360.WriteLine("FREQ300");
            try
            {
                ds360.Close();
            }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            Console.WriteLine("Press any key to continue");
            //Console.ReadKey();
            ds360.PortName = "COM5";
            try
            {
                ds360.Open();
            }
            catch (UnauthorizedAccessException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            catch (InvalidOperationException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            ds360.WriteLine("FREQ500");
            try
            {
                ds360.Close();
            }
            catch (IOException ex) { Console.WriteLine("Ошибка" + ex.Message); }
            */
            //Проверка GPIB. Работает
            /*
            GpibPort gpib = new GpibPort();
            gpib.Send("ID?");
            string str = string.Empty;
            gpib.ReadString(out str);
            Console.WriteLine(str);
            List<string> ports = GpibPort.GetAllPorts();
            if (ports != null)
            {
                foreach (string port in ports)
                {
                    Console.WriteLine(port);
                }
            }
            gpib.Close();
            List<string> devices = Agilent3458A.FindAllAgilent3458A();
            foreach (string device in devices)
            {
                Console.WriteLine(device);
            }
            Multimeter multimeter = new Multimeter();
            string portName = string.Empty;
            Agilent3458A.FindFirstAgilent3458APort(out portName);
            Multimeter.PortName = portName;
            Multimeter.MultimeterModel = MultimeterModel.Agilent3458A;

            double value = 0;
            for (int i = 0; i < 10; i++)
            {
                if (multimeter.Measure(out value) == Result.Success)
                {
                    Console.WriteLine(value);
                }
            }
            */
            //Проверка DS360 через GPIB. Не работает((
            /*
            GpibPort aserial = new GpibPort("ASRL5");
            gpib.Send("IDN?");
            //str = string.Empty;
            gpib.ReadString(out str);
            Console.WriteLine(str);
            */
            //Тест ChangeAmplitudeRMS() и ChangeFrequency(). Работает
            /*
            DS360Setting dS360Setting = new DS360Setting();
            dS360Setting.ComPortName = "COM5";
            dS360Setting.IsComPortDefaultName = false;
            dS360Setting.SendDS360Setting();
            for (double i = 100; i < 2000; i += 100)
            {
                dS360Setting.Frequency = i;
                dS360Setting.ChangeFrequency();
            }
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            for (double i = 0.01; i < 0.1; i += 0.01)
            {
                dS360Setting.AmplitudeRMS = i;
                dS360Setting.ChangeAmplitudeRMS();
            }
            */


            //<==ТЕСТОВАЯ ЧАСТЬ

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }
    internal class Multimeter : Multimeter<Multimeter>
    {
        public Multimeter()
        {
            Agilent3458A.FindFirstAgilent3458APort(out string portName);
            Multimeter.PortName = portName;
        }
    }
}
