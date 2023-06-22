using LibDevicesManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace LibControls
{
    [Serializable]
    public class DS360SettingVibroSigParam : DS360Setting
    {
        public SignalsParameter VibroParametr;
        public SignalParametrType SignalParametrTone1;
        public SignalParametrType SignalParametrTone2;
        public Sensitivity Sensitivity=new Sensitivity();
    }
    public static  class PmData
    {
        public static T CloneObj<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }

    }
}
