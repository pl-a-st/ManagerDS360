using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolTip = System.Windows.Forms.ToolTip;

namespace ManagerDS360
{
    public partial class frmInputName : Form
    {
        public SaveName SaveName;
        public frmInputName()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveName = SaveName.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNameSet.Text == "" || txtNameSet.Text == string.Empty)
            {
                MessageBox.Show("Не введено название.");
                return;
            }
            SaveName = SaveName.SaveName;
            Close();
        }

        private void frmInputName_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.btnSave, "CTRL+S ");
            toolTip1.SetToolTip(this.btnCancel, "CTRL+X ");
        }

        private void txtNameSet_TextChanged(object sender, EventArgs e)
        {
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S)    // сохранить
            {
                if (txtNameSet.Text == "" || txtNameSet.Text == string.Empty)
                {
                    MessageBox.Show("Не введено название.");
                    return;
                }
                SaveName = SaveName.SaveName;
                Close();
            }
            if (e.Control == true && e.KeyCode == Keys.X)    // закрыть
            {
                Close();
            }
        }
    }
}
