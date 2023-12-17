using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace LibDevicesManager
{
    [Serializable]
    public class VibrationStand : Stend
    {
        public VibroParametr VibroParametr;
        public SignalParametrType Detector;
        public Frequency Frequency = new Frequency();
        public Sensitivity Sensitivity = new Sensitivity();
    }
}
