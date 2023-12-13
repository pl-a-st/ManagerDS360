using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    #region Enums
    public enum Result
    {
        Success, Failure, Exception, ParamError, AcsessError, Canceled
    }
    public enum DeviceType
    {
        Generator,
        Multimeter,
        Unknown
    }
    /*
    public enum DeviceModel
    {
        DS360,
        DS360Emulator,
        Agilent33220A,
        Agilent3458A,
        Agilent34401A,
        Unknown
    }
    */
    public enum GeneratorModel
    {
        DS360,
        DS360Emulator,
        Agilent33220A,
        Unknown
    }
    public enum MultimeterModel
    {
        Agilent3458A,
        Agilent34401A,
        Unknown
    }
    #endregion Enums
    interface IDevice
    {
        DeviceType DeviceType { get; }
        //MeasureType MeasureType { get; set; }

        Result Send(string command);
        string Receive();
    }
    interface IGenerator : IDevice
    {
        GeneratorModel GeneratorModel { get; }
    }
    interface IMultimeter : IDevice
    {
        MultimeterModel MultimeterModel { get; }
        MeasureType MeasureType { get; set; }
    }
}
