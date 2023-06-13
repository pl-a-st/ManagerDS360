using LibDevicesManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibroMath;

namespace ManagerDS360
{
    public static class PmData
    {
        public const string FileNameRouteAddresses = @"RouteAddresses.bin";

        public static Dictionary<PhysicalQuantity, string> PhysicalQuantity = new Dictionary<PhysicalQuantity, string>()
        {
            { ManagerDS360.PhysicalQuantity.U,"мВ"},
            { ManagerDS360.PhysicalQuantity.м_с2,@"м/c²"},
            { ManagerDS360.PhysicalQuantity.мм_с,@"мм/с" },
            { ManagerDS360.PhysicalQuantity.мкм,@"мкм" },
        };
        public static Dictionary<Detector, string> Detector = new Dictionary<Detector, string>()
        {
            { ManagerDS360.Detector.СКЗ,"СКЗ"},
            { ManagerDS360.Detector.Пик,"Пик"},
            { ManagerDS360.Detector.Пик_пик,"Пик-Пик"}
        };
        public static Dictionary<FunctionTypeSignal, string> FunctionTypeSignal = new Dictionary<FunctionTypeSignal, string>()
        {
            { ManagerDS360.FunctionTypeSignal.Синус,"Синус"},
            { ManagerDS360.FunctionTypeSignal.Квадрат,"Квадрат"},
            { ManagerDS360.FunctionTypeSignal.Синус_Синус,"Синус-Синус"},
            { ManagerDS360.FunctionTypeSignal.Синус_Квадрат,"Синус-Квадрат"},
        };

        public static List<FileInfo> RouteAddresses = new List<FileInfo>();

        static PmData()
        {
            RouteAddresses = DAO.binReadFileToObject(RouteAddresses, DAO.GetApplicationDataPath(FileNameRouteAddresses), out var result);
        }


        public static InputEnum GetEnumFromString<InputEnum>(Dictionary<InputEnum, string> dictionary, string str)
        {
            return dictionary.FirstOrDefault(x => x.Value == str).Key;
        }
    }
    
}
