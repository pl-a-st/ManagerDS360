﻿using System;
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
        static CancellationTokenSource CancelTokenSource = new CancellationTokenSource();
        CancellationToken TokenForTest = CancelTokenSource.Token;
        static CancellationTokenSource CancelTokenConnect = new CancellationTokenSource();
        CancellationToken TokenForConnect = CancelTokenConnect.Token;
        static string LastRouteName = string.Empty;
        public frmCreationVibroCalibSetting FrmVibroCalib = new frmCreationVibroCalibSetting();
        public frmManagerDS360()
        {
            InitializeComponent();
        }
        internal async void frmManagerDS360_Load(object sender, EventArgs e)
        {
#if DEBUG
            mnuForTest.Visible = true;
#endif
            LoadCboSavedRoutes();
            //await SetDefaultDS360();
            SetToolTipes();
            await SetTestedDevicesList();
            cboTestedDevice.SelectedIndexChanged += CboTestedDevice_SelectedIndexChanged;
            frmDevicePlugIn frmDevicePlugIn = new frmDevicePlugIn();
            frmDevicePlugIn.ShowDialog();
            VibrationStand.StatusHasChanged += VibrationStand_StatusHasChanged;
        }

        private void VibrationStand_StatusHasChanged(VibStendInfo info)
        {
            BeginInvoke(new Action(() => PushInfoAboutStend(info)));
        }

        private void PushInfoAboutStend(VibStendInfo info)
        {
            int MaxWidth = grpStend.Width;
            lblVibCalibStatus.Text = PmData.VibStendStatus[info.VibStendStatus];
            lblFreq.Text ="F: " + info.Frequency.Get_Hz().ToString() + " Гц";
            lblParametrToHold.Text = PmData.Detector[(Detector)info.Detector] + ": " + info.ParametrToHold.Get(info.Detector).ToString() + " " + PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, info.ParametrToHold)];
            lblCurentParametr.Text = PmData.Detector[(Detector)info.Detector] + ": " + info.CurrentParametr.Get(info.Detector).ToString() + " " + PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, info.CurrentParametr)];
            lblParametrToHold.Location = new Point(MaxWidth / 2 - lblParametrToHold.Width / 2, lblParametrToHold.Location.Y);
            lblFreq.Location = new Point(MaxWidth / 2 - lblFreq.Width / 2, lblFreq.Location.Y);
            lblVibCalibStatus.Location = new Point(MaxWidth / 2  - lblVibCalibStatus.Width / 2, lblVibCalibStatus.Location.Y);
            lblCurentParametr.Location = new Point(MaxWidth / 2 - lblCurentParametr.Width / 2, lblCurentParametr.Location.Y);
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
            Task task = null;
            var client = ManagerDC23.Client;

            if (PmData.GetEnumFromString(PmData.TestedDevice, cboTestedDevice.Text) == TestedDevice.DC23)
            {
                CancelTokenConnect.Dispose();
                CancelTokenConnect = new CancellationTokenSource();
                TokenForConnect = CancelTokenConnect.Token;

                task = new Task(() => client.Connect(TokenForConnect), TokenForConnect);
                LastRouteName = string.Empty;
                client.ConnectedEvent += Client_ConnectedEvent;
                client.DisconnectedEvent += Client_DisconnectedEvent;

                Invoke(new Action(() =>
                    {
                        lblTestedDevice.ForeColor = Color.Black;
                        lblTestedDevice.Text = "Устанавливается соединение...";
                    }));
                //thr.Start();
                task.Start();
            }
            if (PmData.GetEnumFromString(PmData.TestedDevice, cboTestedDevice.Text) == TestedDevice.None)
            {
                CancelTokenConnect.Cancel();
                do
                {
                    client.Disconnect();


                }
                while (client.Connected);
                client.CancelConnecting();
                while (task != null && task.Status == TaskStatus.Running)
                {
                    Task.Delay(100);
                }
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
                try
                {
                    client.ConnectedEvent -= Client_ConnectedEvent;
                }
                catch { }
                try
                {
                    client.DisconnectedEvent -= Client_DisconnectedEvent;
                }
                catch { }
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
            var client = ManagerDC23.Client;
            if (client != null && client.Connected)
            {
                client.Disconnect();
                client.CancelConnecting();
            }
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
        private Result SendNodeSetting()
        {
            TreeNodeWithSetting selectedNode = null;
            Invoke(new Action(() => { selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting; }));
            if (selectedNode == null)
            {
                return Result.Success;
            }
            if (selectedNode.NodeType == NodeType.Folder)
            {
                return Result.Success;
            }
            if (selectedNode.NodeType == NodeType.Setting)
            {
                return MakeOperationsForDS360(selectedNode);
            }
            if (selectedNode.NodeType == NodeType.DC23)
            {
                return MakeOperationForDC23(selectedNode);
            }
            if (selectedNode.NodeType == NodeType.Message)
            {
                return MakeOperationsForMessge(selectedNode);
            }
            if (selectedNode.NodeType == NodeType.VibroStand)
            {
                return MakeOperationsForVibroStend(selectedNode);
            }
            return Result.Success;
        }
        private Result MakeOperationsForMessge(TreeNodeWithSetting selectedNode)
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(
                      this,
                      selectedNode.Text,
                      "Сообщение",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1);
                selectedNode.ImageIndex = 9;
                selectedNode.SelectedImageIndex = 9;
            }));
            if (selectedNode.StopTest)
            {
                return Result.Failure;
            }
            return Result.Success;
        }
        private Result MakeOperationForDC23(TreeNodeWithSetting selectedNode)
        {
            if (ManagerDC23.Client == null || !ManagerDC23.Client.Connected)
            {
                AcyncShowMassageAndChangePicture("Отсутсвует соединение!", selectedNode);
                return Result.Failure;
            }
            if (LastRouteName != selectedNode.DC23.RouteName)
            {
                if (selectedNode.DC23.OpenRoute() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture($"Не удалось открыть маршрут: {selectedNode.DC23.GetRouteNameWithoutCharProtection()}", selectedNode);
                    return Result.Failure;
                }
                LastRouteName = selectedNode.DC23.RouteName;
                Thread.Sleep(1000);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                return Result.Canceled;
            }
            if (!string.IsNullOrEmpty(selectedNode.DC23.СhannelFirstAddress))
            {
                if (selectedNode.DC23.SetChannelFirst() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture("Не удалось привязать канал А", selectedNode);
                    return Result.Failure;
                }
                Thread.Sleep(300);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                return Result.Canceled;
            }
            if (!string.IsNullOrEmpty(selectedNode.DC23.СhannelSecondAddress))
            {
                if (selectedNode.DC23.SetChannelSecond() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture("Не удалось привязать канал В", selectedNode);
                    return Result.Failure;
                }
                Thread.Sleep(300);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                return Result.Canceled;
            }
            if (selectedNode.DC23.Meas() != ResultCommandDC23.Success)
            {
                AcyncShowMassageAndChangePicture("Не удалось произвести измерение", selectedNode);
                return Result.Failure;
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                return Result.Canceled;
            }
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 7;
                selectedNode.SelectedImageIndex = 7;
            }));
            return Result.Success;
        }

        private void AcyncShowMassageAndChangePicture(string massege, TreeNodeWithSetting selectedNode)
        {
            BeginInvoke(new Action(() =>
            {
                MessageBox.Show(
                   this,
                   massege,
                   "Предупреждение",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning,
                   MessageBoxDefaultButton.Button1);
                selectedNode.ImageIndex = 6;
                selectedNode.SelectedImageIndex = 6;
            }));
        }
        private Result MakeOperationsForVibroStend(TreeNodeWithSetting selectedNode)
        {
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 11;
                selectedNode.SelectedImageIndex = 11;
            }));
            if (selectedNode.VibrationStand.RunStend() != Result.Success)
            {
                BeginInvoke(new Action(() =>
                {
                    //MessageBox.Show(
                    //   this,
                    //   selectedNode.DS360Setting.ResultMessage,
                    //   "Предупреждение",
                    //   MessageBoxButtons.OK,
                    //   MessageBoxIcon.Warning,
                    //   MessageBoxDefaultButton.Button1);
                    selectedNode.ImageIndex = 12;
                    selectedNode.SelectedImageIndex = 12;
                }));
                return Result.Failure;
            }
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 13;
                selectedNode.SelectedImageIndex = 13;
            }));
            return Result.Success;
        }
        private Result MakeOperationsForDS360(TreeNodeWithSetting selectedNode)
        {
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 2;
                selectedNode.SelectedImageIndex = 2;
            }));
            if (selectedNode.DS360Setting.SendDS360Setting() != Result.Success)
            {
                BeginInvoke(new Action(() =>
                {
                    MessageBox.Show(
                       this,
                       selectedNode.DS360Setting.ResultMessage,
                       "Предупреждение",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning,
                       MessageBoxDefaultButton.Button1);
                    selectedNode.ImageIndex = 3;
                    selectedNode.SelectedImageIndex = 3;
                }));
                return Result.Failure;
            }
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 4;
                selectedNode.SelectedImageIndex = 4;
            }));
            return Result.Success;
        }

        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavedRoutes.SelectedIndex == -1)
            {
                return;
            }
            LastRouteName = string.Empty;
            treRouteTree.Nodes.Clear();
            treRouteTree.LoadTreeNodesWithSeetings(PmData.RouteAddresses[cboSavedRoutes.SelectedIndex]);
            foreach (TreeNode node in treRouteTree.Nodes)
            {
                node.Checked = true;
            }
            if (treRouteTree.Nodes.Count > 0)
            {
                treRouteTree.SelectedNode = treRouteTree.Nodes[0];
            }
            treRouteTree.Focus();
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
            InsertControlsForWating(panel, new ProgressBar(), new Label());
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
        private void InsertControlsForWating(Panel panel, ProgressBar progressBar, Label label)
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
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Folder)
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
            //записан в Load формы
        }

        private void buttonForPicture1_VisibleChanged(object sender, EventArgs e)
        {
            butStopTest.ImageList.Images.Add(Properties.Resources.Стоп_серый);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        enum TestStatus
        {
            Started,
            Stoped
        }
        private async void butStartTest_Click(object sender, EventArgs e)
        {
            //LastRouteName = string.Empty;
            butStopTest.Click += butStop_Click;
           
            Task taskSend = new Task(SendAllChacked, TokenForTest);
            taskSend.Start();
            SetLocationLblTestStatus("Идет испытание!!!");
            Task taskBlink = new Task((Action)(() => LblTestBlink(taskSend)));
            taskBlink.Start();
            SetControlsEnabledForTest(TestStatus.Started);
        }

        private void SetLocationLblTestStatus(string message)
        {
            lblTestStatus.Text = message;
            lblTestStatus.Location = new Point(
                grpTest.Location.X + grpTest.Width / 2 - lblTestStatus.Width / 2,
                lblTestStatus.Location.Y);
        }

        private async void LblTestBlink(Task task)
        {
            while (task.Status == TaskStatus.Running)
            {
                await Task.Delay(500);
                BeginInvoke((Action)(() => { lblTestStatus.Visible = !lblTestStatus.Visible; }));
            }
            BeginInvoke((Action)(() => { lblTestStatus.Visible = true; }));
        }
        private void SetControlsEnabledForTest(TestStatus testStatus)
        {
            bool enabled = false;
            if (testStatus == TestStatus.Started)
            {
                enabled = false;
            }
            if (testStatus == TestStatus.Stoped)
            {
                enabled = true;
            }
            foreach (Control control in splitContainer1.Panel1.Controls)
            {
                control.Enabled = enabled;
            }
            foreach (Control control in splitContainer1.Panel2.Controls)
            {
                control.Enabled = enabled;
            }
            butStopTest.Enabled = true;
            lblTestStatus.Enabled = true;
            grpStend.Enabled = true;
        }

        private void SendAllChacked()
        {
            List<TreeNode> chackedNode = new List<TreeNode>();
            bool doOnlyAfterSelected = true;
            GetChakedNodes(chackedNode, treRouteTree.Nodes, ref doOnlyAfterSelected);
            if (chackedNode.Count == 0)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show(
                          this,
                          "Не выбран узел для начала испытаний",
                          "Сообщение",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information,
                          MessageBoxDefaultButton.Button1);
                }));
            }
            foreach (TreeNode node in chackedNode)
            {
                if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
                {
                    return;
                }
                BeginInvoke(new Action(() => { treRouteTree.SelectedNode = node; }));
                Result result = SendNodeSetting();
                if (result != Result.Success)
                {
                    if (result == Result.Canceled)
                    {
                        return;
                    }
                    CancelTokenSource.Dispose();
                    CancelTokenSource = new CancellationTokenSource();
                    TokenForTest = CancelTokenSource.Token;
                    BeginInvoke(new Action(() => { SetLocationLblTestStatus("Испытание остановлено"); }));
                    BeginInvoke(new Action(() => { SetControlsEnabledForTest(TestStatus.Stoped); }));
                    butStopTest.Click -= butStop_Click;
                    return;
                }
                if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
                {
                    return;
                }
                Thread.Sleep(300);
            }
            BeginInvoke(new Action(() => { SetLocationLblTestStatus("Испытание закончено"); }));
            BeginInvoke(new Action(() => { SetControlsEnabledForTest(TestStatus.Stoped); }));
            butStopTest.Click -= butStop_Click;
            LastRouteName = string.Empty;
        }
        public enum TokenStatus
        {
            InWork,
            Canceled
        }
        private TokenStatus IsTokenCancelAndServiceCancel()
        {
            if (TokenForTest == null)
            {
                return TokenStatus.Canceled;
            }
            if (TokenForTest.IsCancellationRequested)
            {
                CancelTokenSource.Dispose();
                CancelTokenSource = new CancellationTokenSource();
                TokenForTest = CancelTokenSource.Token;
                BeginInvoke(new Action(() =>
                {
                    SetVisualForStop();
                }));
                butStopTest.Click -= butStop_Click;
                //LastRouteName = string.Empty;
                return TokenStatus.Canceled;
            }
            return TokenStatus.InWork;
        }

        private void SetVisualForStop()
        {
            MessageBox.Show(
               this,
               "Измерение прервано пользователем",
               "Сообщение", MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1);
            treRouteTree.Enabled = true;
            SetLocationLblTestStatus("Испытание прервано\n пользователем");
            SetControlsEnabledForTest(TestStatus.Stoped);
        }
        private void GetChakedNodes(List<TreeNode> chackedNode, TreeNodeCollection nodes, ref bool doOnlyAfterSelected)
        {
            foreach (TreeNode node in nodes)
            {
                bool isSelected = false;
                Invoke((Action)(() => { isSelected = node.IsSelected; }));
                if (isSelected)
                {
                    doOnlyAfterSelected = false;
                }
                if (!doOnlyAfterSelected && node.Checked)
                {
                    chackedNode.Add(node);
                }
                if (node.Nodes.Count > 0)
                {
                    GetChakedNodes(chackedNode, node.Nodes, ref doOnlyAfterSelected);
                }
            }
        }
        private void butStop_Click(object sender, EventArgs e)
        {
            CancelTokenSource.Cancel();
            SetLocationLblTestStatus("Идет остановка \n испытания!!!");
            butStopTest.Click -= butStop_Click;
        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }

        private void butStopTest_Click(object sender, EventArgs e)
        {
            //привязываетсяя в методе butStartTest_Click
        }

        private void mnuInfo_Click(object sender, EventArgs e)
        {

        }

        private void treRouteTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SendNodeSetting();
        }

        private void butVibCalibStop_Click(object sender, EventArgs e)
        {
            VibrationStand.Generator.SetOutputOff();
            if (VibrationStand.IsTesting)
            {
                VibrationStand.StopTest();
            }
           
        }

        private void butVibCalibSetting_Click(object sender, EventArgs e)
        {
            FrmVibroCalib.CallType = CallType.Control;

            FrmVibroCalib.TopLevel = true;
            if (FrmVibroCalib.Visible)
            {
                FrmVibroCalib.Visible = false;
            }
            else
            {
                
                FrmVibroCalib.StartPosition = FormStartPosition.CenterParent;

                
                FrmVibroCalib.Show(this);
               
            }
        }
    }
}
