using LibDevicesManager.DC23;
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

    public partial class frmCreationDC23Setting : Form
    {

        public ManagerDC23 DC23 = new ManagerDC23();
        public TypeFormOpen TypeFormOpen = TypeFormOpen.ToСreate;
        private string StringToCopy = string.Empty;
        private frmAddChangeNode FrmAddChangeNode = new frmAddChangeNode();
        public frmCreationDC23Setting()
        {
            InitializeComponent();
        }

        public TextBox GetTxtRoutName()
        {
            return txtRouteName;
        }
        public ListBox GetLstChannaleFirst()
        {
            return lstChannelFirst;
        }
        public ListBox GetLstChannelSecond()
        {
            return lstChannelSecond;
        }

        private void frmCreationDC23Setting_Load(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            FrmAddChangeNode.TypeFormOpen = TypeFormOpen.ToСreate;
            if (FrmAddChangeNode.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (FrmAddChangeNode.GetCboChannel().SelectedIndex == (int)Channel.ChannelFirst)
            {
                lstChannelFirst.Items.Add(FrmAddChangeNode.GetTxtNameNode().Text);
            }
            if (FrmAddChangeNode.GetCboChannel().SelectedIndex == (int)Channel.ChannelSecond)
            {
                lstChannelSecond.Items.Add(FrmAddChangeNode.GetTxtNameNode().Text);
            }
            if (FrmAddChangeNode.GetCboChannel().SelectedIndex == (int)Channel.ChannelFirstAndSecond)
            {
                lstChannelFirst.Items.Add(FrmAddChangeNode.GetTxtNameNode().Text);
                lstChannelSecond.Items.Add(FrmAddChangeNode.GetTxtNameNode().Text);
            }
        }

        private void butChange_Click(object sender, EventArgs e)
        {
            if (IsItemNotSelected())
            {
                MessageBox.Show("Не выбран канал или узел!");
                return;
            }
            FrmAddChangeNode.TypeFormOpen = TypeFormOpen.ToChange;
            if (FrmAddChangeNode.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (lstChannelFirst.Focused)
            {
                lstChannelFirst.Items[lstChannelFirst.SelectedIndex] = FrmAddChangeNode.GetTxtNameNode().Text;
            }
            if (lstChannelSecond.Focused)
            {
                lstChannelSecond.Items[lstChannelFirst.SelectedIndex] = FrmAddChangeNode.GetTxtNameNode().Text;
            }
        }

        private bool IsItemNotSelected()
        {
            return (lstChannelFirst.SelectedIndex == -1 && lstChannelSecond.SelectedIndex == -1) ||
                (!lstChannelFirst.Focused && !lstChannelSecond.Focused);
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
            if (IsItemNotSelected())
            {
                MessageBox.Show("Не выбран канал или узел!");
                return;
            }
            if (lstChannelFirst.Focused)
            {
                StringToCopy = lstChannelFirst.Items[lstChannelFirst.SelectedIndex].ToString();
            }
            if (lstChannelSecond.Focused)
            {
                StringToCopy = lstChannelSecond.Items[lstChannelFirst.SelectedIndex].ToString();
            }
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            if ((!lstChannelFirst.Focused && !lstChannelSecond.Focused))
            {
                MessageBox.Show("Не выбран канал!");
                return;
            }
            if (lstChannelFirst.Focused)
            {
                lstChannelFirst.Items.Add(StringToCopy);
            }
            if (lstChannelSecond.Focused)
            {
                lstChannelSecond.Items.Add(StringToCopy);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (IsItemNotSelected())
            {
                MessageBox.Show("Не выбран канал или узел!");
                return;
            }
            if (lstChannelFirst.Focused)
            {
                int selectIndex = lstChannelFirst.SelectedIndex;
                lstChannelFirst.Items.RemoveAt(selectIndex);
                if (lstChannelFirst.Items.Count > 0)
                {
                    lstChannelFirst.SelectedIndex = selectIndex;
                }
            }
            if (lstChannelSecond.Focused)
            {
                int selectIndex = lstChannelSecond.SelectedIndex;
                lstChannelSecond.Items.RemoveAt(selectIndex);
                if (lstChannelFirst.Items.Count > 0)
                {
                    lstChannelSecond.SelectedIndex = selectIndex;
                }
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            DC23.SetRouteName(txtRouteName.Text);
            DC23.SetСhannelFirstAddress(GetAddress(lstChannelFirst));
            DC23.SetСhannelSecondAddress(GetAddress(lstChannelSecond));
        }
        private string GetAddress(ListBox lst)
        {
            string address = txtRouteName.Text;
            foreach(string str in lst.Items)
            {
                address += $"/{str}";
            }
            address = address.Replace(" ", "_"); 
            return address;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmCreationDC23Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
