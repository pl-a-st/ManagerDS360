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

        public TextBox GetTxtTimeToAnswer()
        {
            return txtTimeToAnswer;
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
                MessageBox.Show("Не выбран узел!");
                return;
            }
            FrmAddChangeNode.TypeFormOpen = TypeFormOpen.ToChange;
            if (FrmAddChangeNode.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (lstChannelFirst.SelectedIndex != -1)
            {
                lstChannelFirst.Items[lstChannelFirst.SelectedIndex] = FrmAddChangeNode.GetTxtNameNode().Text;
            }
            if (lstChannelSecond.SelectedIndex != -1)
            {
                lstChannelSecond.Items[lstChannelSecond.SelectedIndex] = FrmAddChangeNode.GetTxtNameNode().Text;
            }
        }

        private bool IsItemNotSelected()
        {
            return (lstChannelFirst.SelectedIndex == -1 && lstChannelSecond.SelectedIndex == -1);
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
            if (IsItemNotSelected())
            {
                MessageBox.Show("Не выбран узел!");
                return;
            }
            if (lstChannelFirst.SelectedIndex != -1)
            {
                StringToCopy = lstChannelFirst.Items[lstChannelFirst.SelectedIndex].ToString();
            }
            if (lstChannelSecond.SelectedIndex != -1)
            {
                StringToCopy = lstChannelSecond.Items[lstChannelFirst.SelectedIndex].ToString();
            }
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            if (IsItemNotSelected())
            {
                MessageBox.Show("Не выбран канал!");
                return;
            }
            if (lstChannelFirst.SelectedIndex != -1)
            {
                lstChannelFirst.Items.Add(StringToCopy);
            }
            if (lstChannelSecond.SelectedIndex != -1)
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
            if (lstChannelFirst.SelectedIndex != -1)
            {
                int selectIndex = lstChannelFirst.SelectedIndex;
                lstChannelFirst.Items.RemoveAt(selectIndex);
                if (lstChannelFirst.Items.Count > 0)
                {
                    if (lstChannelFirst.Items.Count == selectIndex)
                    {
                        lstChannelFirst.SelectedIndex = selectIndex - 1;

                    }
                    else
                    {
                        lstChannelFirst.SelectedIndex = selectIndex;
                    }
                }
            }
            if (lstChannelSecond.SelectedIndex != -1)
            {
                int selectIndex = lstChannelSecond.SelectedIndex;
                lstChannelSecond.Items.RemoveAt(selectIndex);
                if (lstChannelFirst.Items.Count > 0)
                {
                    if (lstChannelSecond.Items.Count == selectIndex)
                    {
                        lstChannelSecond.SelectedIndex = selectIndex - 1;

                    }
                    else
                    {
                        lstChannelSecond.SelectedIndex = selectIndex;
                    }
                }
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            DC23.SetRouteName(txtRouteName.Text);
            DC23.SetСhannelFirstAddress(GetAddress(lstChannelFirst));
            DC23.SetСhannelSecondAddress(GetAddress(lstChannelSecond));
            DC23.TimeToAnswer = int.Parse(txtTimeToAnswer.Text);
        }
        private string GetAddress(ListBox lst)
        {
            string address = txtRouteName.Text;
            foreach (string str in lst.Items)
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

        private void lstChannelFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChannelFirst.SelectedIndex == -1)
            {
                return;
            }
            lstChannelSecond.SelectedIndex = -1;
        }

        private void lstChannelSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstChannelSecond.SelectedIndex == -1)
            {
                return;
            }
            lstChannelFirst.SelectedIndex = -1;
        }

        private void butChannelFirstUp_Click(object sender, EventArgs e)
        {
            ItemUp(lstChannelFirst);
        }
        private void butChannelSecondUp_Click(object sender, EventArgs e)
        {
            ItemUp(lstChannelSecond);
        }
        private void butChannelFirstDown_Click(object sender, EventArgs e)
        {
            ItemDown(lstChannelFirst);
        }
        private void butChannelSecondDown_Click(object sender, EventArgs e)
        {
            ItemDown(lstChannelSecond);
        }
         
        private void ItemUp(ListBox lst)
        {
            if (lst.SelectedIndex == -1)
            {
                return;
            }
            var item = lst.SelectedItem;
            int index = lst.SelectedIndex;
            if (index > 0)
            {
                lst.Items.RemoveAt(index);
                lst.Items.Insert(index - 1, item);
                lst.SelectedIndex = index - 1;
            }
        }
        private void ItemDown(ListBox lst)
        {
            if (lst.SelectedIndex == -1)
            {
                return;
            }
            var item = lst.SelectedItem;
            int index = lst.SelectedIndex;
            if (index < lst.Items.Count - 1)
            {
                lst.Items.RemoveAt(index);
                lst.Items.Insert(index +1, item);
                lst.SelectedIndex = index+1 ;
            }
        }
    }
}
