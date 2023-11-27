using LibControls;
using LibDevicesManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360
{
    public partial class frmDevicePlugIn : Form
    {
        public frmDevicePlugIn()
        {
            InitializeComponent();
        }

        private async void frmDevicePlugIn_Load(object sender, EventArgs e)
        {
            await GetDefaultDS360ToCboListComPorts();
        }
        private async Task GetDefaultDS360ToCboListComPorts()
        {
            cboListComPorts.Enabled = false;
            cboListComPorts.Items.Clear();
            await Task.Run(() => butRefreshDS360List.StartRotationBackgroundImage());
            await Task.Delay(100);
            if (DS360Setting.ComPortDefaultName== "NONE")
            {
                Task getComes = new Task(() => DS360Setting.SetFirstDS360AsDefault());
                await Task.Run(() => getComes.Start());
                await Task.Run(() => getComes.Wait());
            }
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            cboListComPorts.Items.Add(name);
            cboListComPorts.SelectedItem = name;
            await Task.Run(() => butRefreshDS360List.StopRotationBackgroundImage());
            cboListComPorts.Enabled = true;
        }
        private async Task SetDefaultDS360()
        {
            Task getComes = new Task(() => DS360Setting.SetFirstDS360AsDefault());
            await Task.Run(() => getComes.Start());
            await Task.Run(() => getComes.Wait());
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
        }
        private async void RotateImage()
        {
           


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void buttonForPicture3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private async void buttonForPicture1_Click(object sender, EventArgs e)
        {
           
            await GetDefaultDS360ToCboListComPorts();
        }

        private void SwetchRotationButton(ButtonForRotation buttonForPicture)
        {
            if (buttonForPicture.IsRotation)
            {
                buttonForPicture.StopRotationBackgroundImage();
                return;
            }
            if (!buttonForPicture.IsRotation)
            {
                buttonForPicture.StartRotationBackgroundImage();
                return;
            }
        }

        private void buttonForPicture2_Click(object sender, EventArgs e)
        {

            SwetchRotationButton(buttonForPicture2);
        }

        private void buttonForPicture3_Click_1(object sender, EventArgs e)
        {
            SwetchRotationButton(buttonForPicture3);
        }
    }
}
