using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    [Serializable]
    public abstract class Generator <T> : IGenerator
    {
        public DeviceType DeviceType { get { return DeviceType.Generator; } }

        public static GeneratorModel GeneratorModel = GeneratorModel.Unknown;
        public FunctionType FunctionType { get { return functionType; } }
        public double AmplitudeRMS { get { return amplitudeRMS; } set { amplitudeRMS = value; } }
        public double Frequency { get { return frequency; } set { frequency = value; } }
        public double Offset { get { return offset; } set { offset = value; } }
        public OutputImpedance OutputImpedance { get { return OutputImpedance.HiZ; } }
        public static string Address = string.Empty;

        //private static GeneratorModel generatorModel = GeneratorModel.Unknown;
        private FunctionType functionType = FunctionType.Sine;
        //static private string address = string.Empty;
        private double amplitudeRMS = 0.1;
        private double frequency = 160;
        private double offset = 0;
        public Generator() { }

        #region PublicMethods
        public Result SendSetting()
        {
            return Result.Failure;
        }
        public Result SetOutputOff()
        {
            return Result.Failure;
        }
        public Result SetOutputOn()
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
        #endregion PublicMethods
    }
}
