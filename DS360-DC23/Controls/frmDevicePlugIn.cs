using LibControls;
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

        private void frmDevicePlugIn_Load(object sender, EventArgs e)
        {
            
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

        private void buttonForPicture1_Click(object sender, EventArgs e)
        {
            SwetchRotationButton(buttonForPicture1);
        }

        private void SwetchRotationButton(ButtonForRotation buttonForPicture)
        {
            if (buttonForPicture.IsRotation)
            {
                buttonForPicture.StopRotation();
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
