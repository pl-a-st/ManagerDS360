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
using AcroPDFLib;
using LibControls;
using LibDevicesManager;
using LibDevicesManager.DC23;
using Metrology;
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
        public frmDevicePlugIn FrmDevicePlugIn = new frmDevicePlugIn();
        public bool IsVibStendInWork = false;
        Task TaskLblStendBlink;
        Action DoLblStendBlink;
        int CountLblStendBlink = 0;
        bool IsLblStendBlink = false;
        public frmManagerDS360()
        {
            InitializeComponent();
        }
        internal async void frmManagerDS360_Load(object sender, EventArgs e)
        {
            PmData.MainForm = this;
#if DEBUG
            mnuForTest.Visible = true;
#endif
            LoadCboSavedRoutes();
            LoadCboSavadFreqResp();
            //await SetDefaultDS360();
            SetToolTipes();
            await SetTestedDevicesList();
            cboTestedDevice.SelectedIndexChanged += CboTestedDevice_SelectedIndexChanged;
            FrmDevicePlugIn.ShowDialog();
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
            lblFreq.Text = "F: " + info.Frequency.Get_Hz().ToString() + " Гц";
            lblParametrToHold.Text = PmData.Detector[(Detector)info.Detector] + ": " + MetrologyRound.GetRounded(info.ParametrToHold.Get(info.Detector), 4).ToString() + " " + PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, info.ParametrToHold)];
            if (info.VibStendStatus == VibStendStatus.Stably || info.VibStendStatus == VibStendStatus.Correction)
            {
                lblCurentParametr.Text = PmData.Detector[(Detector)info.Detector] + ": " + MetrologyRound.GetRounded(info.CurrentParametr.Get(info.Detector), 4).ToString() + " " + PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, info.CurrentParametr)];
            }
            else
            {
                lblCurentParametr.Text = PmData.Detector[(Detector)info.Detector] + ": ---";
            }
            lblParametrToHold.Location = new Point(MaxWidth / 2 - lblParametrToHold.Width / 2, lblParametrToHold.Location.Y);
            lblFreq.Location = new Point(MaxWidth / 2 - lblFreq.Width / 2, lblFreq.Location.Y);
            lblVibCalibStatus.Location = new Point(MaxWidth / 2 - lblVibCalibStatus.Width / 2, lblVibCalibStatus.Location.Y);
            lblCurentParametr.Location = new Point(MaxWidth / 2 - lblCurentParametr.Width / 2, lblCurentParametr.Location.Y);
            if (info.VibStendStatus != VibStendStatus.Correction &&
                info.VibStendStatus != VibStendStatus.None &&
                info.VibStendStatus != VibStendStatus.NotStably &&
                info.VibStendStatus != VibStendStatus.SetupProcess &&
                info.VibStendStatus != VibStendStatus.Stably)
            {
                IsVibStendInWork = false;
            }
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
            if (DS360Setting.ConnectedCOMPort != null)
            {
                while (DS360Setting.ConnectedCOMPort.Count > 0)
                {
                    DS360Setting.DisconnectCOMPort(DS360Setting.ConnectedCOMPort[0].Port.PortName);
                }
            }
        }
        internal void butDefaultGenerator_Click(object sender, EventArgs e)
        {
            FrmDevicePlugIn.ShowDialog();
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
        private async Task<Result> SendNodeSetting()
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
                if (DS360Setting.ComPortDefaultName == GeneratorForVibCalib.Address)
                {
                    VibrationStandStopWork();
                }
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
                return await MakeOperationsForVibroStend(selectedNode);
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
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 14;
                selectedNode.SelectedImageIndex = 14;

            }));

            if (ManagerDC23.IsBeingMeasured)
            {
                AcyncShowMassageAndChangePicture("Уже запущено измерение, дождитесь завершения!", selectedNode);
                return Result.Failure;
            }
            ManagerDC23.IsBeingMeasured = true;
            if (ManagerDC23.Client == null || !ManagerDC23.Client.Connected)
            {
                AcyncShowMassageAndChangePicture("Отсутсвует соединение!", selectedNode);
                ManagerDC23.IsBeingMeasured = false;
                return Result.Failure;
            }
            if (LastRouteName != selectedNode.DC23.RouteName)
            {
                if (selectedNode.DC23.OpenRoute() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture($"Не удалось открыть маршрут: {selectedNode.DC23.GetRouteNameWithoutCharProtection()}", selectedNode);
                    ManagerDC23.IsBeingMeasured = false;
                    return Result.Failure;
                }
                LastRouteName = selectedNode.DC23.RouteName;
                Thread.Sleep(1000);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                ManagerDC23.IsBeingMeasured = false;
                return Result.Canceled;
            }
            if (!string.IsNullOrEmpty(selectedNode.DC23.СhannelFirstAddress))
            {
                if (selectedNode.DC23.SetChannelFirst() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture("Не удалось привязать канал А", selectedNode);
                    ManagerDC23.IsBeingMeasured = false;
                    return Result.Failure;
                }
                Thread.Sleep(300);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                ManagerDC23.IsBeingMeasured = false;
                return Result.Canceled;
            }
            if (!string.IsNullOrEmpty(selectedNode.DC23.СhannelSecondAddress))
            {
                if (selectedNode.DC23.SetChannelSecond() != ResultCommandDC23.Success)
                {
                    AcyncShowMassageAndChangePicture("Не удалось привязать канал В", selectedNode);
                    ManagerDC23.IsBeingMeasured = false;
                    return Result.Failure;
                }
                Thread.Sleep(300);
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                ManagerDC23.IsBeingMeasured = false;
                return Result.Canceled;
            }
            if (selectedNode.DC23.Meas() != ResultCommandDC23.Success)
            {
                AcyncShowMassageAndChangePicture("Не удалось произвести измерение", selectedNode);
                ManagerDC23.IsBeingMeasured = false;
                return Result.Failure;
            }
            if (IsTokenCancelAndServiceCancel() == TokenStatus.Canceled)
            {
                ManagerDC23.IsBeingMeasured = false;
                return Result.Canceled;
            }
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 7;
                selectedNode.SelectedImageIndex = 7;
            }));
            ManagerDC23.IsBeingMeasured = false;
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
        private async Task<Result> MakeOperationsForVibroStend(TreeNodeWithSetting selectedNode)
        {
            IsVibStendInWork = true;
            var runStend = selectedNode.VibrationStand.RunStend();
            TaskLblStendBlink = new Task((Action)(() => LblStendBlink(runStend)));
            TaskLblStendBlink.Start();
            BeginInvoke(new Action(() =>
            {
                selectedNode.ImageIndex = 11;
                selectedNode.SelectedImageIndex = 11;

            }));
            await runStend;
            while (!selectedNode.VibrationStand.IsSetupComplete)
            {
                await Task.Delay(100);
            }
            var qwe = ChangeSelectNode(selectedNode, runStend);
            qwe.Wait();
            var result = qwe.Result;
            return result;
        }

        private async Task<Result> ChangeSelectNode(TreeNodeWithSetting selectedNode, Task<Result> runStend)
        {
            IsVibStendInWork = true;


            if (runStend.Result != Result.Success)
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
            if (selectedNode.DS360Setting.SendDS360Setting() != Result.Success ||
                selectedNode.DS360Setting.SetOutputSignalOn() != Result.Success)
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
        private void LoadCboSavadFreqResp()
        {
            mnuCboFrequencyResponse.Items.Clear();

            FileInfo[] freqResp = PmData.FreqRespAddresses.ToArray();
            string[] fileNames = new string[freqResp.Length];
            for (int i = 0; i < freqResp.Length; i++)
            {
                fileNames[i] = freqResp[i].Name.Replace(freqResp[i].Extension, "");
            }
            mnuCboFrequencyResponse.Items.AddRange(fileNames);

            if (VibrationStand.CurentFreqResp.Count > 0)
                if (VibrationStand.CurentFreqResp.Name != null && mnuCboFrequencyResponse.Items.Contains(VibrationStand.CurentFreqResp.Name))
                {
                    mnuCboFrequencyResponse.SelectedItem = VibrationStand.CurentFreqResp.Name;

                }
            mnuCboFrequencyResponse.SelectedIndexChanged -= MnuCboFrequencyResponse_SelectedIndexChanged;
            mnuCboFrequencyResponse.SelectedIndexChanged += MnuCboFrequencyResponse_SelectedIndexChanged;
        }

        private void MnuCboFrequencyResponse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mnuCboFrequencyResponse.SelectedItem.ToString()))
            {
                VibrationStand.CurentFreqResp = new FrequencyResponse();
                MessageBox.Show("АЧХ не выбран");
                return;
            }
            if (!string.IsNullOrEmpty(mnuCboFrequencyResponse.SelectedItem.ToString()))
            {
                var FileCurentFreqResp = PmData.FreqRespAddresses[mnuCboFrequencyResponse.SelectedIndex];
                VibrationStand.CurentFreqResp = DAO.binReadFileToObject(VibrationStand.CurentFreqResp, FileCurentFreqResp.FullName, out _);
                PmData.SaveCurentFreqResp();
                MessageBox.Show($"Выбрано АЧХ: {FileCurentFreqResp.Name}");
                return;
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
        private async void SendNextNodeSetting()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectNextSetting();
            await SenNodeSettingAndShowStatus();
        }
        private void SelectNextSetting()
        {
            if (treRouteTree.SelectedNode.NextVisibleNode == null)
            {
                return;
            }
            if (!treRouteTree.SelectedNode.IsExpanded)
            {
                treRouteTree.SelectedNode.Expand();
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
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Folder)
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
        private async void SendPreviousNodeSetting()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectPreviousSetting();
            await SenNodeSettingAndShowStatus();
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
        private async void butPlay_Click(object sender, EventArgs e)
        {
            await SenNodeSettingAndShowStatus();
        }

        private async Task SenNodeSettingAndShowStatus()
        {
            Task taskSend = new Task((Action)(() => SendNodeSetting()));
            taskSend.Start();
            Task taskBlink = new Task((Action)(() => LblCommandBlink(taskSend)));
            taskBlink.Start();

            while (taskSend.Status == TaskStatus.Running)
            {
                await Task.Delay(100);
            }
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
            lblTestStatus.ForeColor = Color.DarkBlue;
            lblTestStatus.Text = message;
            lblTestStatus.Location = new Point(
                grpTest.Width / 2 - lblTestStatus.Width / 2,
                grpTest.Height - lblTestStatus.PreferredHeight - 5);
        }
        private void SetLocationLblCommandStatus(string message)
        {
            lblCommandStatus.Text = message;
            lblCommandStatus.Location = new Point(
                grpCommand.Width / 2 - lblCommandStatus.Width / 2,
                grpCommand.Height - lblCommandStatus.PreferredHeight - 5);
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
        private async void LblCommandBlink(Task task)
        {
            while (task.Status == TaskStatus.Running)
            {
                await Task.Delay(500);
                BeginInvoke((Action)(() =>
                {
                    SetLocationLblCommandStatus("Выполнение команды !!!");
                    lblCommandStatus.Visible = !lblCommandStatus.Visible;
                }));
            }
            BeginInvoke((Action)(() =>
            {
                SetLocationLblCommandStatus("Команда выполнена");
                lblCommandStatus.Visible = true;
            }));
        }
        private async void LblTestBlink(bool isRun)
        {
            while (isRun)
            {
                await Task.Delay(500);
                BeginInvoke((Action)(() => { lblTestStatus.Visible = !lblTestStatus.Visible; }));
            }
            BeginInvoke((Action)(() => { lblTestStatus.Visible = true; }));
        }
        public async void LblStendBlink(Task<Result> result)
        {
            CountLblStendBlink++;
            for (int i = 0; i < 100; i++)
            {
                if (!IsLblStendBlink)
                {
                    break;
                }
                Thread.Sleep(100);
            }
            if (IsLblStendBlink)
            {
                return;
            }
            IsLblStendBlink = true;
            do
            {
                await Task.Delay(500);
                BeginInvoke((Action)(() => { lblStendCurrent.Visible = !lblStendCurrent.Visible; }));
            }
            while (
                 VibrationStand.VibStendStatus != VibStendStatus.Finished &&
             VibrationStand.VibStendStatus != VibStendStatus.GeneratorProblem &&
              VibrationStand.VibStendStatus != VibStendStatus.MultimeterProblem &&
               VibrationStand.VibStendStatus != VibStendStatus.NotSensitive);
            BeginInvoke((Action)(() => { lblStendCurrent.Visible = true; }));
            IsLblStendBlink = false;
        }
        private void SetControlsEnabledForTest(TestStatus testStatus)
        {
            bool enabled = IsTestStatusStoped(testStatus);
            foreach (Control control in splitContainer1.Panel1.Controls)
            {
                control.Enabled = enabled;
            }
            foreach (Control control in splitContainer1.Panel2.Controls)
            {
                control.Enabled = enabled;
            }
            butVibCalibSetting.Enabled = enabled;
            butStopTest.Enabled = true;
            grpTest.Enabled = true;
            butStartTest.Enabled = enabled;
            lblTestStatus.Enabled = true;
            grpStend.Enabled = true;
        }

        private static bool IsTestStatusStoped(TestStatus testStatus)
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

            return enabled;
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
                Result result = SendNodeSetting().Result;
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
            VibrationStandStopWork();
            VibrationStand.Generator.SetOutputOff();
        }

        public void VibrationStandStopWork()
        {
            if (VibrationStand.IsTesting)
            {
                VibrationStand.StopWork();
            }
        }

        private void butVibCalibSetting_Click(object sender, EventArgs e)
        {
            if (VibrationStand.IsTesting)
            {
                VibrationStand.StopWork();
            }
            VibrationStand.Generator.SetOutputOff();
            FrmVibroCalib.CallType = CallType.Control;
            FrmVibroCalib.Text = "Управление вибрационной установкой";
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

        private void аЧХВибростендаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mnuCboFrequencyResponse.SelectedItem = "";
        }

        private void mnuSettingFrequencyResponse_Click(object sender, EventArgs e)
        {
            frmFreqResps frmFreqResps = new frmFreqResps();
            frmFreqResps.ShowDialog();
            LoadCboSavadFreqResp();
        }

        private void mnuCboFrequencyResponse_Click(object sender, EventArgs e)
        {
            // привязал в лоаде главной формы
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DS360Setting.CountCalls.ToString());
        }

        private void поискЗначенийСКЗНеПоддерживаемыDS360ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DS360Setting dS360Setting = new DS360Setting();
            double RMS = 1;
            double step = 0.001;
            List<double> errorList = new List<double>();
            while (RMS > 0.000005)
            {

                dS360Setting.AmplitudeRMS = RMS;

                for (int i = 0; i < 3; i++)
                {
                    Result result = dS360Setting.ChangeAmplitudeRMS();
                    if (result != Result.Success)
                    {
                        errorList.Add(RMS);
                        Thread.Sleep(2000);
                        break;
                    }
                }
                RMS -= step;
                RMS = MetrologyRound.GetRounded(RMS, 5);
                if (RMS <= step * 1000 && step >= 0.000001)
                {
                    step /= 10;
                }
            }
            frmInputName frmInputName = new frmInputName();
            foreach (double db in errorList)
            {
                frmInputName.txtNameSet.Text += " " + db;
            }
            frmInputName.ShowDialog();
        }

        private void проверкаКоррекцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInputName frmInput = new frmInputName();
            frmInput.ShowDialog();
            string value = DS360Setting.CorrectErroInPhysicalGenerator(frmInput.txtNameSet.Text);
            MessageBox.Show(value);
        }

        private void cboTestedDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            try
            {
                string fileFullPath = DAO.GetApplicationDataPath("Help.pdf");
                using (FileStream fileStream = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(Properties.Resources.Краткая_инструкция_по_автоматизации_поверки);
                    }
                }
                System.Diagnostics.Process.Start(fileFullPath);
            }
            catch(Exception exp)
            {
                if (exp.Message.Contains("так как этот файл используется другим процессом."))
                {
                    MessageBox.Show(
                        this,
                        "Не удалось открыть файл, возможно он уже открыт",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    return;
                }
                MessageBox.Show(
                    this,
                    "Не удалось открыть файл, возможно не установлен компонент для чтения файлов формата pdf",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
            }
        }
    }
    
}
