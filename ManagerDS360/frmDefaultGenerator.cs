using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;

namespace ManagerDS360
{
    public partial class frmManagerRoutse : Form
    {
        public frmManagerRoutse()
        {
            InitializeComponent();
            //cboListComPorts.Text = nameGenerator;
        }

        private void lblLisеComPorts_Click(object sender, EventArgs e)
        {
        }

        internal void frmDefaultGenerator_Load(object sender, EventArgs e)
        {

            //this.cboListComPorts.Items.AddRange ( DS360Setting.GetComPortList().ToArray());
            cboListComPorts.Items.AddRange(DS360Setting.GetDevicesArray());
            cboListComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboListComPorts.SelectedIndex = 0;
        }

        internal void cboListComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //комбобокс с выбором вариантов
        }

        private void butFindGenerator_Click(object sender, EventArgs e)
        {

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            //сохранить выбранный генератор как по умолчанию и отправить имя на главную страницу в лейбл 
            frmManagerDS360 frmManagerDS360 = new frmManagerDS360();
            frmManagerDS360.lblDefaultGenerator.Text = Convert.ToString(cboListComPorts.SelectedItem);
            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
