using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;
using LibDevicesManager.DC23;
using ManagerDS360;

namespace LibControls
{
    public class ButtonForPicture : Button
    {
        List<Image> Images = new List<Image>();
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.CheckedBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            ImageList images = new ImageList();
            this.ImageList = images;
            this.ImageList.ImageSize = new Size(256, 256);
            this.BackColor = Color.Transparent;
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            
            if (Images.Count == 0 && this.BackgroundImage != null)
            {
                Images.Add(this.BackgroundImage);
                Images.Add(DoDark(new Bitmap(this.BackgroundImage)));
            }
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.Location = new Point(this.Location.X + 1, this.Location.Y + 1);
            this.Size = new Size(this.Width - 2, this.Height - 2);
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.Location = new Point(this.Location.X - 1, this.Location.Y - 1);
            this.Size = new Size(this.Width + 2, this.Height + 2);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (Images.Count > 1)
            {
                this.BackgroundImage = Images[1];
            }
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (Images.Count > 0)
            {
                this.BackgroundImage = Images[0];
            }
        }
        private Bitmap DoDark(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color p = bmp.GetPixel(i, j);
                    int a = p.A;
                    if (a == 0)
                    {
                        continue;
                    }
                    int r = p.R - 20;
                    int g = p.G - 20;
                    int b = p.B - 20;
                    if (r < 0)
                        r = 0;
                    if (g < 0)
                        g = 0;
                    if (b < 0)
                        b = 0;
                    bmp.SetPixel(i, j, Color.FromArgb(a, r, g, b));
                }
            }
            return bmp;
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
        Setting,
        DC23,
        Message
    }
    [Serializable]
    public class TreeNodeWithSetting : TreeNode
    {
        public TreeNodeWithSetting(string text)
        {
            Text = text;
        }
        public NodeType NodeType;
        public DS360SettingVibroSigParam DS360Setting = new DS360SettingVibroSigParam();
        public ManagerDC23 DC23 = new ManagerDC23();
        public Boolean StopTest = false;
        public TreeNodeWithSetting(NodeType nodeType, string text)
        {
            this.NodeType = nodeType;
            SetImage();
            Text = text;
        }
        protected TreeNodeWithSetting(SerializationInfo info, StreamingContext context)
        {
            List<Action> actions = new List<Action>();
            TreeNodeWithSetting[] test = new TreeNodeWithSetting[1];
            TreeNodeWithSetting[] treeNodeWithSettings;
            actions.Add(() => this.Text = (string)info.GetValue("NodeText", this.Text.GetType()));
            actions.Add(() => this.DS360Setting = (DS360SettingVibroSigParam)info.GetValue("DS360Setting", this.DS360Setting.GetType()));
            actions.Add(() => this.NodeType = (NodeType)info.GetValue("NodeType", this.NodeType.GetType()));
            actions.Add(() =>
                {
                    treeNodeWithSettings = (TreeNodeWithSetting[])info.GetValue("treeNodeWithSettings", test.GetType());
                    foreach (var node in treeNodeWithSettings)
                    {
                        this.Nodes.Add(node);
                    }
                });
            actions.Add(() =>
                {
                    if ((bool)info.GetValue("IsExpand", this.IsExpanded.GetType()))
                    {
                        this.Expand();
                    }
                });
            actions.Add(() => SetImage());
            actions.Add(() => this.DC23 = (ManagerDC23)info.GetValue("DC23", this.DC23.GetType()));
            actions.Add(() => this.StopTest = (bool)info.GetValue("StopTest", this.StopTest.GetType()));
            foreach (Action action in actions)
            {
                try
                {
                    action();
                }
                catch
                {

                }

            }
        }


        protected override void Deserialize(SerializationInfo serializationInfo, StreamingContext context)
        {
            base.Deserialize(serializationInfo, context);
        }
        protected override void Serialize(SerializationInfo si, StreamingContext context)
        {
            base.Serialize(si, context);
            si.AddValue("DC23", this.DC23);
            si.AddValue("NodeText", this.Text);
            si.AddValue("DS360Setting", this.DS360Setting);
            si.AddValue("NodeType", this.NodeType);
            SetImage();
            TreeNodeWithSetting[] treeNodeWithSettings = new TreeNodeWithSetting[this.Nodes.Count];
            this.Nodes.CopyTo(treeNodeWithSettings, 0);
            si.AddValue("treeNodeWithSettings", treeNodeWithSettings);
            si.AddValue("IsExpand", this.IsExpanded);
            si.AddValue("StopTest", this.StopTest);
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
            if (NodeType == NodeType.DC23)
            {
                this.ImageIndex = 5;
                this.SelectedImageIndex = 5;
            }
            if (NodeType == NodeType.Message)
            {
                this.ImageIndex = 8;
                this.SelectedImageIndex = 8;
            }
        }
        public TreeNodeWithSetting Copy()
        {
            TreeNodeWithSetting treeNodeWithSetting = new TreeNodeWithSetting(this.NodeType, this.Text);
            treeNodeWithSetting.DS360Setting = DS360Setting.CloneObj();
            treeNodeWithSetting.DC23 = DC23.CloneObj();
            if (this.IsExpanded)
            {
                treeNodeWithSetting.Expand();
            }
            foreach (TreeNodeWithSetting node in this.Nodes)
            {
                treeNodeWithSetting.Nodes.Add(node.Copy());

            }
            return treeNodeWithSetting;
        }
    }
    [Serializable]
    public class TreeViewWithSetting : TreeView
    {
        public TreeNodeWithSetting CopyTreeNodeWithSetup;
        private TreeNode LastSelectedTreeNode;
        private bool _isChackingChaild = false;
        private bool _isChackingParant = false;
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
            ImageList.Images.Add(Properties.Resources.DC23_серый_);
            ImageList.Images.Add(Properties.Resources.DC23_красный);
            ImageList.Images.Add(Properties.Resources.DC23_зеленый);
            ImageList.Images.Add(Properties.Resources.Message_серый);
            ImageList.Images.Add(Properties.Resources.Message_зеленый);
        }
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            if (!_isChackingParant)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    _isChackingChaild = true;
                    node.Checked = e.Node.Checked;
                    _isChackingChaild = false;
                }
            }
            CheckParant(e.Node);
        }
        private void CheckParant(TreeNode node)
        {
            if (_isChackingChaild)
            {
                return;
            }
            if (node.Parent == null)
            {
                return;
            }
            if (!node.Checked)
            {
                _isChackingParant = true;
                node.Parent.Checked = false;
                _isChackingParant = false;
                return;
            }
            foreach (TreeNode ParantesNode in node.Parent.Nodes)
            {
                if (ParantesNode == node)
                {
                    continue;
                }
                if (!ParantesNode.Checked)
                {
                    _isChackingParant = true;
                    node.Parent.Checked = false;
                    _isChackingParant = false;
                    return;
                }
            }
            _isChackingParant = true;
            node.Parent.Checked = true;
            _isChackingParant = false;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) { m.Result = IntPtr.Zero; }
            else base.WndProc(ref m);
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

        public void CopySelectedNode()
        {
            TreeNodeWithSetting selectedNode = this.SelectedNode as TreeNodeWithSetting;
            if (selectedNode == null)
            {
                return;
            }

            CopyTreeNodeWithSetup = selectedNode.Copy();
        }
        public void PasteCopyTreeNode()
        {
            if (CopyTreeNodeWithSetup == null)
            {
                return;
            }
            TreeNodeWithSetting selectedNode = this.SelectedNode as TreeNodeWithSetting;
            if (selectedNode == null)
            {
                this.Nodes.Add(CopyTreeNodeWithSetup.Copy());
                return;
            }
            selectedNode.Nodes.Add(CopyTreeNodeWithSetup.Copy());
        }

    }
}