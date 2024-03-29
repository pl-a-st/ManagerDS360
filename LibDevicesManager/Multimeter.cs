﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDevicesManager
{
    public enum MeasureType
    {
        AC,
        DC
    }
    public enum PhysicalParameter
    {
        U,
        I
    }
    [Serializable]
    public abstract class Multimeter <T>: IMultimeter
    {
        /// <summary>
        /// Тип устройства
        /// </summary>
        /// <returns>одно из значений перечисления DeviceType </returns>
        public  DeviceType DeviceType { get { return DeviceType.Multimeter; } }

        public static MultimeterModel MultimeterModel { get { return multimeterModel; } set { multimeterModel = value; } }
        public static string PortName
        {
            get
            {
                return portName;
            }
            set
            {
                portName = value;
            }
        }

        public MeasureType MeasureType { get { return measureType; } set { measureType = value; } }
        public PhysicalParameter PhysicalParameter { get { return physicalParameter; } set { physicalParameter = value; } }
        /// <summary>
        /// Задаёт или возвращает минимальную частоту входного сигнала в Гц (влияет на скорость измерения).
        /// </summary>
        /// <returns>Минимальная частота входного сигнала в Гц</returns>
        /// <value>Допустимые значения от 1 Гц </value>
        public double InputSignalMinFrequency { get { return inputSignalMinFrequency; }  set {inputSignalMinFrequency = value; } }
        public double BandWhidthfrequencyLow { get { return bandWhidthfrequencyLow; } set { bandWhidthfrequencyLow = value; } }
        public double BandWhidthfrequencyHigh { get { return bandWhidthfrequencyHigh; } set { bandWhidthfrequencyHigh = value; } }

        private MeasureType measureType = MeasureType.AC;
        private PhysicalParameter physicalParameter = PhysicalParameter.U;
        private double inputSignalMinFrequency = 100;
        private double bandWhidthfrequencyLow = 1;
        private double bandWhidthfrequencyHigh = 2000000;



        private static MultimeterModel multimeterModel = MultimeterModel.Unknown;
        private static string portName = "NONE"; // todo зачем тут значение по умолчанию?
        public Multimeter() { }
        public virtual Result SendSetting()
        {
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                multimeter.PhysicalParameter = PhysicalParameter;
                multimeter.MeasureType = MeasureType;
                multimeter.InputSignalMinFrequency = InputSignalMinFrequency;
                return multimeter.SendSetting();
            }
                return Result.Failure;
        }
        public virtual Result Measure(out double value, int averages = 1)
        {
            value = 0;
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Measure(out value, averages);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                //TODO: прописать код
                return Result.Failure;
            }
            //TODO: прописать код
            return Result.Failure;
        }
        public virtual Result Receive(out string response)
        {
            response = string.Empty;
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Receive(out response);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                return Result.Failure; //TODO: Прописать код
            }
            return Result.Failure;
        }

        public virtual Result Send(string command)
        {
            if (multimeterModel == MultimeterModel.Agilent3458A)
            {
                Agilent3458A multimeter = new Agilent3458A(portName);
                return multimeter.Send(command);
            }
            if (multimeterModel == MultimeterModel.Agilent34401A)
            {
                return Result.Failure; //Прописать код
            }
            return Result.Failure;
        }
    }
}
