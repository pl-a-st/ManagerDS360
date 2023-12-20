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

        /// <summary>
        /// Метод в разработке
        /// </summary>
        public void Start() // todo это набросок метода 
        {
            Generator.SetOutputOff();
            StopTest();
           
            // todo проверить остановку и остановить
            VibroCalc.Sensitivity.Set_mV_MS2(Sensitivity.Get_mV_MS2());
            VibroCalc.Frequency.Set_Hz(Frequency.Get_Hz());
            if (VibroParametr is Acceleration)
                VibroCalc.CalcAll((Acceleration)VibroParametr);
            if (VibroParametr is Velocity)
                VibroCalc.CalcAll((Velocity)VibroParametr);
            if (VibroParametr is Displacement)
                VibroCalc.CalcAll((Displacement)VibroParametr);
            Generator.Frequency = Frequency.Get_Hz();
            double voltToHold = VibroCalc.Voltage.GetRMS()/1000;
            double startVolt = 0.1;
            double currentVoltage;
            double lastVoltage;
            double accuracyIndexToStart = 0.3;
            double indexToChange = 1.5;

            Generator.AmplitudeRMS = startVolt;
            while (IsTesting)
            {
                Task.Delay(300);
            }
            IsTesting = true;

            if (Generator.SendSetting() != Result.Success)
            {
                //ошбика генератора
                Generator.SetOutputOff();
                IsTesting = false;
                return;
            }
            Generator.SetOutputOn();
            Task.Delay(300);
            currentVoltage = Multimeter.Measure();
            Generator.AmplitudeRMS = indexToChange * startVolt;
            if (Generator.SendSetting() != Result.Success)
            {
                //ошбика генератора
                Generator.SetOutputOff();
                IsTesting = false;
                return;
            }
            Task.Delay(300);
            if (IsMeasureStable(Multimeter.Measure(), currentVoltage * indexToChange, accuracyIndexToStart))
            {
                //установка не чувствительна к входному воздействию
                Generator.SetOutputOff();
                IsTesting = false;
                return;
            }
            lastVoltage = currentVoltage;

            while (IsTokenCancelAndServiceCancel()== TokenStatus.InWork) // todo token
            {
                currentVoltage = Multimeter.Measure();
                if (!IsMeasureStable(currentVoltage, lastVoltage, Accuracy))
                {
                    //todo проверить адекватность
                    Generator.AmplitudeRMS = Generator.AmplitudeRMS * voltToHold / currentVoltage;
                    if (Generator.SendSetting() != Result.Success)
                    {
                        //ошбика генератора
                        Generator.SetOutputOff();
                        StopTest();
                        IsTesting = false;
                        return;
                    }
                    Task.Delay(300);
                    lastVoltage = currentVoltage;
                }
            }
            IsTesting = false;
        }
        static public void StopTest()
        {
            CancelTokenSourceForTest.Cancel();

        }
        private static bool IsMeasureStable(double newResult, double lastResult, double accuracyIndex)
        {
            return newResult < lastResult * (1 - accuracyIndex) || Multimeter.Measure() > lastResult * (1 + accuracyIndex);
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
}
