using LibDevicesManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using VibroMath;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static ManagerDS360.frmCreationEditingRoute;
using System.IO.Ports;
using LibControls;
using ToolTip = System.Windows.Forms.ToolTip;

namespace ManagerDS360
{
   

    public partial class frmCreationVibroCalibSetting : Form
    {
        public CallType Type = CallType.Create;
        public VibrationQuantity VibrationQuantity;
        public Detector Detector;


        public double Voltage;
        public DS360SettingVibroSigParam DS360Setting = new DS360SettingVibroSigParam();
        public frmCreationVibroCalibSetting()
        {
            InitializeComponent();
        }

        public  async void frmCreationVibroCalibSetting_LoadAsync(object sender, EventArgs e)
        {
            await PushCboDetector();
            await PushCboSetValue();

        }
        internal async Task PushCboDetector()
        {
            await Task.Delay(10);
            cboDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;   
            cboDetector.Items.AddRange(PmData.Detector.Values.ToArray());
            cboDetector.SelectedItem = PmData.Detector[Detector.СКЗ];
            
        }

        ///// <summary>
        ///// добавление в комбобокс физ.величин
        ///// </summary>
        internal async Task PushCboSetValue()
        {
            await Task.Delay(10);
            var elements = PmData.VibrationQuantity.Values.ToArray();
            cboSetValue.BeginUpdate();
            cboSetValue.Items.AddRange(elements);
            cboSetValue.SelectedItem = PmData.VibrationQuantity[VibrationQuantity.м_с2];
            cboSetValue.EndUpdate();
        }
        private void butSave_Click_1(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            //if (CheckFormsParameters() != Result.Success)
            //{
            //    return;
            //}
            //SetDS360Setting();
            //if (DS360Setting.CheckDS360Setting() != Result.Success)
            //{
            //    MessageBox.Show(DS360Setting.ResultMessage, "Ошибка", MessageBoxButtons.OK,
            //    MessageBoxIcon.Warning,
            //    MessageBoxDefaultButton.Button1);
            //    return;
            //}
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void butSend_Click(object sender, EventArgs e)
        {

        }



        ////private void SetDS360Setting()
        ////{
        ////    DS360Setting = new DS360SettingVibroSigParam();
        ////    if (chcDefaultGenerator.Checked)
        ////    {
        ////        DS360Setting.IsComPortDefaultName = true;
        ////    }
        ////    if (!chcDefaultGenerator.Checked)
        ////    {
        ////        DS360Setting.IsComPortDefaultName = false;
        ////        DS360Setting.ComPortNumber = (int)numComName.Value;
        ////    }
        ////    DS360Setting.SignalParametrTone1 = (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDetector.Text);
        ////    DS360Setting.SignalParametrTone2 = (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDetector2.Text);
        ////    //ветка для двух тонов
        ////    if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Синус)
        ////    {
        ////        DS360Setting.FunctionType = FunctionType.SineSine;
        ////        DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
        ////        SetVibroCalclAndSetDS360VibroParam(txtValue.Text, cboDetector.Text, txtFrequency.Text);
        ////        DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
        ////        SetVibroCalclAndSetDS360VibroParam(txtValue2.Text, cboDetector2.Text, txtFrequency2.Text);
        ////        DS360Setting.AmplitudeRMSToneB = VibroCalc.Voltage.GetRMS();
        ////    }
        ////    if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Квадрат)
        ////    {
        ////        DS360Setting.FunctionType = FunctionType.SineSquare;
        ////        DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
        ////        SetVibroCalclAndSetDS360VibroParam(txtValue.Text, cboDetector.Text, txtFrequency.Text);
        ////        DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
        ////        SetVibroCalclAndSetDS360VibroParam(
        ////            GetValueToSquareToDetector(cboDetector2, txtValue2).ToString(),
        ////            cboDetector2.Text,
        ////            txtFrequency2.Text);
        ////        DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
        ////        DS360Setting.AmplitudeRMSToneB = VibroCalc.Voltage.GetRMS();
        ////    }
        ////    if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус)
        ////    {
        ////        DS360Setting.FunctionType = FunctionType.Sine;
        ////        SetVibroCalclAndSetDS360VibroParam(txtValue.Text, cboDetector.Text, txtFrequency.Text);
        ////        DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
        ////    }
        ////    if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Квадрат)
        ////    {
        ////        DS360Setting.FunctionType = FunctionType.Square;
        ////        SetVibroCalclAndSetDS360VibroParam(
        ////            GetValueToSquareToDetector(cboDetector, txtValue).ToString(),
        ////            PmData.Detector[Detector.СКЗ],
        ////            txtFrequency.Text);
        ////        DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
        ////    }

        ////    DS360Setting.Sensitivity.Set_mV_G(double.Parse(txtConversionFactor.Text));
        ////    DS360Setting.Frequency = double.Parse(txtFrequency.Text);
        ////    DS360Setting.Offset = double.Parse(txtOffset.Text);
        ////    DS360SettingConvert_mV_to_V();
        ////}

        //private void DS360SettingConvert_mV_to_V()
        //{
        //    DS360Setting.AmplitudeRMS /= 1000;
        //    DS360Setting.AmplitudeRMSToneB /= 1000;
        //    DS360Setting.Offset /= 1000;
        //}

        //private double GetValueToSquareToDetector(ComboBox cbo, TextBox txt)
        //{
        //    double value1 = double.Parse(txt.Text);
        //    if (PmData.GetEnumFromString(PmData.Detector, cbo.Text) == Detector.Пик_пик)
        //    {
        //        value1 = value1 / 2;
        //    }
        //    return value1;
        //}

        //internal void SetVibroCalclAndSetDS360VibroParam(string txtVal, string cboDet, string txtFreq)
        //{
        //    VibroCalc.Frequency.Set_Hz(double.Parse(txtFreq));
        //    VibroCalc.Sensitivity.Set_mV_G(double.Parse(txtConversionFactor.Text));

        //    if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мм_с)
        //    {
        //        Velocity velocity = new Velocity(double.Parse(txtVal), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet));
        //        VibroCalc.CalcAll(velocity);
        //        DS360Setting.VibroParametr = velocity;
        //    }
        //    if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мкм)
        //    {
        //        Displacement displacement = new Displacement(double.Parse(txtVal), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet));
        //        VibroCalc.CalcAll(displacement);
        //        DS360Setting.VibroParametr = displacement;
        //    }
        //    if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.м_с2)
        //    {
        //        Acceleration acceleration = new Acceleration(double.Parse(txtVal), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet));
        //        VibroCalc.CalcAll(acceleration);
        //        DS360Setting.VibroParametr = acceleration;
        //    }
        //    if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.U)
        //    {
        //        Voltage voltage = new Voltage(double.Parse(txtVal), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet));
        //        VibroCalc.CalcAll(voltage);
        //        DS360Setting.VibroParametr = voltage;
        //    }
        //}

        //private Result CheckFormsParameters()
        //{
        //    string message = string.Empty;
        //    Result result = Result.Success;
        //    if (!double.TryParse(txtValue.Text, out double amplitudeRMS_A))
        //    {
        //        message += "\nВведите значение 1";
        //        result = Result.Failure;
        //    }
        //    if (!double.TryParse(txtFrequency.Text, out double frequency_A))
        //    {
        //        message += "\nВведите частоту 1";
        //        result = Result.Failure;
        //    }
        //    if (IsTwoTone() && !double.TryParse(txtValue2.Text, out double amplitudeRMS_B))
        //    {
        //        message += "\nВведите значение 2.";
        //        result = Result.Failure;
        //    }
        //    if (IsTwoTone() && !double.TryParse(txtFrequency2.Text, out double frequency_B))
        //    {
        //        message += "\nВведите частоту 2.";
        //        result = Result.Failure;
        //    }
        //    if (!IsTwoTone() && !double.TryParse(txtOffset.Text, out double offset))
        //    {
        //        message += "\nВведите значение смещения.";
        //        result = Result.Failure;
        //    }
        //    if (!double.TryParse(txtConversionFactor.Text, out double conversionFactor))
        //    {
        //        message += "\nВведите значение коэффициента.";
        //        result = Result.Failure;
        //    }
        //    if (result != Result.Success)
        //    {
        //        MessageBox.Show(message);
        //    }
        //    return result;
        //}

        //internal bool IsTwoTone()
        //{
        //    return PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Синус
        //        | PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Квадрат;
        //}

        //internal static void NewMethod(frmCreationEditingSettings editingSettings)
        //{
        //}

        //private void chcDefaultGenerator_CheckedChanged(object sender, EventArgs e)
        //{
        //    //галочка, чтобы взять генератор по умолч. 
        //    if (chcDefaultGenerator.Checked == false)
        //    {
        //        numComName.Enabled = true;
        //    }
        //    if (chcDefaultGenerator.Checked == true)
        //    {
        //        numComName.Enabled = false;
        //    }
        //}

        //private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        //internal void cboTypeSignal_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string strSinSin = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус_Синус];
        //    string strSinSquare = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус_Квадрат];
        //    string strSin = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус];
        //    string strSquare = PmData.FunctionTypeSignal[FunctionTypeSignal.Квадрат];
        //    if (cboTypeSignal.Text == strSinSin | cboTypeSignal.Text == strSinSquare)
        //    {
        //        txtOffset.Enabled = true;
        //        txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = true;
        //    }
        //    else if (cboTypeSignal.Text == strSin | cboTypeSignal.Text == strSquare)
        //    {
        //        txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = false;
        //        txtConversionFactor.Enabled = txtOffset.Enabled = true;
        //    }
        //}

        //private void lblComPort_Click(object sender, EventArgs e)
        //{
        //}

        //private void lblTypeSignal_Click(object sender, EventArgs e)
        //{
        //}

        //private void lblSetValue_Click(object sender, EventArgs e)
        //{
        //}

        //private async void cboSetValue_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string item = string.Empty;
        //    if (cboTypeSignal.SelectedIndex != -1)
        //    {
        //        item = cboTypeSignal.SelectedItem.ToString();
        //    }
        //    await InitializecboTypeSignal();
        //    if (cboTypeSignal.Items.Contains(item))
        //    {
        //        cboTypeSignal.SelectedItem = item;
        //    }

        //}

        //private void lblConversionFactor_Click(object sender, EventArgs e)
        //{
        //}

        //private void txtConversionFactor_TextChanged(object sender, EventArgs e)
        //{
        //}

        //internal void txtFrequency_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void lblFrequency_Click(object sender, EventArgs e)
        //{
        //}

        //private void lblOffset_Click(object sender, EventArgs e)
        //{
        //}

        //private void txtOffset_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void lblDetector_Click(object sender, EventArgs e)
        //{
        //}

        //private void butCancel_Click(object sender, EventArgs e)
        //{
        //    SaveStatus = SaveStatus.Cancel;
        //    Close();
        //}

        //private void butSendSetting_Click(object sender, EventArgs e)
        //{
        //    SendSetting();
        //}

        //private void SendSetting()
        //{
        //    if (CheckFormsParameters() != Result.Success)
        //    {
        //        return;
        //    }
        //    SetDS360Setting();
        //    Result sendingResult = DS360Setting.SendDS360Setting();

        //    if (sendingResult == Result.Success)
        //    {
        //        MessageBox.Show("Настройка успешно передана в генератор");
        //    }
        //    if (sendingResult != Result.Success)
        //    {
        //        MessageBox.Show(DS360Setting.ResultMessage);
        //    }
        //}

        //private void cboDetector_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        //private void txtFrequency2_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void cboDetector2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //}

        //private void txtValue_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void txtValue2_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void numComName_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Return || e.KeyChar == (char)Keys.Back)
        //    {
        //        return;
        //    }
        //    e.Handled = true;
        //}

        //private void numComName_ValueChanged(object sender, EventArgs e)
        //{

        //}
    }
}
