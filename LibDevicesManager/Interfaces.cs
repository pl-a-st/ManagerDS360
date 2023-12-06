﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
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
    public enum DeviceModel
    {
        DS360,
        DS360Emulator,
        Agilent33220A,
        Agilent3458A,
        Agilent34401A,
        Unknown
    }
    interface IDevice
    {
        DeviceType DeviceType { get; }
        DeviceModel DeviceModel { get; }
        Result Send(string command);
        string Receive();
    }
    interface IGenerator : IDevice
    {

    }
    interface IMultimeter : IDevice
    {

    }
}