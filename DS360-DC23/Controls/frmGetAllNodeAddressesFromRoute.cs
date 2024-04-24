using LibDevicesManager.DC23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360.Controls
{
    public partial class frmGetAllNodeAddressesFromRoute : Form
    {
        public frmGetAllNodeAddressesFromRoute()
        {
            InitializeComponent();
        }
        private bool IsNodeAdresesAnswerFinish = false;

        private async void frmGetAllNodeAddressesFromRoute_Load(object sender, EventArgs e)
        {
            await SetTestedDevicesList();
            cboTestedDevice.SelectedIndexChanged += CboTestedDevice_SelectedIndexChanged;
        }
        private void CboTestedDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            var client = ManagerDC23.Client;
            if (PmData.GetEnumFromString(PmData.TestedDevice, cboTestedDevice.Text) == TestedDevice.DC23)
            {
                client.ConnectedEvent += Client_ConnectedEvent;
                client.DisconnectedEvent += Client_DisconnectedEvent;

                Thread thr = new Thread(() => client.Connect());
                thr.IsBackground = true;
                Invoke(new Action(() =>
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
        private void Client_ConnectedEvent(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lblTestedDevice.ForeColor = Color.Green;
                lblTestedDevice.Text = "Соединение установлено";
            }));

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
                catch{}
                try
                {
                    client.DisconnectedEvent -= Client_DisconnectedEvent;
                }
                catch{}
            }));

        }

        private void cboTestedDevice_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // записан в load фыормы
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

        private void frmGetAllNodeAddressesFromRoute_FormClosing(object sender, FormClosingEventArgs e)
        {
            var client = ManagerDC23.Client;

            if (client != null && client.Connected)
            {
                client.Disconnect();
                client.CancelConnecting();
            }
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await GetAllAddressNodeWithProgessBar();
        }

        private async Task GetAllAddressNode()
        {
            ManagerDC23.Client.ReceivedMessageDC23Event += Client_ReceivedMessageDC23Event;
            ManagerDC23 DC23 = new ManagerDC23();
            DC23.SetRouteName(txtRouteName.Text);
            if (DC23.OpenRoute() != ResultCommandDC23.Success)
            {
                ManagerDC23.Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
                AcyncShowMassageAndChangePicture("Не удалось открыть маршрут");
                return;
            }
            ManagerDC23.Client.SendCommandDC23($"CONTROL_FROM_PC_GET_NODE_ADRESES");
            while (!IsNodeAdresesAnswerFinish)
            {
                Task.Delay(300);
            }
            ManagerDC23.Client.ReceivedMessageDC23Event -= Client_ReceivedMessageDC23Event;
            AcyncShowMassage("Все узлы получены.");
        }

        private async Task GetAllAddressNodeWithProgessBar()
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }
            Panel panel = new Panel();
            InsertControlsForWating(panel, new ProgressBar(), new Label());
            Task getComes = new Task(action: () => GetAllAddressNode());
            await Task.Run(() => getComes.Start());
            await Task.Run(() => getComes.Wait());
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
            label.Text = "Идет получение адресов узлов";
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
        private void AcyncShowMassageAndChangePicture(string massege)
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

            }));
        }
        private void AcyncShowMassage(string massege)
        {
            BeginInvoke(new Action(() =>
            {
                MessageBox.Show(
                   this,
                   massege,
                   "Сообщение",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1);

            }));
        }
        private void Client_ReceivedMessageDC23Event(string message)
        {
            BeginInvoke(new Action(() =>
            {
                if (message.Contains("GET_NODE_ADRESES_ANSWER_FINISH"))
                {
                    IsNodeAdresesAnswerFinish = true;
                    return;
                }
                if (message.Contains("GET_NODE_ADRESES_ANSWER_NODE_"))
                {
                    lstAddresses.Items.Add(txtRouteName.Text+"/"+message.
                        Replace("GET_NODE_ADRESES_ANSWER_NODE_", "").
                        Replace("<", "").
                        Replace(">", ""));
                }
            }));
        }

        private void ButDelete_Click(object sender, EventArgs e)
        {
            for (int x = lstAddresses.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = lstAddresses.SelectedIndices[x];
                lstAddresses.Items.RemoveAt(idx);
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboTestedDevice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
