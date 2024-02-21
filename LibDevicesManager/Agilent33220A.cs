using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public class Agilent33220A : Generator<Agilent33220A>
    {
        public static GeneratorModel GeneratorModel { get; private set; }
        public static string Address
        {
            get { return GetAddress(); }
            set { SetAddress(value); }
        }
        public static List<string> ConnectedUSBPort; //?
        public Agilent33220A()
        {
            Generator<Agilent33220A>.GeneratorModel = GeneratorModel.Agilent33220A;
        }
        public List<string> FindAllAgilent33220A()
        {
            List<string> usbPorts = new List<string>();
            List<string> generators = new List<string>();
            usbPorts = GpibPort.GetUSBPorts();
            foreach (string usbPort in usbPorts)
            {

            }
            return generators;
        }
        public Result SendAgilent33220ASetting()
        {
            //TODO: Прописать метод
            return Result.Failure; 
        }
        private static string GetAddress()
        {
            return Generator<Agilent33220A>.Address;
        }

        private static void SetAddress(string address)
        {
            Generator<Agilent33220A>.Address = address; //TODO: вписать проверку корректности адреса
        }
    }
}
