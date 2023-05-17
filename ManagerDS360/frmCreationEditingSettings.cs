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
using VibroMath;

namespace ManagerDS360
{
    public enum Type
    {
        Change,
        Control
    }
    public enum SaveStatus
    {
        Save,
        Cancel
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
        public SaveStatus SaveStatus;
        public double Voltage;
        public DS360Setting DS360Setting;
        Timer timer;
        public frmCreationEditingSettings()
        {
            InitializeComponent();
            InitializecboSetValue();
            InitializecboTypeSignal();
            InitializecboTypeSignal2();
            InitializecboDetector();
            InitializecboDetector2();
            InitializechcboComPort();
        }

        internal void InitializechcboComPort()
        {
            //переключение вкл-выкл у выпадающего ком-порт
        }
        internal void InitializecboDetector2()
        {
            //добавление в комбобокс детектора
            cboDetector2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            string[] enumElements = Enum.GetNames(typeof(Detector));
            foreach (var item in enumElements)
            {
                cboDetector2.Items.Add(item.Replace("_", " - "));
            }
            cboDetector2.SelectedIndex = (int)Detector.СКЗ;
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
        internal void InitializecboTypeSignal2()
        {
            //добавление в комбобокс типов сигналов
            //cboTypeSignal2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //cboTypeSignal2.Items.AddRange(Enum.GetNames(typeof(ToneBFunctionType)));
            //cboTypeSignal2.SelectedIndex = (int)ToneBFunctionType.Sine;
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

            double freq_A;
            double freq_B;
            double voltage = Voltage;
            double amplitudeRMS_A;
            double amplitudeRMS_B;
            string portName;

        
            if (!double.TryParse(txtFrequency.Text, out freq_A))
            {
                MessageBox.Show("Введите частоту 1.");
                //NewMethod(editingSettings);
                return;
            }
            if (!double.TryParse(txtFrequency2.Text, out freq_B))
            {
                MessageBox.Show("Введите частоту 2.");
                //NewMethod(editingSettings);
                return;
            }


            if (cboTypeSignal.Items == cboTypeSignal.Items)
            {
                //ветка для двух тонов
            }
            else //ветка для одного тона
            {
                //if (editingSettings.chcDefaultGenerator.IsCheck)
                //{
                //    dS360Setting = new DS360Setting(voltage);
                //}

                //if (!editingSettings.chcDefaultGenerator.IsCheck)
                //{
                //    dS360Setting = new DS360Setting(voltage);
                //}
            }

            //Voltage = 5; /*= VibroMth.GetVolt();*/
            DS360Setting = new DS360Setting();
            //TreeNode treeNode = new TreeNode();
            //treeNode.Setup = dS360Setting;
            //treRouteTree

            //сохранить настройки в 

            //создание экземпляра
          
            //dS360Setting.frequency_A = double.Parse(txtFrequency.Text);
            //dS360Setting.portName = cboComPort.Items;
            //dS360Setting.frequency_B = double.Parse(txtFrequency2.Text);
            //dS360Setting.functionType = cboTypeSignal.SelectedIndex;

            
            //dS360Setting.Name = cboComPort.Items + txtFrequency.Text + cboDetector.Items;

            //статус сохранения и запуск таймера
            this.SaveStatus = SaveStatus.Save;
            //frmCreationEditingRoute frmCreationEditingRoute = new frmCreationEditingRoute();
            //frmCreationEditingRoute.lblSave.Visible = true;
            //timer.Enabled = true;
            this.Close();
        }

        internal static void NewMethod(frmCreationEditingSettings editingSettings)
        {
            //editingSettings.ShowDialog();

            //DS360Setting dS360Setting = new DS360Setting();

        }
        
        //таймер для сохранения
        internal void timeTick(object sender, EventArgs e)
        {
            frmCreationEditingRoute frmCreationEditingRoute = new frmCreationEditingRoute();
            frmCreationEditingRoute.lblSave.Visible = false;
            timer.Enabled = false;
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

            cboComPort.Items.AddRange(DS360Setting.GetDevicesArray());
            cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            frmCreationEditingRoute frmCreationEditingRoute = new frmCreationEditingRoute();

            chcDefaultGenerator.Checked = true;

            //timer = new Timer();
            //timer.Interval = 5000;
            //timer.Tick += timeTick;
        }

        private void chcDefaultGenerator_CheckedChanged(object sender, EventArgs e)
        {
            //галочка, чтобы взять генератор по умолч. 
            if (chcDefaultGenerator.Checked == false)
            {
                cboComPort.Enabled = true;
            }
            if (chcDefaultGenerator.Checked == true)
            {
                cboComPort.Enabled = false;
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //падающее меню ком - портов
        }

        internal void cboTypeSignal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //вид сигнала 1
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
            this.SaveStatus = SaveStatus.Cancel;
            this.Close();
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            //отправить параметры в генератор
            this.Close();
            //MessageBox.Show("Otpravleno");
        }

        private void cboDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор детектора
        }

        //private void txtFrequency_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        private void cboTypeSignal2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //вид сигнала 2
        }

        private void txtFrequency2_TextChanged(object sender, EventArgs e)
        {
            //ввод второй частоты
        }

        private void cboDetector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор второго детектора
        }

    }
}
