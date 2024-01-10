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
            string str=string.Empty;
            gpib.ReadString(out str);
            Console.WriteLine(str);


            string[] ports = GpibPort.GetPorts();
            if (ports != null)
            {
                foreach (string port in ports)
                {
                    Console.WriteLine(port);
                }
            }

            //<==ТЕСТОВАЯ ЧАСТЬ
            Console.ReadKey();
        }
    }
}
