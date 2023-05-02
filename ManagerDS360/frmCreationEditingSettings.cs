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

namespace ManagerDS360
{
    public enum Type
    {
        Change,
        Control
    }
    public partial class frmCreationEditingSettings : Form
    {
        public Type Type;
        public frmCreationEditingSettings()
        {
            InitializeComponent();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            //сохранить в файл

        }

        private void frmCreationEditingSettings_Load(object sender, EventArgs e)
        {
            //добавление в комбобокс физ.величин
            cboSetValue.Items.Add("м/с2");
            cboSetValue.Items.Add("мм/с");
            cboSetValue.Items.Add("мкм");
            cboSetValue.Items.Add("U");
            cboSetValue.Items.Add("G");

            //добавление в комбобокс вид. сигнала
            cboTypeSignal.Items.Add("Sine");
            cboTypeSignal.Items.Add("Square");


            if (this.Type == Type.Control)
            {
                butSave.Visible = true;
                butSave.Visible = false;
            }
            if (this.Type == Type.Change)
            {
                butSave.Visible = false;
                butSave.Visible = true;
            }

            this.cboComPort.Items.AddRange(DS360Setting.GetDevicesArray());
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

        }

        private void txtFrequency_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFrequency_Click(object sender, EventArgs e)
        {

        }

        private void lblOffset_Click(object sender, EventArgs e)
        {

        }

        private void txtOffset_TextChanged(object sender, EventArgs e)
        {

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
        }
    }
}
