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

        public static FrequencyResponse CurentFreqResp = new FrequencyResponse();
        public async Task<Result> RunStend()
        {

            VibStendStatus = VibStendStatus.SetupProcess;
            _ = Task.Run(SetVibroParamInStend, TokenForTest);

            await Task.Delay(1000); // todo попробовать заменить на while (VibStendStatus == VibStendStatus.Stably || VibStendStatus == VibStendStatus.Correction)
            while ((VibStendStatus == VibStendStatus.None ||
                VibStendStatus == VibStendStatus.SetupProcess ||
                VibStendStatus == VibStendStatus.Stoping ||
                VibStendStatus == VibStendStatus.Finished))
            {
                await Task.Delay(100);
            }
            if (VibStendStatus == VibStendStatus.NotStably || VibStendStatus == VibStendStatus.Correction)
            {
                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1500);
                    if (VibStendStatus != VibStendStatus.NotStably && VibStendStatus != VibStendStatus.Correction)
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
            //StopTest();
            return Result.Failure;
        }
        private bool CheckAndSetStatusesIfTrue(bool ToCheck, VibStendStatus vibStendStatus, double currentVoltage)
        {
            if (ToCheck)
            {
                HandleVibStendStatus(currentVoltage, vibStendStatus);
                IsTesting = false;
                IsSetupComplete = true;
            }
            return ToCheck;
        }
        private double GetStartVolt(double coeff)
        {
            if (Frequency.Get_Hz()<40)
            {
                return coeff / 12 / Math.PI / Frequency.Get_Hz() * 1000;
            }
            return coeff;
        }
        /// <summary>
        /// Метод в разработке (рефакторинг)
        /// </summary>
        private void SetVibroParamInStend() // todo отрефакторить
        {
            CancellLastVibrostendSetup();
            VibStendStatus = VibStendStatus.SetupProcess;
            StatusHasChanged.Invoke(new VibStendInfo(this, -1));
            double voltToHold = GetVoltageFromVibroparam()/CurentFreqResp.GetCoefficient(Frequency.Get_Hz());
            double startVolt = GetStartVolt(0.05);
            double currentVoltage = 0;
            double lastVoltage;

            Generator.Frequency = Frequency.Get_Hz();
            Generator.AmplitudeRMS = startVolt;

            Multimeter.InputSignalMinFrequency = Generator.Frequency;
            Multimeter.MeasureType = MeasureType.AC;
            Multimeter.PhysicalParameter = PhysicalParameter.U;

           
            if (CheckAndSetStatusesIfTrue(Generator.SendSetting() != Result.Success, VibStendStatus.GeneratorProblem, currentVoltage))
                return;
            if (CheckAndSetStatusesIfTrue(Generator.SetOutputOn() != Result.Success, VibStendStatus.GeneratorProblem, currentVoltage))
                return;
            if (CheckAndSetStatusesIfTrue(Multimeter.SendSetting() != Result.Success, VibStendStatus.MultimeterProblem, currentVoltage))
                return;

            for (int i = 0; i < 2; i++)
            {
                if (CheckAndSetStatusesIfTrue(Multimeter.Measure(out currentVoltage) != Result.Success, VibStendStatus.GeneratorProblem, currentVoltage))
                    return;
            }
          
            Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS, 4) * voltToHold / currentVoltage;
            if (CheckAndSetStatusesIfTrue(Generator.ChangeAmplitudeRMS() != Result.Success, VibStendStatus.GeneratorProblem, currentVoltage))
                return;
            Multimeter.Measure(out currentVoltage);

            while (IsTokenCancelAndServiceCancel() == TokenStatus.InWork)
            {
                    if (Multimeter.Measure(out currentVoltage) != Result.Success)
                    {
                        if (IsTokenCancelAndServiceCancel() != TokenStatus.InWork)
                            break;
                        HandleVibStendStatus(-1, VibStendStatus.MultimeterProblem);
                        IsTesting = false;
                        IsSetupComplete = false;
                        return;
                    }
                if (!IsMeasureStable(currentVoltage, voltToHold, Accuracy))
                {
                    if (IsTokenCancelAndServiceCancel() != TokenStatus.InWork)
                        break;
                    if (!IsMeasureStable(currentVoltage, voltToHold, 0.4))
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
                        StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage*CurentFreqResp.GetCoefficient(Frequency.Get_Hz())));
                    }

                    Result result = Result.Failure;
                    Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS, 4) * voltToHold / currentVoltage;
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
                        if (IsTokenCancelAndServiceCancel() != TokenStatus.InWork)
                            break;
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
                    if (IsTokenCancelAndServiceCancel() != TokenStatus.InWork)
                        break;
                    VibStendStatus = VibStendStatus.Stably;
                    StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage*CurentFreqResp.GetCoefficient(Frequency.Get_Hz())));
                    Generator.AmplitudeRMS = MetrologyRound.GetRounded(Generator.AmplitudeRMS, 4) * voltToHold / currentVoltage;
                    Result result = Result.Failure;

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
                        if (IsTokenCancelAndServiceCancel() != TokenStatus.InWork)
                            break;
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
            StatusHasChanged.Invoke(new VibStendInfo(this, currentVoltage*CurentFreqResp.GetCoefficient(Frequency.Get_Hz())));
            return;
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
            StatusHasChanged.Invoke(new VibStendInfo(this, 0));
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
            currentVoltage = currentVoltage * CurentFreqResp.GetCoefficient(Frequency.Get_Hz());
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
