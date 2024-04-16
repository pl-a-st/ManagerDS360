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
        public static List<ConnectedUSBPort> ConnectedUSBPort;
        private static List<string[]> resources = new List<string[]>();
        private static List<string> generators = new List<string>();

        public Agilent33220A()
        {
            Generator<Agilent33220A>.GeneratorModel = GeneratorModel.Agilent33220A;
        }
        public static List<string> FindAllAgilent33220A()
        {
            Result result = Result.Failure;
            List<string> usbPorts = new List<string>();
            //List<string> generators = new List<string>();
            usbPorts = GpibPort.GetUSBPorts();
            string response = string.Empty;
            const string rightRespons = "Agilent Technologies,33220A";
            const string rightRespons2 = "Agilent Technologies,33210A";
            string deviceInfo = string.Empty; // формат должен быть deviceName = $"{usbNumber}: Agilent 33220A, s/n{serialNumber}";
            //string usbNumber = string.Empty;
            //string serialNumber = string.Empty;
            generators.Clear();
            resources.Clear();
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
                    string[] resourceNameSplited = ConvertResourceNameToArray(usbPort);
                    deviceInfo = $"{resourceNameSplited[0]}: Agilent 33220A, s/n{resourceNameSplited[3]}";
                    generators.Add(deviceInfo);
                    resources.Add(resourceNameSplited);
                }
                if (response.Contains(rightRespons2))
                {
                    string[] resourceNameSplited = ConvertResourceNameToArray(usbPort);
                    deviceInfo = $"{resourceNameSplited[0]}: Agilent 33210A, s/n{resourceNameSplited[3]}";
                    generators.Add(deviceInfo);
                    resources.Add(resourceNameSplited);
                }
                device.Close();
            }
            return generators;
        }

        public static string GetSerialNumberFromDeviceInfo(string deviceInfo)
        {
            string sn = string.Empty;
            string substringMark = "s/n";
            int snStartPosition = deviceInfo.IndexOf(substringMark) + substringMark.Length;
            if (snStartPosition < 0)
            {
                return sn;
            }
            sn = deviceInfo.Substring(snStartPosition);
            return sn;
        }
        private static string GetSerialNumberFromResourceName(string resourceName)
        {
            return ConvertResourceNameToArray(resourceName)[3]; //TODO: обработать исключения
        }
        public static string[] ConvertResourceNameToArray(string resourceName) //TODO: добавить проверку корректности resourceName
        {
            string[] stringSeparator = { "::" };
            string[] str = resourceName.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);
            return str;
        }
        private static int FindIndexInConnectedUSBPort(string serialNumber)
        {
            int index = -1;
            if (ConnectedUSBPort == null)
            {
                //ConnectedUSBPort = new List<ConnectedUSBPort>();
                return index;
            }
            if (ConnectedUSBPort.Count != 0)
            {
                for (int i = 0; i < ConnectedUSBPort.Count; i++)
                {
                    if (GetSerialNumberFromDeviceInfo(ConnectedUSBPort[i].DeviceInfo) == serialNumber)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        private static int FindIndexInResources (string serialNumber)
        {
            int index = -1;
            string sn = string.Empty;
            if (resources.Count != 0)
            {
                for (int i = 0; i < resources.Count; i++)
                {
                    sn = resources[i][3];
                    if (sn == serialNumber)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
        public static void GetDeviceInfo(string resource, out string usbNumber, out string vendorId, out string productId, out string serialNumber)
        {
            usbNumber = string.Empty;
            serialNumber = string.Empty;
            vendorId = string.Empty;
            productId = string.Empty;
            string[] stringSeparator = { "::" };
            string[] str = resource.Split(stringSeparator, StringSplitOptions.RemoveEmptyEntries);
            usbNumber = str[0];
            vendorId = str[1];
            productId = str[2];
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
