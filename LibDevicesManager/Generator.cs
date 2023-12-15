using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    [Serializable]
    public class Generator : IGenerator
    {
        public DeviceType DeviceType { get { return DeviceType.Generator; } }

        public GeneratorModel GeneratorModel { get { return generatorModel; } set { generatorModel = value; } }
        public FunctionType FunctionType { get { return FunctionType.Sine; } }
        public double AmplitudeRMS { get { return amplitudeRMS; } set { amplitudeRMS = value; } }
        public double Frequency { get { return frequency; } set { frequency = value; } }
        public double Offset { get { return offset; } set { offset = value; } }
        public OutputImpedance OutputImpedance { get { return OutputImpedance.HiZ; } }
        static public string Address { get { return address; } set { address = value; } }

        private GeneratorModel generatorModel = GeneratorModel.Unknown;
        static private string address = string.Empty;
        private double amplitudeRMS = 0.1;
        private double frequency = 160;
        private double offset = 0;
        public Generator() { }
        public Result SendSetting()
        {
            return Result.Failure;
        }
        public string Receive()
        {
            return "ЗАПОЛНИТЬ";
        }

        public Result Send(string command)
        {
            return Result.Failure;
        }
    }
}
