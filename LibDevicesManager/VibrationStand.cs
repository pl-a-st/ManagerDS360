using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VibroMath;

namespace LibDevicesManager
{
    public enum TokenStatus
    {
        InWork,
        Canceled
    }

    public enum VibStendStatus
    {
        Stably,
        NotStably,
        NotSensitive,
        Correction,
        GeneratorProblem,
        MultimeterProblem,
        Stoping,
        Finished,
        None,
    }
    public class VibStendInfo
    {
        public VibroParametr ParametrToHold;
        public SignalParametrType Detector;
        public Frequency Frequency;
        public Sensitivity Sensitivity;
        public double CurrentVoltage;
        public VibStendStatus VibStendStatus;
        public VibroParametr CurrentParametr
        {
            get { return GetVibroParametr(); }
            private set { }
        }

        public VibStendInfo(VibrationStand stand, double currentVoltage)
        {
            ParametrToHold = stand.VibroParametr;
            Detector = stand.Detector;
            Frequency = stand.Frequency;
            Sensitivity = stand.Sensitivity;
            CurrentVoltage = currentVoltage;
            VibStendStatus = stand.VibStendStatus;

        }
        private VibroParametr GetVibroParametr()
        {
            VibroCalc.Frequency.Set_Hz(Frequency.Get_Hz());
            VibroCalc.Sensitivity.Set_mV_MS2(Sensitivity.Get_mV_MS2());
            VibroCalc.CalcAll(new Voltage(CurrentVoltage * 1000, SignalParametrType.RMS));
            if (ParametrToHold is Acceleration)
                return VibroCalc.Acceleration;
            if (ParametrToHold is Displacement)
                return VibroCalc.Displacement;
            if (ParametrToHold is Velocity)
                return VibroCalc.Velocity;
            return new Acceleration();

        }

    }
    [Serializable]
    public class VibrationStand : Stend
    {
        public VibroParametr VibroParametr;
        public SignalParametrType Detector;
        public Frequency Frequency = new Frequency();
        public Sensitivity Sensitivity = new Sensitivity();
        public static GeneratorForVibCalib Generator = new GeneratorForVibCalib();
        public static MultimeterForVibCalib Multimeter = new MultimeterForVibCalib();
        static CancellationTokenSource CancelTokenSourceForTest = new CancellationTokenSource();
        public static CancellationToken TokenForTest = CancelTokenSourceForTest.Token;
        public static bool IsTesting = false;
        public delegate void StatusStandChangeHandler(VibStendInfo info);
        public static  event StatusStandChangeHandler StatusHasChanged;
        public VibStendStatus VibStendStatus = VibStendStatus.None;
        
        public Result RunStend()
        {
            Task.Run(() => SetVibroParamInStend());
            while (VibStendStatus== VibStendStatus.None)
            {
                Task.Delay(300);
            }
            if(VibStendStatus == VibStendStatus.Stably)
            {
                return Result.Success;
            }
            return Result.Failure;
        }
        /// <summary>
        /// Метод в разработке (рефакторинг)
        /// </summary>
        public void SetVibroParamInStend() // todo отрефакторить
        {
            Generator.SetOutputOff();
            StopTest();

            // todo проверить остановку и остановить
            VibroCalc.Sensitivity.Set_mV_MS2(Sensitivity.Get_mV_MS2());
            VibroCalc.Frequency.Set_Hz(Frequency.Get_Hz());
            if (VibroParametr is Acceleration)
                VibroCalc.CalcAll((Acceleration)VibroParametr.CloneObj());
            if (VibroParametr is Velocity)
                VibroCalc.CalcAll((Velocity)VibroParametr.CloneObj());
            if (VibroParametr is Displacement)
                VibroCalc.CalcAll((Displacement)VibroParametr.CloneObj());

            Generator.Frequency = Frequency.Get_Hz();
            double voltToHold = VibroCalc.Voltage.GetRMS() / 1000;
            double startVolt = 0.1;
            double currentVoltage = 0;
            double lastVoltage;
            double accuracyIndexToStart = 0.3;
            double indexToChange = 1.5;

            Generator.AmplitudeRMS = startVolt;
            while (IsTesting)
            {
                VibStendStatus = VibStendStatus.Stoping;
                StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
                Task.Delay(300);
            }
            IsTesting = true;

            if (Generator.SendSetting() != Result.Success)
            {
                HandleVibStendProblem(currentVoltage, VibStendStatus.GeneratorProblem);
                return;
            }
            Generator.SetOutputOn();
            Task.Delay(300);

            if(Multimeter.Measure(out currentVoltage)!= Result.Success)
            {
                HandleVibStendProblem(-1, VibStendStatus.MultimeterProblem);
                return;
            }
            Generator.AmplitudeRMS = indexToChange * startVolt;
            if (Generator.SendSetting() != Result.Success)
            {
                HandleVibStendProblem(currentVoltage, VibStendStatus.GeneratorProblem);
                return;
            }
            Task.Delay(300);


            lastVoltage = currentVoltage;
            if (Multimeter.Measure(out currentVoltage) != Result.Success)
            {
                HandleVibStendProblem(-1, VibStendStatus.MultimeterProblem);
                return;
            }
            if (IsMeasureStable(currentVoltage, lastVoltage * indexToChange, accuracyIndexToStart))
            {
                //установка не чувствительна к входному воздействию
                HandleVibStendProblem(currentVoltage, VibStendStatus.NotSensitive);
                return;
            }
            lastVoltage = currentVoltage;

            while (IsTokenCancelAndServiceCancel() == TokenStatus.InWork) 
            {
                if (Multimeter.Measure(out currentVoltage) != Result.Success)
                {
                    HandleVibStendProblem(-1, VibStendStatus.MultimeterProblem);
                    return;
                }
                
                if (!IsMeasureStable(currentVoltage, lastVoltage, Accuracy))
                {
                    if (!IsMeasureStable(currentVoltage, lastVoltage, 0.1))
                    {
                        HandleVibStendProblem(currentVoltage, VibStendStatus.NotStably);
                    }
                    
                        //todo проверить адекватность
                        Generator.AmplitudeRMS = Generator.AmplitudeRMS * voltToHold / currentVoltage;
                    if (Generator.SendSetting() != Result.Success)
                    {
                        HandleVibStendProblem(currentVoltage, VibStendStatus.GeneratorProblem);
                        return;
                    }
                    Task.Delay(300);
                    lastVoltage = currentVoltage;
                }
                else
                {
                    VibStendStatus = VibStendStatus.Stably;
                    StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
                }
            }
            IsTesting = false;
            VibStendStatus = VibStendStatus.Finished;
        }
        static public void StopTest()
        {
            CancelTokenSourceForTest.Cancel();

        }

        private static bool IsMeasureStable(double newResult, double lastResult, double accuracyIndex)
        {
            return newResult < lastResult * (1 - accuracyIndex) || newResult > lastResult * (1 + accuracyIndex);
        }
        private void HandleVibStendProblem(double currentVoltage, VibStendStatus status)
        {
            VibStendStatus = status;
            StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
            try
            {
                Generator.SetOutputOff();
            }
            catch { }
            IsTesting = false;
        }
        private TokenStatus IsTokenCancelAndServiceCancel()
        {
            if (TokenForTest == null)
            {
                return TokenStatus.Canceled;
            }
            if (TokenForTest.IsCancellationRequested)
            {
                CancelTokenSourceForTest.Dispose();
                CancelTokenSourceForTest = new CancellationTokenSource();
                TokenForTest = CancelTokenSourceForTest.Token;
                return TokenStatus.Canceled;
            }
            return TokenStatus.InWork;
        }

    }
    public static class PmData
    {
        public static T CloneObj<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }

    }
}
