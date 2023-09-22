using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360.Controls
{
    public partial class frmAddChangeNode : Form
    {
        public frmAddChangeNode()
        {
            InitializeComponent();
        }
        public TypeFormOpen TypeFormOpen = TypeFormOpen.ToСreate;
        private void frmAddChangeNode_Load(object sender, EventArgs e)
        {
            if (cboChannel.Items.Count == 0)
            {
                cboChannel.Items.AddRange(PmData.Channel.Values.ToArray());
                cboChannel.SelectedIndex = 0;
            }
            if(TypeFormOpen == TypeFormOpen.ToChange)
            {
                lblChannel.Visible = false;
                cboChannel.Visible = false;
            }
            if (TypeFormOpen == TypeFormOpen.ToСreate)
            {
                lblChannel.Visible = true;
                cboChannel.Visible = true;
            }
        }
        public ComboBox GetCboChannel()
        {
            return cboChannel;
        }
        public TextBox GetTxtNameNode ()
        {
            return txtNameNode;
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAddChangeNode_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
