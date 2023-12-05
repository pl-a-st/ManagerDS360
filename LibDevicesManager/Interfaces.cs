using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    interface IDevice
    {
        DeviceType DeviceType { get; }
        DeviceModel DeviceModel { get; }
        Result Send();
        string Receive();
    }
    interface IGenerator : IDevice
    {
        
    }
    interface IMultimeter : IDevice
    {

    }
}
