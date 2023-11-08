using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    interface IDevice
    {
        Result Send();
        string Address
        {
            get;
            set;
        }
    }
    
}
