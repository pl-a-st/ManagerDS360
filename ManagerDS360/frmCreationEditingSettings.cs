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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManagerDS360
{
    public enum Type
    {
        Change,
        Control
    }

    public enum PhysicalQuantity
    {
        м_с2,
        мм_с,
        мкм,
        U,
        G
    }
    public enum Detector
    {
        СКЗ,
        Пик,
        Пик_пик
    }

    public partial class frmCreationEditingSettings : Form
    {
        public Type Type;
        public PhysicalQuantity PhysicalQuantity;
        public frmCreationEditingSettings()
        {
            InitializeComponent();
            InitializecboSetValue();
            InitializecboTypeSignal();
            InitializecboDetector();
        }

        internal void InitializecboDetector()
        {
            //добавление в комбобокс детектора
            cboDetector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //cboDetector.Items.AddRange(Enum.GetNames(typeof(Detector)));

            string[] enumElements = Enum.GetNames(typeof(Detector));
            foreach (var item in enumElements)
            {
                cboDetector.Items.Add(item.Replace("_", " - "));
            }
            cboDetector.SelectedIndex = (int)Detector.СКЗ;
        }

        internal void InitializecboTypeSignal()
        {
            //добавление в комбобокс типов сигналов
            cboTypeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            cboTypeSignal.Items.AddRange(Enum.GetNames(typeof(FunctionType)));
            cboTypeSignal.SelectedIndex = (int)FunctionType.Sine;
        }

        internal void InitializecboSetValue()
        {
            //добавление в комбобокс физ.величин
            cboSetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //cboSetValue.Items.AddRange(Enum.GetNames(typeof(PhysicalQuantity)));

            string[] enumElements = Enum.GetNames(typeof(PhysicalQuantity));
            foreach ( var item in enumElements )
            {
                cboSetValue.Items.Add(item.Replace("_", "/"));
            }
            cboSetValue.SelectedIndex = (int)PhysicalQuantity.G;
        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            //сохранить настройки в лист


            //создание экземпляра

            //dS360Setting.frequency_A = double.Parse(txtFrequency.Text);
            //dS360Setting.portName = cboComPort.Items;
            //dS360Setting.frequency_B = double.Parse(txtFrequency2.Text);
            //dS360Setting.amplitudeRMS_A = cboDetector.Items;
            //dS360Setting.amplitudeRMS_B = cboDetector2.Items[0].ToString();
            //dS360Setting.functionType = cboTypeSignal.SelectedIndex;

            //dS360Setting.Name = cboComPort.Items + txtFrequency.Text + cboDetector.Items;
            this.Close();
            
        }

        public void frmCreationEditingSettings_Load(object sender, EventArgs e)
        {
            //взять енам из ds360.сs FunctionType


            if (this.Type == Type.Control)
            {
                butSave.Visible = false;
                butSend.Visible = true;
            }
            if (this.Type == Type.Change)
            {
                butSave.Visible = true;
                butSend.Visible = false;
            }

            this.cboComPort.Items.AddRange(DS360Setting.GetDevicesArray());
            cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void chcDefaultGenerator_CheckedChanged(object sender, EventArgs e)
        {
            //галочка, чтобы взять генератор по умолч. 
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTypeSignal_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        }

        private void lblConversionFactor_Click(object sender, EventArgs e)
        {

        }

        private void txtConversionFactor_TextChanged(object sender, EventArgs e)
        {
            //ввод коэф. преобразования
        }

        internal void txtFrequency_TextChanged(object sender, EventArgs e)
        {
            //ввод частоты
            //double frequency = double.Parse(txtFrequency.Text);
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
        }

        private void lblDetector_Click(object sender, EventArgs e)
        {

        }

        private void txtDetector_TextChanged(object sender, EventArgs e)
        {

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            //отправить параметры в генератор
            this.Close();
            MessageBox.Show("Otpravleno");
        }

        private void cboDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор детектора
        }
    }
}
