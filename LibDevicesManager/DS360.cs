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
    public class DS360Setting
    {
        public static string ComPortDefault;
        public string ComPort { get; set; }
        public DeviceModel Model { get { return DeviceModel.DS360; } }
        public DeviceType DeviceType { get { return DeviceType.Generator; } }
        public FunctionType FunctionType { get; set; }
        public string SerialNumber { get; }
        public double Frequency { get; set; }
        public double AmplitudeRMS { get; set; }
        public double Offset { get; set; }




        public DS360Setting() { }
    }
}
