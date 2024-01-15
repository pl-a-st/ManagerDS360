using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibDevicesManager;
using Ivi.Visa.Interop;

namespace ForLibDevicesTestOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FOR TEST ONLY");
            //ТЕСТОВАЯ ЧАСТЬ
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
            */

            /*
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            for (double i = 0.01; i < 0.1; i += 0.01)
            {
                dS360Setting.AmplitudeRMS = i;
                dS360Setting.ChangeAmplitudeRMS();
            }
            */

            /*
           GpibPort aserial = new GpibPort("ASRL5");
            gpib.Send("IDN?");
            //str = string.Empty;
            gpib.ReadString(out str);
            Console.WriteLine(str);
            */
            //<==ТЕСТОВАЯ ЧАСТЬ
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

    }
    internal class Multimeter : Multimeter<Multimeter>
    {
        public Multimeter() { }
    }
}
