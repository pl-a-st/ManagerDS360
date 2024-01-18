using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibDevicesManager;
using Ivi.Visa.Interop;
using System.IO.Ports;
using System.IO;

namespace ForLibDevicesTestOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FOR TEST ONLY");
            //ТЕСТОВАЯ ЧАСТЬ
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
