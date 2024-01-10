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
            await SetCboListFromDict(cboGenToMultType, PmData.GeneratorModel);
            await SetCboListFromDict(cboGenToVibType, PmData.GeneratorModel);
            await SetCboListFromDict(cboMultToMultType, PmData.MultimeterModel);
            await SetCboListFromDict(cboMultToVibType, PmData.MultimeterModel);
            await GetDefaultDS360ToCboListComPorts();

        }
        private async Task SetCboListFromDict<T>(ComboBox cbo, Dictionary<T, string> dict)
        {
            await Task.Delay(10);
            var elements = dict.Values.ToArray();
            cbo.BeginUpdate();
            cbo.Items.AddRange(elements);
            cbo.SelectedIndex = (int)TestedDevice.None;
            cbo.EndUpdate();
        }
        private async Task GetDefaultDS360ToCboListComPorts()
        {
            cboListComPorts.Enabled = false;
            cboListComPorts.Items.Clear();
            await Task.Run(() => butRefreshDS360List.StartRotationBackgroundImage());
            await Task.Delay(100);
            if (DS360Setting.ComPortDefaultName == "NONE")
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
            await SwetchRotationButton(butRefreshDS360List);
            await FindDS360PushCbo(cboListComPorts);
            await SwetchRotationButton(butRefreshDS360List);
        }
        private async Task FindDS360PushCbo(ComboBox cbo)
        {
            Task<string[]> getComs = new Task<string[]>(() => DS360Setting.FindAllDS360(true));
            Task.Run(() => getComs.Start());
            await Task.Run(() => getComs.Wait());
            cbo.Items.Clear();
            cbo.Items.AddRange(getComs.Result);
            cbo.SelectedIndex = 0;
        }
        private async Task FindAgilent3458APushCbo(ComboBox cbo)
        {
            Task<string[]> getComs = new Task<string[]>(() => Agilent3458A.FindAllAgilent3458A().ToArray());
            Task.Run(() => getComs.Start());
            await Task.Run(() => getComs.Wait());
            cbo.Items.Clear();
            cbo.Items.AddRange(getComs.Result);
            if (cbo.Items.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }
        private async Task SwetchRotationButton(ButtonForRotation buttonForPicture)
        {
            // перемеситить метод в класс кнопки
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
            buttonForPicture3.SwetchRotationButton();
        }

        private void cboListComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS360Setting.ComPortDefaultName = cboListComPorts.SelectedItem.ToString();
        }

        private async void butRefreshGenToMultAddresses_Click(object sender, EventArgs e)
        {

            await butRefreshGenToMultAddresses.SwetchRotationButton();
            if (PmData.GetEnumFromString(PmData.GeneratorModel, cboGenToMultType.SelectedItem.ToString()) == GeneratorModel.DS360)
            {
                await FindDS360PushCbo(cboGenToMultAddress);
            }
            await butRefreshGenToMultAddresses.SwetchRotationButton();
        }

        private void cboGenToMultAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenToMultAddress.SelectedItem.ToString() != string.Empty)
            {
                // todo прописать установку адреса для генератора
            }
        }

        private async void butRefreshGenToVibAddresses_Click(object sender, EventArgs e)
        {
            await butRefreshGenToVibAddresses.SwetchRotationButton();
            if (PmData.GetEnumFromString(PmData.GeneratorModel, cboGenToVibType.SelectedItem.ToString()) == GeneratorModel.DS360)
            {
                await FindDS360PushCbo(cboGenToVibAddress);
            }
            await butRefreshGenToVibAddresses.SwetchRotationButton();
        }

        private void cboGenToVibType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeneratorForVibCalib.GeneratorModel = PmData.GetEnumFromString(PmData.GeneratorModel, cboGenToVibType.SelectedItem.ToString());
        }

        private void cboGenToVibAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGenToVibAddress.SelectedIndex.ToString() != string.Empty)
                GeneratorForVibCalib.Address = cboGenToVibAddress.SelectedItem.ToString();
        }

        async private void buttonForPicture6_Click(object sender, EventArgs e)
        {
            await butRefreshMultToVibAddresses.SwetchRotationButton();
            if (PmData.GetEnumFromString(PmData.MultimeterModel, cboMultToVibType.SelectedItem.ToString()) == MultimeterModel.Agilent3458A)
            {
                await FindAgilent3458APushCbo(cboMultToVibAddress);
            }
            await butRefreshMultToVibAddresses.SwetchRotationButton();
        }

        private void cboMultToVibAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMultToVibAddress.SelectedItem.ToString()))
            {
                
            }
        }
    }
}
