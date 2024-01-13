using LibDevicesManager;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VibroMath;

namespace ManagerDS360
{
    public enum TestedDevice
    {
        None,
        DC23
    }
    public enum Channel
    {
        ChannelFirst,
        ChannelSecond,
        ChannelFirstAndSecond
    }
    public enum SettingsType
    {
        Folder,
        DS360,
        DC23,
        AllDC23InRoute,
        VibroCalib,
        Message
    }
    public enum CallType
    {
        Create,
        Control,
        Change
    }

    public enum FunctionTypeSignal
    {
        Синус = FunctionType.Sine,
        Квадрат = FunctionType.Square,
        Синус_Синус = FunctionType.SineSine,
        Синус_Квадрат = FunctionType.SineSquare
    }
    public enum SaveStatus
    {
        Cancel,
        Save
    }

    public enum PhysicalQuantity
    {
        U,
        м_с2,
        мм_с,
        мкм,
    }
    public enum VibrationQuantity
    {
        м_с2 = PhysicalQuantity.м_с2,
        мм_с = PhysicalQuantity.мм_с,
        мкм = PhysicalQuantity.мкм,
    }
    public enum Detector
    {
        СКЗ = SignalParametrType.RMS,
        Пик = SignalParametrType.PIK,
        Пик_пик = SignalParametrType.PIK_PIK
    }

    /// <summary>
    /// Сортированный словарь реализуеющий АЧХ 
    /// где ключ - частота,
    /// занчение - коэффициент
    /// </summary>
    [Serializable]
    public class FrequencyResponse : SortedDictionary<double, double>
    {
        /// <summary>
        /// Добавляет или затирает коэффициент для указанной частоты в словаре
        /// </summary>
        /// <value><br><see langword="double"/></br> frequency: частота 
        /// <br><see langword="double"/></br> <see cref="coefficient"/>: коэффициент </value>
        /// <param name="frequency"></param>
        /// <param name="coefficient"></param>
        public new void Add(double frequency, double coefficient)
        {
            if (this.ContainsKey(frequency))
            {
                this[frequency] = coefficient;
            }
            else
            {
                base.Add(frequency, coefficient);
            }
        }
        /// <summary>
        /// Вычисляет аппроксимированный коэффициент для указанной частоты 
        /// </summary>
        /// <value><br><strong><see langword="double"/></strong></br> frequency: частота </value>
        /// <returns><br><strong><see langword="double"/></strong></br> коэффициент</returns>
        public double GetCoefficient(double frequency)
        {
            double coefficient = 1;
            if (this.TryGetValue(frequency, out coefficient))
            {
                return coefficient;
            }
            if (this.Count < 2)
            {
                return this.ElementAt(0).Value;
            }
            double x = frequency;
            double x1 = 0;
            double x2 = 0;
            double y1 = 0;
            double y2 = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (frequency > this.ElementAt(i).Key)
                {
                    continue;
                }
                if (i == 0)
                {
                    x1 = this.ElementAt(i).Key;
                    x2 = this.ElementAt(i + 1).Key;
                    y1 = this.ElementAt(i).Value;
                    y2 = this.ElementAt(i + 1).Value;
                    return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
                }
                x1 = this.ElementAt(i).Key;
                x2 = this.ElementAt(i - 1).Key;
                y1 = this.ElementAt(i).Value;
                y2 = this.ElementAt(i - 1).Value;
                return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
            }
            x1 = this.ElementAt(this.Count - 1).Key;
            x2 = this.ElementAt(this.Count - 1 - 1).Key;
            y1 = this.ElementAt(this.Count - 1).Value;
            y2 = this.ElementAt(this.Count - 1 - 1).Value;
            return y1 + (x - x1) * (y2 - y1) / (x2 - x1);
        }
    }
    public static class PmData
    {
        public const string FileNameRouteAddresses = @"RouteAddresses.bin";
        public const string FileNameFreqRespAddresses = @"FrequencyResponses.bin";
        public static Dictionary<SettingsType, string> SettingsType = new Dictionary<SettingsType, string>()
        {
            { ManagerDS360.SettingsType.Folder, "Папка"},
            { ManagerDS360.SettingsType.DS360,"DS360"},
            { ManagerDS360.SettingsType.DC23,"СД-23"},
            { ManagerDS360.SettingsType.AllDC23InRoute, "Все узлы маршрута"},
            { ManagerDS360.SettingsType.Message,"Сообщение"},
            { ManagerDS360.SettingsType.VibroCalib,"Вибростенд"},
        };
        public static Dictionary<Channel, string> Channel = new Dictionary<Channel, string>()
        {
            { ManagerDS360.Channel.ChannelFirst, "Канал А"},
            { ManagerDS360.Channel.ChannelSecond,"Канал В"},
            { ManagerDS360.Channel.ChannelFirstAndSecond,"Канала А и В"},
        };
        public static Dictionary<TestedDevice, string> TestedDevice = new Dictionary<TestedDevice, string>()
        {
            { ManagerDS360.TestedDevice.None,"Нет/отключить"},
            { ManagerDS360.TestedDevice.DC23,@"СД-23"},
        };
        public static Dictionary<PhysicalQuantity, string> PhysicalQuantity = new Dictionary<PhysicalQuantity, string>()
        {
            { ManagerDS360.PhysicalQuantity.U,"мВ"},
            { ManagerDS360.PhysicalQuantity.м_с2,@"м/c²"},
            { ManagerDS360.PhysicalQuantity.мм_с,@"мм/с" },
            { ManagerDS360.PhysicalQuantity.мкм,@"мкм" },
        };
        public static Dictionary<VibrationQuantity, string> VibrationQuantity = new Dictionary<VibrationQuantity, string>()
        {
            { ManagerDS360.VibrationQuantity.м_с2,@"м/c²"},
            { ManagerDS360.VibrationQuantity.мм_с,@"мм/с" },
            { ManagerDS360.VibrationQuantity.мкм,@"мкм" },
        };
        public static Dictionary<VibrationQuantity, VibroParametr> VibroParametr = new Dictionary<VibrationQuantity, VibroParametr>()
        {
            { ManagerDS360.VibrationQuantity.м_с2,new Acceleration()},
            { ManagerDS360.VibrationQuantity.мм_с,new Velocity()},
            { ManagerDS360.VibrationQuantity.мкм,new Displacement()},
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
        public static Dictionary<GeneratorModel, string> GeneratorModel = new Dictionary<GeneratorModel, string>()
        {
            { LibDevicesManager.GeneratorModel.DS360, "DS360" },
            //{ LibDevicesManager.GeneratorModel.Agilent33220A, "Agilent33220A" },
        };
        public static Dictionary<MultimeterModel, string> MultimeterModel = new Dictionary<MultimeterModel, string>()
        {
            { LibDevicesManager.MultimeterModel.Agilent3458A, "Agilent3458A" },
            //{ LibDevicesManager.MultimeterModel.Agilent34401A, "Agilent34401A" },
        };
        public static Dictionary<VibStendStatus, string> VibStendStatus = new Dictionary<VibStendStatus, string>()
        {
            { LibDevicesManager.VibStendStatus.Correction, "Коррекция"},
            { LibDevicesManager.VibStendStatus.GeneratorProblem, "Ошибка генератора"},
            { LibDevicesManager.VibStendStatus.MultimeterProblem, "Ошибка мультиметра"},
            { LibDevicesManager.VibStendStatus.NotSensitive, "Нет чуствительности"},
            { LibDevicesManager.VibStendStatus.NotStably, "Нестабильные показания"},
            { LibDevicesManager.VibStendStatus.Stably, "Корректно"},
            { LibDevicesManager.VibStendStatus.Stoping, "Остнов"},
            { LibDevicesManager.VibStendStatus.Finished, "Закончен"},
            { LibDevicesManager.VibStendStatus.None, "Не установлен"},
        };
        public static List<FileInfo> RouteAddresses = new List<FileInfo>();
        public static List<FileInfo> FreqRespAddresses = new List<FileInfo>();

        static PmData()
        {
            RouteAddresses = DAO.binReadFileToObject(RouteAddresses, DAO.GetApplicationRoutePath(FileNameRouteAddresses), out _);
            FreqRespAddresses = DAO.binReadFileToObject(FreqRespAddresses, DAO.GetApplicationRoutePath(FileNameFreqRespAddresses), out _);
        }

        static public void SaveRouteAddresses()
        {
            if (DAO.binWriteObjectToFile(RouteAddresses, DAO.GetApplicationRoutePath(FileNameRouteAddresses)) != MethodResultStatus.Ok)
            {
                MessageBox.Show("Произошла проблема с сохранением списка маршрутов");
            }
        }
        static public void SaveFreqRespAddresses()
        {
            if (DAO.binWriteObjectToFile(FreqRespAddresses, DAO.GetApplicationRoutePath(FileNameFreqRespAddresses)) != MethodResultStatus.Ok)
            {
                MessageBox.Show("Произошла проблема с сохранением списка маршрутов");
            }
        }
        public static InputEnum GetEnumFromString<InputEnum>(Dictionary<InputEnum, string> dictionary, string str)
        {
            return dictionary.FirstOrDefault(x => x.Value == str).Key;
        }
        public static InputEnum GetEnumFromVibroParam<InputEnum>(Dictionary<InputEnum, VibroParametr> dictionary, VibroParametr vibroparam)
        {
            return dictionary.FirstOrDefault(x => x.Value.GetType() == vibroparam.GetType()).Key;
        }
        public static T CloneObj<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }
    }

}
