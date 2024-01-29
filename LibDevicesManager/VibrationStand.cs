using Metrology;
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
        SetupProcess,
        None,
    }
    public class VibStendInfo
    {
        public VibroParametr ParametrToHold;
        public SignalParametrType Detector;
        public Frequency Frequency;
        public Sensitivity Sensitivity;
        public double CurrentVoltage;
        public VibStendStatus VibStendStatus = VibStendStatus.None;
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
            VibStendStatus = VibrationStand.VibStendStatus;

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
        public static event StatusStandChangeHandler StatusHasChanged;
        public static VibStendStatus VibStendStatus = VibStendStatus.None;

        public async Task<Result> RunStend()
        {
            _ = Task.Run(SetVibroParamInStend, TokenForTest);
            while (VibStendStatus == VibStendStatus.None ||
                VibStendStatus == VibStendStatus.SetupProcess)
            {
                await Task.Delay(100);
            }
            if (VibStendStatus == VibStendStatus.NotStably)
            {
                for (int i = 0; i < 3; i++)
                {
                    await Task.Delay(300);
                    if (VibStendStatus != VibStendStatus.NotStably)
                    {
                        break;
                    }
                }
            }
            IsSetupComplete = true;
            if (VibStendStatus == VibStendStatus.Stably)
            {
                return Result.Success;
            }
            return Result.Failure;
        }
        /// <summary>
        /// Метод в разработке (рефакторинг)
        /// </summary>
        private void SetVibroParamInStend() // todo отрефакторить
        {
            CancellLastVibrostendSetup();
            double voltToHold = GetVoltageFromVibroparam();
            double startVolt = 0.1;
            double currentVoltage = 0;
            double lastVoltage;
            double accuracyIndexToStart = 0.3;
            double indexToChange = 1.1;

            Generator.Frequency = Frequency.Get_Hz();
            Generator.AmplitudeRMS = startVolt;
            Multimeter.InputSignalMinFrequency = (int)(Generator.Frequency/2);
            Multimeter.MeasureType = MeasureType.AC;
            Multimeter.PhysicalParameter = PhysicalParameter.U;
            Multimeter.SendSetting();

            if (Generator.SendSetting() != Result.Success)
            {
                HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
                IsTesting = false;
                IsSetupComplete = false;
                return;
            }
            if (Generator.SetOutputOn() != Result.Success) 
            {
                HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
                IsTesting = false;
                IsSetupComplete = false;
                return;
            }
            Thread.Sleep(2000);

            if (Multimeter.Measure(out currentVoltage,3) != Result.Success)
            {
                HandleVibStendStatus(-1, VibStendStatus.MultimeterProblem);
                IsTesting = false;
                IsSetupComplete = false;
                return;
            }
            //Generator.AmplitudeRMS = indexToChange * startVolt;

            //if (Generator.ChangeAmplitudeRMS() != Result.Success)
            //{
            //    HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
            //    IsTesting = false;
            //    IsSetupComplete = false;
            //    return;
            //}
            //Thread.Sleep(1000);


            //lastVoltage = currentVoltage;
            //if (Multimeter.Measure(out currentVoltage,3) != Result.Success)
            //{
            //    HandleVibStendStatus(-1, VibStendStatus.MultimeterProblem);
            //    IsTesting = false;
            //    IsSetupComplete = false;
            //    return;
            //}
            //if (!IsMeasureStable(currentVoltage, lastVoltage * indexToChange, accuracyIndexToStart))
            //{
            //    //установка не чувствительна к входному воздействию
            //    HandleVibStendStatus(currentVoltage, VibStendStatus.NotSensitive);
            //    IsTesting = false;
            //    IsSetupComplete = false;
            //    return;
            //}
            //lastVoltage = currentVoltage;
            Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS, 4) * voltToHold / currentVoltage;
            if (Generator.ChangeAmplitudeRMS() != Result.Success)
            {
                HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
                IsTesting = false;
                IsSetupComplete = false;
                return;
            }
            Thread.Sleep(2000);
            while (IsTokenCancelAndServiceCancel() == TokenStatus.InWork)
            {
                if (Multimeter.Measure(out currentVoltage,3) != Result.Success)
                {
                    HandleVibStendStatus(-1, VibStendStatus.MultimeterProblem);
                    IsTesting = false;
                    IsSetupComplete = false;
                    return;
                }

                if (!IsMeasureStable(currentVoltage, voltToHold, Accuracy))
                {
                    if (!IsMeasureStable(currentVoltage, voltToHold, 0.3))
                    {
                        HandleVibStendStatus(currentVoltage, VibStendStatus.NotSensitive);
                        IsTesting = false;
                        IsSetupComplete = false;
                        return;
                    }
                    if (!IsMeasureStable(currentVoltage, voltToHold, 0.1))
                    {
                        HandleVibStendStatus(currentVoltage, VibStendStatus.NotStably);
                    }
                    else
                    {
                        VibStendStatus = VibStendStatus.Correction;
                        StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
                    }

                    Result result = Result.Failure;
                    //todo проверить адекватность
                    Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS,4) * voltToHold / currentVoltage;
                    for (int i = 0; i < 3; i++)
                    {
                        result = Generator.ChangeAmplitudeRMS();
                        if (result == Result.Success)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    if (result != Result.Success)
                    {
                        HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
                        IsTesting = false;
                        IsSetupComplete = false;
                        return;
                    }
                    Thread.Sleep(500);
                    lastVoltage = currentVoltage;
                }
                else
                {
                    VibStendStatus = VibStendStatus.Stably;
                    StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
                    Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS,4) * voltToHold / currentVoltage;
                    Result result = Result.Failure;
                    //todo проверить адекватность
                    
                    for (int i = 0; i < 3; i++)
                    {
                        result = Generator.ChangeAmplitudeRMS();
                        if (result == Result.Success)
                        {

                            break;
                        }
                        Thread.Sleep(1000);
                    }
                    if (result != Result.Success)
                    {
                        HandleVibStendStatus(currentVoltage, VibStendStatus.GeneratorProblem);
                        IsTesting = false;
                        IsSetupComplete = false;
                        return;
                    }
                    Thread.Sleep(500);
                }
            }
            IsTesting = false;
            IsSetupComplete = false;
            VibStendStatus = VibStendStatus.Finished;
            StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));
        }

        private double GetVoltageFromVibroparam()
        {
            VibroCalc.Sensitivity.Set_mV_MS2(Sensitivity.Get_mV_MS2());
            VibroCalc.Frequency.Set_Hz(Frequency.Get_Hz());
            if (VibroParametr is Acceleration)
                VibroCalc.CalcAll((Acceleration)VibroParametr.CloneObj());
            if (VibroParametr is Velocity)
                VibroCalc.CalcAll((Velocity)VibroParametr.CloneObj());
            if (VibroParametr is Displacement)
                VibroCalc.CalcAll((Displacement)VibroParametr.CloneObj());

            double voltToHold = VibroCalc.Voltage.GetRMS() / 1000;
            return voltToHold;
        }

        private void CancellLastVibrostendSetup()
        {
            VibStendStatus = VibStendStatus.SetupProcess;
            StatusHasChanged.Invoke(new VibStendInfo(this, -1));
            Generator.SetOutputOff();
            StopTest();
            while (IsTesting)
            {
                VibStendStatus = VibStendStatus.Stoping;
                StatusHasChanged.Invoke(new VibStendInfo(this, 0));
                Thread.Sleep(300);
            }
            IsTesting = true;
            CancelTokenSourceForTest.Dispose();
            CancelTokenSourceForTest = new CancellationTokenSource();
            TokenForTest = CancelTokenSourceForTest.Token;
        }

        static public void StopTest()
        {
            CancelTokenSourceForTest.Cancel();
        }

        private static bool IsMeasureStable(double newResult, double lastResult, double accuracyIndex)
        {
            double toHoldMin = lastResult * (1 - accuracyIndex);
            double toHoldMax = lastResult * (1 - accuracyIndex);
            bool isMasure = newResult > lastResult * (1 - accuracyIndex) && newResult < lastResult * (1 + accuracyIndex);
            return isMasure;
        }
        private void HandleVibStendStatus(double currentVoltage, VibStendStatus status)
        {
            VibStendStatus = status;
            StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage));

            CancelTokenSourceForTest.Dispose();
            CancelTokenSourceForTest = new CancellationTokenSource();
            TokenForTest = CancelTokenSourceForTest.Token;

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
