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
        Client Client = new Client();
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
                BeginInvoke(new Action(() => txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + message + "\n\n"));
            }
            else
            {
                txtMessages.Text += DateTime.Now.ToShortTimeString() + " " + message + "\n\n";
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
                lblConectStatus.Text = "Соединение с прибором установлено";
            }
            if(status == ConectStatus.Disconected)
            {
                lblConectStatus.Text = "Соединение разорвано";
            }
        }

        private void butDisconect_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
        }

        private void butOpenRoute_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_OPEN_ROUTE_[{txtRouteName.Text}]");
        }

        private void butSetChannelA_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_SELECT_NODE_FERST_[{txtNodeAddressChannelA.Text}]");
        }

        private void butSetChannelB_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_SELECT_NODE_SECOND_[{txtNodeAddressChannelB.Text}]");
        }

        private void butMeas_Click(object sender, EventArgs e)
        {
            Client.SendCommandDC23($"CONTROL_FROM_PC_MEAS");
        }
    }
}
