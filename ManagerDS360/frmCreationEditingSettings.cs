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
using System.Diagnostics;

namespace ManagerDS360
{
    public enum Type
    {
        Change,
        Control
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
        Save,
        Cancel
    }

    public enum PhysicalQuantity
    {
        U,
        м_с2,
        мм_с,
        мкм,
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
        public SaveStatus SaveStatus;
        public PhysicalQuantity PhysicalQuantity;
        public Detector Detector;
        public FunctionTypeSignal FunctionTypeSignal;

        public double Voltage;
        public DS360Setting DS360Setting;
        public frmCreationEditingSettings()
        {
            InitializeComponent();
            InitializecboSetValue();
            InitializecboTypeSignal();
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

        internal void InitializecboTypeSignal()
        {
            //добавление в комбобокс типов сигналов
            cboTypeSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //cboTypeSignal.Items.AddRange(Enum.GetNames(typeof(FunctionType)));
            //cboTypeSignal.SelectedIndex = (int)FunctionType.Sine;

            string[] enumElements = Enum.GetNames(typeof(FunctionTypeSignal));
            foreach (var item in enumElements)
            {
                cboTypeSignal.Items.Add(item.Replace("_", " - "));
            }
            cboTypeSignal.SelectedIndex = (int)FunctionTypeSignal.Синус;
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
            cboSetValue.SelectedIndex = (int)PhysicalQuantity.U;
        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            //объявление переменных
            double frequency_A;
            double frequency_B;
            double voltage = Voltage;
            double amplitudeRMS_A;
            double amplitudeRMS_B;
            double offset;
            double conversionFactor;
            string portName;
            if (chcDefaultGenerator.Checked)
            {
                portName = chcDefaultGenerator.Text;
            }
            if (!chcDefaultGenerator.Checked)
            {
                portName = cboComPort.Text;
            }
            DS360Setting = new DS360Setting();

            //проверки на ввод значений

            if (!double.TryParse(txtValue.Text, out amplitudeRMS_A))
            {
                MessageBox.Show("Введите значение 1.");
                //NewMethod(editingSettings);
                return;
            }
            if (!double.TryParse(txtFrequency.Text, out frequency_A))
            {
                MessageBox.Show("Введите частоту 1.");
                return;
            }
            if (cboTypeSignal.Text == "Синус - Квадрат" | cboTypeSignal.Text == "Синус - Синус" & !double.TryParse(txtValue2.Text, out amplitudeRMS_B))
            {
                MessageBox.Show("Введите значение 2.");
                return;
            }
            if (cboTypeSignal.Text == "Синус - Квадрат" | cboTypeSignal.Text == "Синус - Синус" & !double.TryParse(txtFrequency2.Text, out frequency_B))
            {
                MessageBox.Show("Введите частоту 2.");
                return;
            }
            

            if (cboTypeSignal.Text == "Синус" & cboTypeSignal.Text == "Квадрат" &  !double.TryParse(txtOffset.Text, out offset))
            {
                MessageBox.Show("Введите значение смещения.");
                return;
            }
            if (!double.TryParse(txtConversionFactor.Text, out conversionFactor))
            {
                MessageBox.Show("Введите значение коэффициента.");
                //NewMethod(editingSettings);
                return;
            }


            //Enum.Parse(typeof(Race), cBxRace.Text, true);

            //(Race)Enum.Parse(typeof(RaceInRussian), cBxRace.Text, true)

             //ветви для приёма значений
             //ветка для двух тонов
            if (cboTypeSignal.Text == "Синус - Синус" | cboTypeSignal.Text == "Синус - Квадрат")
            {
                //DS360Setting = new DS360Setting(portName, functionType, frequency_A, amplitudeRMS_A, frequency_B, amplitudeRMS_B);
            }
            else //ветка для одного тона
            {

                if (chcDefaultGenerator.Checked)
                {
                    //DS360Setting = new DS360Setting(functionType, amplitudeRMS_A(voltage), frequency_A, offset);
                }

                if (!chcDefaultGenerator.Checked)
                {
                    //DS360Setting = new DS360Setting(portName, functionType, amplitudeRMS_A(voltage), frequency_A, offset);
                }
            }

            //Voltage = 5; /*= VibroMth.GetVolt();*/

            //TreeNode treeNode = new TreeNode();
            //treeNode.Setup = dS360Setting;
            //treRouteTree

            //сохранить настройки в 


            //создание экземпляра
            //dS360Setting.functionType = cboTypeSignal.SelectedIndex;

            
            //dS360Setting.Name = cboComPort.Items + txtFrequency.Text + cboDetector.Items;


            this.Close();
        }

        internal static void NewMethod(frmCreationEditingSettings editingSettings)
        {
            //editingSettings.ShowDialog();

            //DS360Setting dS360Setting = new DS360Setting();
        }

        public void frmCreationEditingSettings_Load(object sender, EventArgs e)
        {
            //взять енам из ds360.сs FunctionType

            if (this.Type == Type.Control)
            {
                butSave.Enabled = false;
                butSend.Enabled = true;
            }
            if (this.Type == Type.Change)
            {
                butSave.Enabled = true;
                butSend.Enabled = false;
            }

            cboComPort.Items.AddRange(DS360Setting.GetDevicesArray());
            cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            frmCreationEditingRoute frmCreationEditingRoute = new frmCreationEditingRoute();

            chcDefaultGenerator.Checked = true;
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
            FunctionTypeSignal = FunctionTypeSignal.Квадрат;
            //FunctionTypeSignal = cboTypeSignal.SelectedIndex;
            //FunctionTypeSignal = typeof(cboTypeSignal.Items[cboTypeSignal.SelectedIndex].Replace("_", " - "));
            //if (cboTypeSignal.Items[cboTypeSignal.SelectedIndex] == FunctionTypeSignal.Синус||cboTypeSignal.SelectedItem == FunctionTypeSignal.Квадрат)
            //вид сигнала!!!
            //int index = cboTypeSignal.SelectedIndex;
            //string str1 = cboTypeSignal.Items[index].ToString().Replace(" - ", "_");

            //FunctionTypeSignal = FunctionTypeSignal[cboTypeSignal.SelectedIndex];
            /*
            if (FunctionTypeSignal == FunctionTypeSignal.Синус_Синус | FunctionTypeSignal == FunctionTypeSignal.Синус_Квадрат)
            {
                txtConversionFactor.Enabled = txtOffset.Enabled = false;
                txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = true;
            }
            if (FunctionTypeSignal == FunctionTypeSignal.Синус | this.FunctionTypeSignal == FunctionTypeSignal.Квадрат)
            {
                txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = false;
                txtConversionFactor.Enabled = txtOffset.Enabled = true;
            }
            */
            string strSinSin = FunctionTypeSignal.Синус_Синус.ToString().Replace("_", " - ");
            if (cboTypeSignal.Text == strSinSin | cboTypeSignal.Text == "Синус - Квадрат")
            {
                txtOffset.Enabled = true;
                txtValue2.Enabled = txtFrequency2.Enabled = cboDetector2.Enabled = true;
            }
            else if (cboTypeSignal.Text == "Синус" | cboTypeSignal.Text == "Квадрат")
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
            //физическая величина
        }

        private void lblConversionFactor_Click(object sender, EventArgs e)
        {

        }

        private void txtConversionFactor_TextChanged(object sender, EventArgs e)
        {
            //ввод коэф. преобразования
            txtConversionFactor.Enabled = true;
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
            DS360Setting setting = new DS360Setting();
            Result sendingResult = DS360Setting.SendDS360Setting(setting, out string message);
            if (sendingResult == Result.Success)
            {
                MessageBox.Show("Настройка успешно передана в генератор");
            }
            if (sendingResult != Result.Success)
            {
                MessageBox.Show(message);
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
    }
}
