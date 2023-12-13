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
        public DeviceType DeviceType {get { return DeviceType.Generator;}}

        public GeneratorModel GeneratorModel { get { return generatorModel; } set { generatorModel = value; } }
        private GeneratorModel generatorModel = GeneratorModel.Unknown;
        static public string Address { get { return address; } set { address = value; } }
        static private string address = string.Empty;

        public string Receive()
        {
            throw new NotImplementedException();
        }

        public Result Send(string command)
        {
            throw new NotImplementedException();
        }
    }
}
