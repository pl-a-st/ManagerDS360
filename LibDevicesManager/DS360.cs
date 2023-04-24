using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    enum DS360Errors
    {

    }
    public enum DeviceType
    {
        Generator
    }
    public enum DeviceModel
    {
        DS360, DS360Emulator, Agilent
    }
    public enum FunctionType
    {
        Sine, Square, WhiteNoise, PinkNoise, TwoTone
    }
    public enum ToneBFunctionType
    {
        Sine, Square
    }
    public class DS360Setting
    {
        public static string ComPortDefaultName {get; set;}
        public string ComPortName { get; set; }
        public DeviceModel Model { get { return DeviceModel.DS360; } }
        public DeviceType DeviceType { get { return DeviceType.Generator; } }
        public string SerialNumber { get; }
        public FunctionType FunctionType { get; set; }
        public double Frequency { get; set; }
        public double AmplitudeRMS { get; set; }
        public double Offset { get; set; }

        //
        private static string comPortDefault;


        //Конструкторы для SingleSignal
        public DS360Setting() { }
        public DS360Setting(double amplitudeRMS, double frequency) { }
        public DS360Setting(string portName, double amplitudeRMS, double frequency) { }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency) { }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency) { }
        public DS360Setting(double amplitudeRMS, double  frequency, double offset) { }
        public DS360Setting(string portName, double amplitudeRMS, double frequency, double offset) { }
        public DS360Setting(FunctionType functionType, double amplitudeRMS, double frequency, double offset) { }
        public DS360Setting(string portName, FunctionType functionType, double amplitudeRMS, double frequency, double offset) { }
        //Конструкторы для TwoTone
        public DS360Setting(double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B) { }
        public DS360Setting(double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B, ToneBFunctionType functionType) { }
        public DS360Setting(string portName, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B) { }
        public DS360Setting(string portName, double frequency_A, double amplitudeRMS_A, double frequency_B, double amplitudeRMS_B, ToneBFunctionType functionType) { }

        public void SetComPortAsDefault (string portName) { }
        public static List<string> GetComPortList()
        {
            List<string> portsNamesList = ComPort.PortsNamesList;
            return portsNamesList;
        }
        public static string[] GetDevicesArray()
        {
            List<string> ports = ComPort.PortsNamesList;
            string[] devices = new string[ports.Count];
            for (int i = 0; i < ports.Count; i++)
            {
                devices[i] = $"{ports[i]}: {ComPort.GetDeviceModel(ports[i])}";
            }
            return devices;
        }
    }
}
