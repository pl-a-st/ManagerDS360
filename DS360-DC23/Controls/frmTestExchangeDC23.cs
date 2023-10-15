using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Vast.DC23.DataTransferClient;
using LibDevicesManager.DC23;

namespace ManagerDS360
{
    public enum ConectStatus
    {
        Connecting,
        Conected,
        Disconected
    }
    public partial class frmTestExchangeDC23 : Form
    {
        ClientDC23 Client = ManagerDC23.Client;


        public frmTestExchangeDC23()
        {
            InitializeComponent();
        }

        private void frmTestExchangeDC23_Load(object sender, EventArgs e)
        {
            SetLblConectStatus(ConectStatus.Connecting);
            Client.ConnectedEvent += Client_ConnectedEvent;
            Client.DisconnectedEvent += Client_DisconnectedEvent;
            Client.ReceivedMessageDC23Event += Client_GetedMessageFromDC23;
            Thread thr = new Thread(() => Client.Connect());
            thr.IsBackground = true;
            thr.Start();
        }

        private void Client_GetedMessageFromDC23(string message)
        {
            if(this.InvokeRequired)
            {
                BeginInvoke(new Action(() => txtMessages.Text +=  DateTime.Now.ToShortTimeString() + " " + message + "\r\n")) ;
            }
            else
            {
                txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + message + "\r\n";
            }
            
        }

        private void Client_DisconnectedEvent(object sender, EventArgs e)
        {
            SetLblConectStatus(ConectStatus.Disconected);
        }
        private void Client_ConnectedEvent(object sender, EventArgs e)
        {
            SetLblConectStatus(ConectStatus.Conected);
        }
        void SetLblConectStatus(ConectStatus status)
        {
            if(status == ConectStatus.Connecting)
            {
                lblConectStatus.Text = "Идет соединение с прибором";
            }
            if(status == ConectStatus.Conected)
            {
                this?.Invoke(new Action(() => { 
                    lblConectStatus.Text = "Соединение с прибором установлено";
                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = true;
                    }
                }));
              
            }
            if(status == ConectStatus.Disconected)
            {
                this.Invoke(new Action(() => {
                    lblConectStatus.Text = "Соединение разорвано";
                    foreach (Control control in this.Controls)
                    {
                        control.Enabled = false;
                    }
                }));
            }
        }

        private void butDisconect_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            Client.CancelConnecting();
        }

        private void butOpenRoute_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_OPEN_ROUTE_<{txtRouteName.Text}>");
        }

        private void butSetChannelA_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_SELECT_NODE_FERST_<{txtNodeAddressChannelA.Text}>");
        }

        private void butSetChannelB_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_SELECT_NODE_SECOND_<{txtNodeAddressChannelB.Text}>");
        }

        private void butMeas_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_MEAS");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerDC23 DC23 = new ManagerDC23();
            DC23.SetRouteName(txtRouteName.Text);
            txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + DC23.OpenRoute().ToString() + "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerDC23 DC23 = new ManagerDC23();
            DC23.SetСhannelFirstAddress(txtNodeAddressChannelA.Text);
            txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + DC23.SetChannelFirst().ToString() + "\r\n";
        }

        private void frmTestExchangeDC23_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Disconnect();
            Client.CancelConnecting();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagerDC23 DC23 = new ManagerDC23();
            DC23.SetСhannelSecondAddress(txtNodeAddressChannelB.Text);
            txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + DC23.SetChannelSecond().ToString() + "\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagerDC23 DC23 = new ManagerDC23();
            txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + DC23.Meas().ToString() + "\r\n";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_GET_NODE_ADRESES");
        }
    }
}
