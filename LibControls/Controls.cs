using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;



namespace LibControls
{
    public class GreyButton : Button
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = Color.Blue;
        }
    }
    public enum Access
    {
        UnLock,
        Blocked
    }
    public class ModifiedTextBox : TextBox
    {
        private string LastText;
        public Access Access = Access.UnLock;
        protected override void OnTextChanged(EventArgs e)
        {
            if (Access == Access.UnLock)
            {
                if (!double.TryParse(Text, out double result) && Text != "")
                {
                    Access = Access.Blocked;
                    Text = LastText;
                    Access = Access.UnLock;
                    this.SelectionStart = Text.Length;
                    return;
                }
                LastText = Text;
                base.OnTextChanged(e);
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

    }
    public enum NodeType
    {
        Folder,
        Setting
    }
    [Serializable]
    public class TreeNodeWithSetting : TreeNode
    {
        public NodeType NodeType;
        public DS360SettingVibroSigParam DS360Setting = new DS360SettingVibroSigParam();

        public TreeNodeWithSetting(NodeType nodeType, string text)
        {
            this.NodeType = nodeType;
            if (NodeType == NodeType.Folder)
            {
                this.ImageIndex = 0;
                this.SelectedImageIndex = 0;
            }
            if (NodeType == NodeType.Setting)
            {
                this.ImageIndex = 1;
                this.SelectedImageIndex = 1;
            }
            Text = text;
        }

    }
    [Serializable]
    public class TreeViewWithSetting : TreeView
    {
        public TreeNodeWithSetting CopyTreeNodeWithSetup;
        private TreeNode LastSelectedTreeNode;
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ImageList = new ImageList();
            ImageList.ImageSize = new Size(25, 25);
            ImageList.Images.Add(Properties.Resources.Папка);
            ImageList.Images.Add(Properties.Resources.Настройка);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            DoLastSelectedTreeNodeBackColorWhite();
            this.SelectedNode = null;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Escape)
            {
                DoLastSelectedTreeNodeBackColorWhite();
                this.SelectedNode = null;
            }
        }
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);
            DoLastSelectedTreeNodeBackColorWhite();
            this.SelectedNode.BackColor = Color.FromArgb(0, 120, 215);
            LastSelectedTreeNode = this.SelectedNode;
        }
       private  void DoLastSelectedTreeNodeBackColorWhite()
        {
            if (LastSelectedTreeNode != null)
            {
                LastSelectedTreeNode.BackColor = Color.White;
            }
        }
    }
}