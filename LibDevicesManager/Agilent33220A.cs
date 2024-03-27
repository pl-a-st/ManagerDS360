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
            Result result = Result.Failure;
            List<string> usbPorts = new List<string>();
            List<string> generators = new List<string>();
            usbPorts = GpibPort.GetUSBPorts();
            string response = string.Empty;
            const string rightRespons = "Agilent 33220A"; //Вписать отклик от Agilent 33220A
            string deviceInfo = string.Empty; // формат должен быть deviceName = $"{usbNumber}: Agilent 33220A, s/n{serialNumber}";
            string usbNumber = string.Empty;
            string serialNumber = string.Empty;
            foreach (string usbPort in usbPorts)
            {
                GpibPort device = new GpibPort(usbPort);
                result = device.Send("*IDN?");
                if (result != Result.Success)
                {
                    device.Close();
                    continue;
                }
                result = device.ReadString(out response);
                if (result != Result.Success)
                {
                    device.Close();
                    continue;
                }
                if (response.Contains(rightRespons))
                {
                    GetDeviceInfo(usbPort, out usbNumber, out serialNumber);
                    deviceInfo = $"{usbNumber}: Agilent 33220A, s/n{serialNumber}";
                    generators.Add(deviceInfo);
                }
            }
            return generators;
        }
        public static void GetDeviceInfo (string identificationString, out string usbNumber, out string serialNumber)
        {
            usbNumber = string.Empty;
            serialNumber = string.Empty;
            string[] stringSeparator = { "::" };
            string[] str = identificationString.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);
            usbNumber = str[0];
            serialNumber = str[3];
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
