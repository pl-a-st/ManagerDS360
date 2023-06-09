using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
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
        }

        private void lblLisеComPorts_Click(object sender, EventArgs e)
        {
        }

        internal void frmDefaultGenerator_Load(object sender, EventArgs e)
        {
            //cboListComPorts.Items.AddRange(DS360Setting.GetDevicesArray());
            cboListComPorts.Items.AddRange(DS360Setting.FindAllDS360());
            cboListComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboListComPorts.SelectedIndex = 0;
        }

        internal void cboListComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //комбобокс с выбором вариантов

        }

        private void butFindGenerator_Click(object sender, EventArgs e)
        {
            cboListComPorts.Items.Clear();
            cboListComPorts.Items.AddRange(DS360Setting.FindAllDS360(true));
            cboListComPorts.SelectedIndex = 0;
        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            //сохранить выбранный генератор как по умолчанию и отправить имя на главную страницу в лейбл
            DS360Setting.ComPortDefaultName = cboListComPorts.SelectedItem.ToString();
            frmManagerDS360 frmManagerDS360 = (frmManagerDS360)Application.OpenForms["frmManagerDS360"];
            //frmManagerDS360.lblDefaultGenerator.Text = cboListComPorts.SelectedItem.ToString(); //ААС: эта строка лишняя!
            Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
