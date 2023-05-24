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
            SaveName = SaveName.SaveName;

            Close();
        }

        private void frmInputName_Load(object sender, EventArgs e)
        {

        }

        private void txtNameSet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
