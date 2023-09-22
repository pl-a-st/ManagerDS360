using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibControls;
using LibDevicesManager;
using LibDevicesManager.DC23;
using Vast.DC23.DataTransferClient;


namespace ManagerDS360
{
    public partial class frmManagerDS360 : Form
    {
        public frmManagerDS360()
        {
            InitializeComponent();
        }
        internal async void frmManagerDS360_Load(object sender, EventArgs e)
        {
            LoadCboSavedRoutes();
            await SetDefaultDS360();
            SetToolTipes();
            await SetTestedDevicesList();
            cboTestedDevice.SelectedIndexChanged += CboTestedDevice_SelectedIndexChanged;
        }
       
        private async Task SetTestedDevicesList()
        {
            await Task.Delay(10);
            var elements = PmData.TestedDevice.Values.ToArray();
            cboTestedDevice.BeginUpdate();
            cboTestedDevice.Items.AddRange(elements);
            cboTestedDevice.SelectedIndex = (int)TestedDevice.None;
            cboTestedDevice.EndUpdate();
        }

        private void CboTestedDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = ManagerDC23.Client;
            if (PmData.GetEnumFromString(PmData.TestedDevice,cboTestedDevice.Text)== TestedDevice.DC23)
            {
                
                client.ConnectedEvent += Client_ConnectedEvent;
                client.DisconnectedEvent += Client_DisconnectedEvent;
                Thread thr = new Thread(() => client.Connect());
                thr.IsBackground = true;
                Invoke(new Action (() =>
                {
                    lblTestedDevice.ForeColor = Color.Black;
                    lblTestedDevice.Text = "Устанавливается соединение...";
                }));
                thr.Start();
            }
            if (PmData.GetEnumFromString(PmData.TestedDevice, cboTestedDevice.Text) == TestedDevice.None)
            {
                client.Disconnect();
                client.CancelConnecting();
            }
        }

        private void Client_DisconnectedEvent(object sender, EventArgs e)
        {
            var client = ManagerDC23.Client;
            Invoke(new Action(() =>
            {
                lblTestedDevice.ForeColor = Color.Red;
                lblTestedDevice.Text = "Соединение разорвано";
                cboTestedDevice.SelectedIndex = (int)TestedDevice.None;
                client.ConnectedEvent -= Client_ConnectedEvent;
                client.DisconnectedEvent -= Client_DisconnectedEvent;
            }));
            
        }

        private void Client_ConnectedEvent(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblTestedDevice.ForeColor = Color.Green;
                lblTestedDevice.Text = "Соединение установлено";
            }));
            
        }

        private void frmManagerDS360_Closing(object sender, FormClosingEventArgs e)
        {
        }
        internal void butDefaultGenerator_Click(object sender, EventArgs e)
        {
            SetDefaultGenerator();
        }
        private void SetDefaultGenerator()
        {
            frmManagerRoutse frmDefaultGenerator = new frmManagerRoutse();
            frmDefaultGenerator.ShowDialog();
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            butDefaultGenerator.Text = $"Генератор {name}";
        }
        private void butGeneratorControl_Click(object sender, EventArgs e)
        {
            ControlGenerator();
        }
        private static void ControlGenerator()
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = CallType.Control;
            editingSettings.Text = "Отправка настройки в генератор";
            editingSettings.ShowDialog();
        }
        private void SendNodeSetting()
        {
            var selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            if (selectedNode == null)
            {
                return;
            }
            if (selectedNode.NodeType != NodeType.Setting)
            {
                return;
            }
            selectedNode.ImageIndex = 2;
            selectedNode.SelectedImageIndex = 2;
            if (selectedNode.DS360Setting.SendDS360Setting() != Result.Success)
            {
                MessageBox.Show(selectedNode.DS360Setting.ResultMessage);
                selectedNode.ImageIndex = 3;
                selectedNode.SelectedImageIndex = 3;
                return;
            }
            selectedNode.ImageIndex = 4;
            selectedNode.SelectedImageIndex = 4;
        }
        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavedRoutes.SelectedIndex == -1)
            {
                return;
            }
            treRouteTree.Nodes.Clear();
            treRouteTree.LoadTreeNodesWithSeetings(PmData.RouteAddresses[cboSavedRoutes.SelectedIndex]);
            if (treRouteTree.Nodes.Count > 0)
            {
                treRouteTree.SelectedNode = treRouteTree.Nodes[0];
            }
        }
        private void SetToolTipes()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 100;
            toolTip.ReshowDelay = 100;

            toolTip.SetToolTip(this.butGeneratorControl, "CTRL+G");
            toolTip.SetToolTip(this.butDefaultGenerator, "CTRL+D");
            toolTip.SetToolTip(this.butNext, "Space");
            toolTip.SetToolTip(this.butPrevious, "CTRL+Space");
            toolTip.SetToolTip(this.butPlay, "Enter");

            mnuAboutProgram.MouseEnter += MnuAboutProgram_MouseEnter;
            void MnuAboutProgram_MouseEnter(object sender, EventArgs e)
            {
                toolTip.Show("CTRL+I", this, Cursor.Position.X - this.Location.X + 10, Cursor.Position.Y - this.Location.Y + 10);
            }
            mnuAboutProgram.MouseLeave += MnuAboutProgram_MouseLeave;
            void MnuAboutProgram_MouseLeave(object sender, EventArgs e)
            {
                toolTip.Hide(this);
            }
            // ToDo! Подключить после реализации Help
            //mnuHelp.MouseEnter += MnuHelp_MouseEnter;
            //void MnuHelp_MouseEnter(object sender, EventArgs e)
            //{
            //    toolTip.Show("CTRL+О", this, Cursor.Position.X - this.Location.X + 10, Cursor.Position.Y - this.Location.Y + 10);
            //}
            //mnuHelp.MouseLeave += MnuHelp_MouseLeave;
            //void MnuHelp_MouseLeave(object sender, EventArgs e)
            //{
            //    toolTip.Hide(this);
            //}
        }
        private async Task SetDefaultDS360()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }
            Panel panel = new Panel();
            InsertControls(panel, new ProgressBar(), new Label());
            Task getComes = new Task(() => DS360Setting.SetFirstDS360AsDefault());
            await Task.Run(() => getComes.Start());
            await Task.Run(() => getComes.Wait());
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            butDefaultGenerator.Text = $"Генератор {name}";
            panel.Dispose();
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
        }
        private void InsertControls(Panel panel, ProgressBar progressBar, Label label)
        {
            panel.Height = (int)(this.Height / 3);
            panel.Width = (int)(this.Width / 2);
            panel.BackColor = Color.DarkGray;
            panel.Location = new Point(
                x: this.Width / 2 - panel.Width / 2,
                y: this.Height / 2 - panel.Height / 2);
            progressBar.Width = this.Width / 3;
            progressBar.Height = this.Height / 6;
            progressBar.Location = new Point(
                x: panel.Width / 2 - progressBar.Width / 2,
                y: panel.Height / 2 - progressBar.Height / 2);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 1;
            label.AutoSize = true;
            label.Font = new Font("Verdana", 9, FontStyle.Regular);
            label.Text = "Идет поиск генераторов";
            label.BackColor = Color.Transparent;
            label.Parent = progressBar;
            label.Location = new Point(
                x: panel.Width / 2 - label.PreferredWidth / 2,
                y: progressBar.Location.Y - label.Height);
            panel.Controls.Add(progressBar);
            panel.Controls.Add(label);
            this.Controls.Add(panel);
            panel.BringToFront();
            progressBar.BringToFront();
            label.BringToFront();
        }
        private void LoadCboSavedRoutes()
        {
            treRouteTree.Nodes.Clear();
            cboSavedRoutes.Items.Clear();
            FileInfo[] routes = PmData.RouteAddresses.ToArray();
            string[] fileNames = new string[routes.Length];
            for (int i = 0; i < routes.Length; i++)
            {
                fileNames[i] = routes[i].Name.Replace(routes[i].Extension, "");
            }
            cboSavedRoutes.Items.AddRange(fileNames);
            if (cboSavedRoutes.Items.Count > 0)
            {
                cboSavedRoutes.SelectedIndex = 0;
            }
        }
        private void cboSavedRoutes_Click(object sender, EventArgs e)
        {
            cboSavedRoutes.DroppedDown = true;
        }
        private void mnuEditingRoutes_Click(object sender, EventArgs e)
        {
            EditRoutes();
        }
        private void EditRoutes()
        {
            frmEditingRoutes editingRoutes = new frmEditingRoutes();
            editingRoutes.ShowDialog();
            LoadCboSavedRoutes();
        }
        private TreeNode GetNextParentNode(TreeNode selectedNode)
        {
            if (selectedNode.Parent is TreeNode)
            {
                if (selectedNode.Parent.NextNode != null)
                {
                    return selectedNode.Parent.NextNode;
                }
                return GetNextParentNode(selectedNode.Parent);
            }
            return selectedNode;
        }
        private void butNext_Click(object sender, EventArgs e)
        {
            SendNextNodeSetting();
        }
        private void SendNextNodeSetting()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectNextSetting();
            SendNodeSetting();
        }
        private void SelectNextSetting()
        {
            if (treRouteTree.SelectedNode.NextVisibleNode == null)
            {
                return;
            }
            if (!treRouteTree.SelectedNode.NextVisibleNode.IsExpanded)
            {
                treRouteTree.SelectedNode.NextVisibleNode.Expand();
            }
            treRouteTree.SelectedNode = treRouteTree.SelectedNode.NextVisibleNode;
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Setting)
            {
                SelectNextSetting();
            }
        }
        private void SelectPreviousSetting()
        {
            if (treRouteTree.SelectedNode.PrevVisibleNode == null)
            {
                return;
            }
            if (!treRouteTree.SelectedNode.PrevVisibleNode.IsExpanded)
            {
                treRouteTree.SelectedNode.PrevVisibleNode.Expand();
            }
            treRouteTree.SelectedNode = treRouteTree.SelectedNode.PrevVisibleNode;
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Setting)
            {
                SelectPreviousSetting();
            }
        }
        private void butNext_MouseEnter(object sender, EventArgs e)
        {
            butNext.BackgroundImage = Properties.Resources.следующий_2;
        }
        private void butNext_MouseLeave(object sender, EventArgs e)
        {
            butNext.BackgroundImage = Properties.Resources.следующий;
        }
        private void butNext_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butNext);
        }
        private void SetButClikSize(Button but)
        {
            but.Location = new Point(but.Location.X + 1, but.Location.Y + 1);
            but.Size = new Size(but.Width - 2, but.Height - 2);
        }
        private void butNext_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butNext);
        }
        private void SetButAfterClickSize(Button but)
        {
            but.Location = new Point(but.Location.X - 1, but.Location.Y - 1);
            but.Size = new Size(but.Width + 2, but.Height + 2);
        }
        private void butPrevious_Click(object sender, EventArgs e)
        {
            SendPreviousNodeSetting();
        }
        private void SendPreviousNodeSetting()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectPreviousSetting();
            SendNodeSetting();
        }
        private void butPrevious_MouseEnter(object sender, EventArgs e)
        {
            butPrevious.BackgroundImage = Properties.Resources.предыдущий_2;
        }
        private void butPrevious_MouseLeave(object sender, EventArgs e)
        {
            butPrevious.BackgroundImage = Properties.Resources.предыдущий;
        }
        private void butPrevious_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butPrevious);
        }
        private void butPrevious_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butPrevious);
        }
        private void butPlay_Click(object sender, EventArgs e)
        {
            SendNodeSetting();
        }
        private void butPlay_MouseEnter(object sender, EventArgs e)
        {
            butPlay.BackgroundImage = Properties.Resources.Play2;
        }
        private void butPlay_MouseLeave(object sender, EventArgs e)
        {
            butPlay.BackgroundImage = Properties.Resources.Play;
        }
        private void butPlay_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butPlay);
        }
        private void butPlay_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butPlay);
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowAboutProgram();
        }
        private static void ShowAboutProgram()
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            var buildDateTime = new DateTime(2000, 1, 1).Add(
                new TimeSpan(TimeSpan.TicksPerDay * version.Build + TimeSpan.TicksPerSecond * 2 * version.Revision));
            MessageBox.Show(
                $"Мanager DS360. Версия ПО {version.ToString()}\n  Дата разработки - {buildDateTime.ToShortDateString()}.",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.G)    // управление
            {
                ControlGenerator();
                return;
            }
            if (e.Control == true && e.KeyCode == Keys.D)    // по умолчанию
            {
                SetDefaultGenerator();
                return;
            }
            if (e.Control == true && e.KeyCode == Keys.H)
            {
                EditRoutes();
                return;
            }
            if (e.Control == true && e.KeyCode == Keys.I)    // инфо
            {
                ShowAboutProgram();
                return;
            }
            if (e.Control == true && e.KeyCode == Keys.O)    // руководство
            {
                //StripMenuItem1();
            }
            if (e.KeyCode == Keys.Enter)    // запуск
            {
                if (this.treRouteTree.Focused || this.Focused)
                    SendNodeSetting();
                e.Handled = true;
                return;
            }
            if (e.Control == true && e.KeyCode == Keys.Space)    // назад
            {
                SendPreviousNodeSetting();
                e.Handled = true;
                return;
            }
            if (e.KeyCode == Keys.Space)    // далее
            {
                e.Handled = true;
                SendNextNodeSetting();
            }
        }
        private void butLable_MouseEnter(object sender, EventArgs e)
        {
            butLable.BackgroundImage = Properties.Resources.Логотип_ВАСТ_темный;
        }
        private void butLable_MouseLeave(object sender, EventArgs e)
        {
            butLable.BackgroundImage = Properties.Resources.Логотип_ВАСТ;
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void butLable_Click(object sender, EventArgs e)
        {

            frmAboutAuthors frmAboutAuthors = new frmAboutAuthors();
            frmAboutAuthors.TopMost = true;
            frmAboutAuthors.Left = this.Left + this.Width / 2 - frmAboutAuthors.WithMax / 2;
            frmAboutAuthors.Top = this.Top + this.Height / 2 - frmAboutAuthors.WithMax / 2 + frmAboutAuthors.Height / 2;
            frmAboutAuthors.ShowDialog();
        }

        private void тестОбменаДаннымиССД23ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestExchangeDC23 frmTestExchangeDC23 = new frmTestExchangeDC23();
            frmTestExchangeDC23.ShowDialog();
            frmTestExchangeDC23.Dispose();
        }

        private void cboTestedDevice_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
