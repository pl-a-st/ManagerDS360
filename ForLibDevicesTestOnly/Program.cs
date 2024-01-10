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
            ports = ComPort.SetAllComPortList();
            if (ports != null)
            {
                foreach (string port in ports)
                {
                    Console.WriteLine(port);
                }
            }
            List<string> devices = Agilent3458A.FindAllAgilent3458A();
            foreach (string device in devices)
            {
                Console.WriteLine(device);
            }
            Multimeter multimeter = new Multimeter();
            Multimeter.MultimeterModel = MultimeterModel.Agilent3458A;

            double value = 0;
            for (int i = 0; i < 10; i++)
            {
                if (multimeter.Measure(out value) == Result.Success)
                {
                    Console.WriteLine(value);
                }
            }


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
