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
        public CallType CallType = CallType.Create;
        public VibrationQuantity VibrationQuantity;
        public Detector Detector;
        public VibrationStand VibrationStand = new VibrationStand();
        
        public frmCreationVibroCalibSetting()
        {
            InitializeComponent();
        }

        public  async void frmCreationVibroCalibSetting_LoadAsync(object sender, EventArgs e)
        {
            if (this.Modal == false)
            {
                this.CenterToParent();
            }
            await PushCboDetector();
            await PushCboSetValue();
            SetInterfaceForCallType();
        }

        private void SetInterfaceForCallType()
        {
            if (CallType == CallType.Create || CallType == CallType.Change)
            {
                butStop.Visible = false;
                butSend.Visible = false;
                this.Height -= butSend.Height;
            }
            if (CallType == CallType.Control)
            {
                butStop.Top = butSave.Top;
                butSend.Top = butCancel.Top;
                butSave.Visible = false;
                butCancel.Visible = false;
                this.Height -= butSend.Height;
            }
        }

        internal async Task PushCboDetector()
        {
            await Task.Delay(10);
            cboDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            if (cboDetector.Items.Count != 0) return;
            cboDetector.Items.AddRange(PmData.Detector.Values.ToArray());
            cboDetector.SelectedItem = PmData.Detector[Detector.СКЗ];
            
            
        }

        ///// <summary>
        ///// добавление в комбобокс физ.величин
        ///// </summary>
        internal async Task PushCboSetValue()
        {
            await Task.Delay(10);
            if(cboSetValue.Items.Count!=0)return;
            var elements = PmData.VibrationQuantity.Values.ToArray();
            cboSetValue.BeginUpdate();
            cboSetValue.Items.AddRange(elements);
            if (string.IsNullOrEmpty(cboSetValue.Text))
            {
                cboSetValue.SelectedItem = PmData.VibrationQuantity[VibrationQuantity.м_с2];
            }
            cboSetValue.EndUpdate();
        }
        private void butSave_Click_1(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (CheckFormsParameters() != Result.Success)
            {
                return;
            }
            SetVibroStend();
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
            if (CheckFormsParameters() != Result.Success)
            {
                return;
            }
            SetVibroStend();
            VibrationStand.RunStend();
        }



        private void SetVibroStend()
        {
            VibrationStand.Frequency.Set_Hz(double.Parse(txtFrequency.Text));
            VibrationStand.Sensitivity.Set_mV_MS2(double.Parse(txtConversionFactor.Text));
            double valueVibParam = double.Parse(txtValue.Text);
            Detector detector = PmData.GetEnumFromString(PmData.Detector, cboDetector.SelectedItem.ToString());
            VibrationStand.Detector = (SignalParametrType)detector;
            if(PmData.GetEnumFromString(PmData.VibrationQuantity, cboSetValue.SelectedItem.ToString()) == VibrationQuantity.м_с2)
            {
                VibrationStand.VibroParametr = new Acceleration(valueVibParam, (SignalParametrType)detector);
            }
            if (PmData.GetEnumFromString(PmData.VibrationQuantity, cboSetValue.SelectedItem.ToString()) == VibrationQuantity.мм_с)
            {
                VibrationStand.VibroParametr = new Velocity(valueVibParam, (SignalParametrType)detector);
            }
            if (PmData.GetEnumFromString(PmData.VibrationQuantity, cboSetValue.SelectedItem.ToString()) == VibrationQuantity.мкм)
            {
                VibrationStand.VibroParametr = new Displacement(valueVibParam, (SignalParametrType)detector);
            }

        }

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

        private Result CheckFormsParameters()
        {
            string message = string.Empty;
            Result result = Result.Success;
            if (!double.TryParse(txtValue.Text, out double amplitudeRMS_A))
            {
                message += "\nВведите значение параметра вибрации";
                result = Result.Failure;
            }
            if (!double.TryParse(txtFrequency.Text, out double frequency_A))
            {
                message += "\nВведите значение частоты";
                result = Result.Failure;
            }
            if (!double.TryParse(txtConversionFactor.Text, out double conversionFactor))
            {
                message += "\nВведите значение коэффициента.";
                result = Result.Failure;
            }
            if (result != Result.Success)
            {
                MessageBox.Show(message);
            }
            return result;
        }

        private void frmCreationVibroCalibSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CallType == CallType.Control && Visible == true)
            {
                e.Cancel = true;
                Visible = false;
                TopLevel = false;
            }
        }

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
