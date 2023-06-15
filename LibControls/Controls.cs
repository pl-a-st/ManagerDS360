using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;
using ManagerDS360;

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
            SetImage();
            Text = text;
        }
        protected TreeNodeWithSetting(SerializationInfo info, StreamingContext context)
        {
            try
            {
                this.Text = (string)info.GetValue("NodeText", this.Text.GetType());
                this.DS360Setting = (DS360SettingVibroSigParam)info.GetValue("DS360Setting", this.DS360Setting.GetType());
                this.NodeType = (NodeType)info.GetValue("NodeType", this.NodeType.GetType());
                TreeNodeWithSetting[] test = new TreeNodeWithSetting[1];
                TreeNodeWithSetting[] treeNodeWithSettings = (TreeNodeWithSetting[])info.GetValue("treeNodeWithSettings", test.GetType());
                foreach (var node in treeNodeWithSettings)
                {
                    this.Nodes.Add(node);
                }

                if ((bool)info.GetValue("IsExpand", this.IsExpanded.GetType()))
                {
                    this.Expand();
                }
                SetImage();
            }
            catch
            {

            }
        }

        protected override void Deserialize(SerializationInfo serializationInfo, StreamingContext context)
        {
            base.Deserialize(serializationInfo, context);
        }
        protected override void Serialize(SerializationInfo si, StreamingContext context)
        {
            base.Serialize(si, context);
            si.AddValue("NodeText", this.Text);
            si.AddValue("DS360Setting", this.DS360Setting);
            si.AddValue("NodeType", this.NodeType);
            SetImage();
            TreeNodeWithSetting[] treeNodeWithSettings = new TreeNodeWithSetting[this.Nodes.Count];
            this.Nodes.CopyTo(treeNodeWithSettings, 0);
            si.AddValue("treeNodeWithSettings", treeNodeWithSettings);
            si.AddValue("IsExpand", this.IsExpanded);
        }

        private void SetImage()
        {
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
            ImageList.Images.Add(Properties.Resources.Настройка_синяя);
            ImageList.Images.Add(Properties.Resources.Настройка_красная);
            ImageList.Images.Add(Properties.Resources.Настройка_зеленая);
           
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
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
        public void LoadTreeNodesWithSeetings(FileInfo fileInfo)
        {
            string fileRoutePath = fileInfo.FullName;
            TreeNodeWithSetting[] treeNodeWithSettings = null;
            treeNodeWithSettings = DALS.binReadFileToObject(treeNodeWithSettings, fileRoutePath, out MethodResultStatus methodResultStatus);
            if (methodResultStatus == MethodResultStatus.Ok)
            {
                this.Nodes.AddRange(treeNodeWithSettings);
            }
            if (methodResultStatus == MethodResultStatus.Fault)
            {
                MessageBox.Show($"При чтении файла {fileInfo.FullName} произошла ошибка!");
            }
        }
        private void DoLastSelectedTreeNodeBackColorWhite()
        {
            if (LastSelectedTreeNode != null)
            {
                LastSelectedTreeNode.BackColor = Color.White;
            }
        }
    }
}