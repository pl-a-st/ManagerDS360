﻿using LibDevicesManager;
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

namespace ManagerDS360
{
    public enum Type
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
    public enum Detector
    {
        СКЗ = SignalParametrType.RMS,
        Пик = SignalParametrType.PIK,
        Пик_пик = SignalParametrType.PIK_PIK
    }

    public partial class frmCreationEditingSettings : Form
    {
        public Type Type;
        public SaveStatus SaveStatus;
        public PhysicalQuantity PhysicalQuantity;
        public Detector Detector;
        public FunctionTypeSignal FunctionTypeSignal;

        public double Voltage;
        public DS360SettingVibroSigParam DS360Setting = new DS360SettingVibroSigParam();
        public frmCreationEditingSettings()
        {
            InitializeComponent();
        }
        public void frmCreationEditingSettings_Load(object sender, EventArgs e)
        {
            if (Type == Type.Create || Type == Type.Control)
            {
                InitializecboSetValue();
                InitializecboTypeSignal();
                InitializecboDetector();
                InitializecboDetector2();
                InitializechcboComPort();
            }
            //взять енам из ds360.сs FunctionType

            if (this.Type == Type.Control)
            {
                butSave.Visible = false;
                butSend.Visible = true;
                butSend.Location = butSave.Location;
            }
            if (this.Type == Type.Create || this.Type == Type.Change)
            {
                butSave.Visible = true;
                butSend.Visible = false;
            }

            //cboComPort.Items.AddRange(DS360Setting.GetDevicesArray());
            //ААС: Добавил ниже список из 20 имён
            
            frmCreationEditingRoute frmCreationEditingRoute = new frmCreationEditingRoute();
            chcDefaultGenerator.Checked = true;

        }

        internal void InitializechcboComPort()
        {
            //переключение вкл-выкл у выпадающего ком-порт
        }
        internal void InitializecboDetector2()
        {
            cboDetector2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;  //добавление в комбобокс детектора

            foreach (var element in PmData.Detector)
            {
                cboDetector2.Items.Add(element.Value);
            }

            cboDetector2.SelectedIndex = (int)Detector.СКЗ;
        }

        internal void InitializecboDetector()
        {
            cboDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;   //добавление в комбобокс детектора
            foreach (var element in PmData.Detector)
            {
                cboDetector.Items.Add(element.Value);
            }
            cboDetector.SelectedIndex = (int)Detector.СКЗ;
        }

        internal void InitializecboTypeSignal()
        {
            //добавление в комбобокс типов сигналов
            cboTypeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ///отключение ввода символов
            ////строку в Енам
            //Enum.Parse(typeof(Race), cBxRace.Text, true);
            cboTypeSignal.Items.Clear();
            foreach (var element in PmData.FunctionTypeSignal)
            {
                if (IsElementNotForVelocityOrDisplacment(element))
                {
                    continue;
                }
                cboTypeSignal.Items.Add(element.Value);
            }
            cboTypeSignal.SelectedIndex = 0;
        }

        private bool IsElementNotForVelocityOrDisplacment(KeyValuePair<FunctionTypeSignal, string> element)
        {
            return (
                element.Key == FunctionTypeSignal.Квадрат || element.Key == FunctionTypeSignal.Синус_Квадрат) &
                (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мм_с || 
                PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мкм);
        }

        private static string TypeSignalToString(int element)
        {
            return ((FunctionTypeSignal)element).ToString().Replace("_", " - ");
        }
        /// <summary>
        /// добавление в комбобокс физ.величин
        /// </summary>
        internal void InitializecboSetValue()
        {
            cboSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; ///отключение ввода символов
            foreach (var element in PmData.PhysicalQuantity)
            {
                cboSetValue.Items.Add(element.Value);
            }
            cboSetValue.SelectedIndex = 0;
        }
        private static string SetValueToString(int element)
        {
            return ((PhysicalQuantity)element).ToString().Replace("_", " / ");
        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            if (CheckFormsParameters() != Result.Success)
            {
                return;
            }
            SetDS360Setting();
            SaveStatus = SaveStatus.Save;


            //продумать конфигурацию имени для настройки 
            StaticName.nameBuffer = "Частота: " + DS360Setting.Frequency + "; " + "Тип сигнала: " + DS360Setting.FunctionType + "; " + "Значение: " + txtValue.Text + " " + " _ " + cboSetValue.SelectedText;

            this.Close();
        }

        private void SetDS360Setting()
        {
            DS360Setting = new DS360SettingVibroSigParam();
            if (chcDefaultGenerator.Checked)
            {
                DS360Setting.SetComPortNameToDefault();
            }
            if (!chcDefaultGenerator.Checked)
            {
                DS360Setting.ComPortNumber = (int)numComName.Value;
            }
            DS360Setting.SignalParametrTone1 = (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDetector.Text);
            DS360Setting.SignalParametrTone2 = (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDetector2.Text);
            //ветка для двух тонов
            if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Синус)
            {
                DS360Setting.FunctionType = FunctionType.SineSine;
                DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
                SetVibroCalclToTone(txtValue, cboDetector, txtFrequency);
                DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
                SetVibroCalclToTone(txtValue2, cboDetector2, txtFrequency2);
                DS360Setting.AmplitudeRMSToneB = VibroCalc.Voltage.GetRMS();
            }
            if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Квадрат)
            {
                DS360Setting.FunctionType = FunctionType.SineSquare;
                DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
                SetVibroCalclToTone(txtValue, cboDetector, txtFrequency);
                DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
                DS360Setting.FrequencyB = double.Parse(txtFrequency2.Text);
                DS360Setting.AmplitudeRMSToneB = GetValueToSquareToDetector(cboDetector2, txtValue2);
            }
            if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус)
            {
                DS360Setting.FunctionType = FunctionType.Sine;
                SetVibroCalclToTone(txtValue, cboDetector, txtFrequency);
                DS360Setting.AmplitudeRMS = VibroCalc.Voltage.GetRMS();
            }
            if (PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Квадрат)
            {
                DS360Setting.FunctionType = FunctionType.Square;
                DS360Setting.AmplitudeRMS = GetValueToSquareToDetector(cboDetector, txtValue);
            }

            DS360Setting.Sensitivity.Set_mV_G(double.Parse(txtConversionFactor.Text));
            DS360Setting.Frequency = double.Parse(txtFrequency.Text);
            DS360Setting.Offset = double.Parse(txtOffset.Text);
        }

        private double GetValueToSquareToDetector(System.Windows.Forms.ComboBox cbo, TextBox txt)
        {
            double value1 = double.Parse(txt.Text);
            if (PmData.GetEnumFromString(PmData.Detector, cbo.Text) == Detector.Пик_пик)
            {
                value1 = value1 / 2;
            }
            return value1;
        }

        internal void SetVibroCalclToTone(TextBox txtVal, ComboBox cboDet, TextBox txtFreq)
        {
            VibroCalc.Frequency.Set_Hz(double.Parse(txtFreq.Text));
            VibroCalc.Sensitivity.Set_mV_G(double.Parse(txtConversionFactor.Text));

            if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мм_с)
            {
                Velocity velocity = new Velocity(double.Parse(txtVal.Text), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet.Text));
                VibroCalc.CalcAll(velocity);
                DS360Setting.VibroParametr = velocity;
            }
            if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.мкм)
            {
                Displacement displacement = new Displacement(double.Parse(txtVal.Text), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet.Text));
                VibroCalc.CalcAll(displacement);
                DS360Setting.VibroParametr = displacement;
            }
            if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.м_с2)
            {
                Acceleration acceleration = new Acceleration(double.Parse(txtVal.Text), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet.Text));
                VibroCalc.CalcAll(acceleration);
                DS360Setting.VibroParametr = acceleration;
            }
            if (PmData.GetEnumFromString(PmData.PhysicalQuantity, cboSetValue.Text) == PhysicalQuantity.U)
            {
                Voltage voltage = new Voltage(double.Parse(txtVal.Text), (SignalParametrType)PmData.GetEnumFromString(PmData.Detector, cboDet.Text));
                VibroCalc.CalcAll(voltage);
                DS360Setting.VibroParametr = voltage;
            }

        }

        private Result CheckFormsParameters()
        {
            string message = string.Empty;
            Result result = Result.Success;
            if (!double.TryParse(txtValue.Text, out double amplitudeRMS_A))
            {
                //MessageBox.Show("Введите значение 1.");
                //return Result.Failure;
                message += "\nВведите значение 1";
                result = Result.Failure;
            }
            if (!double.TryParse(txtFrequency.Text, out double frequency_A))
            {
                //MessageBox.Show("Введите частоту 1.");
                //return Result.Failure;
                message += "\nВведите частоту 1";
                result = Result.Failure;
            }
            if (IsTwoTone() && !double.TryParse(txtValue2.Text, out double amplitudeRMS_B))
            {
                //MessageBox.Show("Введите значение 2.");
                //return Result.Failure;
                message += "\nВведите значение 2.";
                result = Result.Failure;
            }
            if (IsTwoTone() && !double.TryParse(txtFrequency2.Text, out double frequency_B))
            {
                //MessageBox.Show("Введите частоту 2.");
                //return Result.Failure;
                message += "\nВведите частоту 2.";
                result = Result.Failure;
            }
            if (!IsTwoTone() && !double.TryParse(txtOffset.Text, out double offset))
            {
                //MessageBox.Show("Введите значение смещения.");
                //return Result.Failure;
                message += "\nВведите значение смещения.";
                result = Result.Failure;
            }
            if (!double.TryParse(txtConversionFactor.Text, out double conversionFactor))
            {
                //MessageBox.Show("Введите значение коэффициента.");
                //return Result.Failure;
                message += "\nВведите значение коэффициента.";
                result = Result.Failure;
            }
            if (result != Result.Success)
            {
                MessageBox.Show(message);
            }
            return result;

        }

        internal bool IsTwoTone()
        {
            return PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Синус
                | PmData.GetEnumFromString(PmData.FunctionTypeSignal, cboTypeSignal.Text) == FunctionTypeSignal.Синус_Квадрат;
        }

        internal static void NewMethod(frmCreationEditingSettings editingSettings)
        {
            //editingSettings.ShowDialog();
            //DS360Setting dS360Setting = new DS360Setting();
        }


        private void chcDefaultGenerator_CheckedChanged(object sender, EventArgs e)
        {
            //галочка, чтобы взять генератор по умолч. 
            if (chcDefaultGenerator.Checked == false)
            {
                numComName.Enabled = true;
            }
            if (chcDefaultGenerator.Checked == true)
            {
                numComName.Enabled = false;
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //падающее меню ком - портов
        }

        internal void cboTypeSignal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FunctionTypeSignal = FunctionTypeSignal.Квадрат;
            //FunctionTypeSignal = cboTypeSignal.SelectedIndex;
            //FunctionTypeSignal = typeof(cboTypeSignal.Items[cboTypeSignal.SelectedIndex].Replace("_", " - "));
            //if (cboTypeSignal.Items[cboTypeSignal.SelectedIndex] == FunctionTypeSignal.Синус||cboTypeSignal.SelectedItem == FunctionTypeSignal.Квадрат)
            //вид сигнала!

            //FunctionTypeSignal = FunctionTypeSignal[cboTypeSignal.SelectedIndex];

            string strSinSin = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус_Синус];
            string strSinSquare = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус_Квадрат];
            string strSin = PmData.FunctionTypeSignal[FunctionTypeSignal.Синус];
            string strSquare = PmData.FunctionTypeSignal[FunctionTypeSignal.Квадрат];
            if (cboTypeSignal.Text == strSinSin | cboTypeSignal.Text == strSinSquare)
            {
                txtOffset.Enabled = true;
                txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = true;
            }
            else if (cboTypeSignal.Text == strSin | cboTypeSignal.Text == strSquare)
            {
                txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = false;
                txtConversionFactor.Enabled = txtOffset.Enabled = true;
            }
        }

        private void lblComPort_Click(object sender, EventArgs e)
        {
        }

        private void lblTypeSignal_Click(object sender, EventArgs e)
        {
        }

        private void lblSetValue_Click(object sender, EventArgs e)
        {
        }

        private void cboSetValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializecboTypeSignal();
            //физическая величина

        }

        private void lblConversionFactor_Click(object sender, EventArgs e)
        {
        }

        private void txtConversionFactor_TextChanged(object sender, EventArgs e)
        {
            //ввод коэф. преобразования
            txtConversionFactor.Enabled = true;
            //txtConversionFactor = 100;
        }

        internal void txtFrequency_TextChanged(object sender, EventArgs e)
        {
            //ввод частоты
            txtFrequency.Enabled = true;
        }

        private void lblFrequency_Click(object sender, EventArgs e)
        {
        }

        private void lblOffset_Click(object sender, EventArgs e)
        {
        }

        private void txtOffset_TextChanged(object sender, EventArgs e)
        {
            //ввод смещения
            txtOffset.Enabled = true;
        }

        private void lblDetector_Click(object sender, EventArgs e)
        {
        }

        //private void txtDetector_TextChanged(object sender, EventArgs e)
        //{
        //}

        private void butCancel_Click(object sender, EventArgs e)
        {
            SaveStatus = SaveStatus.Cancel;
            Close();
        }

        private void butSendSetting_Click(object sender, EventArgs e)
        {
            if (CheckFormsParameters() != Result.Success)
            {
                return;
            }
            SetDS360Setting();
            //
            Result sendingResult = DS360Setting.SendDS360Setting();
            //
            if (sendingResult == Result.Success)
            {
                MessageBox.Show("Настройка успешно передана в генератор");
            }
            if (sendingResult != Result.Success)
            {
                MessageBox.Show(DS360Setting.ResultMessage);
            }
        }

        private void cboDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор детектора
        }

        //private void txtFrequency_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}
        private void txtFrequency2_TextChanged(object sender, EventArgs e)
        {
            //ввод второй частоты
            txtFrequency2.Enabled = true;
        }

        private void cboDetector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор второго детектора
            cboDetector2.Enabled = false;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            //ввод первого значения
            txtValue.Enabled = true;
        }

        private void txtValue2_TextChanged(object sender, EventArgs e)
        {
            //ввод второго значения
            txtValue2.Enabled = true;
        }

        private void numComName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 49 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }
    }
}
