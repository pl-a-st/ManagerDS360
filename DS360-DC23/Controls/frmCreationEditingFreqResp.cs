using LibDevicesManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagerDS360;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LibControls;
using System.Runtime.InteropServices;
using VibroMath;
using System.Diagnostics;
using ToolTip = System.Windows.Forms.ToolTip;
using ManagerDS360.Controls;
using LibDevicesManager.DC23;

namespace ManagerDS360
{
    public partial class frmCreationEditingFreqResp : Form
    {
        public SaveName SaveName;
        public TypeFormOpen TypeFormOpen;
        public FileInfo FileInfo;
        public FrequencyResponse FreqResp = new FrequencyResponse();

        public frmCreationEditingFreqResp()
        {
            InitializeComponent();
        }

        public async void frmCreationEditingRoute_Load(object sender, EventArgs e)
        {
            SetToolTipes();
            await SetSettingTypeList();
        }
        private async Task SetSettingTypeList()
        {
            await Task.Delay(10);
            var elements = PmData.SettingsType.Values.ToArray();
           
        }
        private void SetToolTipes()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.butSave, "CTRL+S");
            toolTip1.SetToolTip(this.butCancel, "CTRL+X");
        }
        /// <summary>
        /// Кнопка добавить папку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAddFolder_Click(object sender, EventArgs e)
        {
          
        }
       
        internal void SetNameSetting(frmInputName frmInputName)
        {
            if (this.SaveName == SaveName.SaveName)
            {
                string nameSet = frmInputName.txtNameSet.Text;
               
            }
            return;
        }

        private void lblRouteName_Click(object sender, EventArgs e)
        {

        }

        private void txtNameRoute_TextChanged(object sender, EventArgs e)
        {
            //название маршрута
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.S)    // добавить настройку
            {

            }
            if (e.Control == true && e.KeyCode == Keys.A)    //добавить папку
            {

            }
            if (e.Control == true && e.KeyCode == Keys.R)    //редактировать  
            {
                
            }
            if (e.Alt == true && e.KeyCode == Keys.C)       //копировать  
            {

                if (e.Alt == true && e.KeyCode == Keys.V)       //вставить  
                {
                    Paste();
                }
                if (e.Control == true && e.KeyCode == Keys.D)       //удалить узел  
                {

                }
                if (e.Control == true && e.Shift == true && e.KeyCode == Keys.D)    //удалить всё  
                {

                }
                if (e.Control == true && e.KeyCode == Keys.S)    //сохранить  
                {
                    
                }
                if (e.Control == true && e.KeyCode == Keys.X)    //закрыть  
                {
                    SaveName = SaveName.Cancel;
                    this.Close();
                }
                if (e.Shift == true && e.KeyCode == Keys.Up)    //вверх  
                {
                    Up();
                    e.Handled = true;
                }
                if (e.Shift == true && e.KeyCode == Keys.Down)    //вниз  
                {
                    Down();
                    e.Handled = true;
                }
            }
        }

        public  void butAddSetting_Click(object sender, EventArgs e)
        {
           
        }
        

        private frmInputName GetFrmInputName(out CheckBox stopTest)
        {
            frmInputName frmInputName = new frmInputName();
            frmInputName = new frmInputName();
            frmInputName.label1.Text = "Текст сообщения";
            stopTest = new CheckBox();
            stopTest.AutoSize = true;
            stopTest.Text = "Останавливать испытание";
            stopTest.Location = new Point(frmInputName.txtNameSet.Location.X, frmInputName.txtNameSet.Location.Y + frmInputName.txtNameSet.Height + 5);
            stopTest.Text = "Останавливать испытание";
            frmInputName.Controls.Add(stopTest);
            return frmInputName;
        }

      

        private static string GetTextNode(frmCreationEditingSettings editingSettings)
        {
            string textNode = string.Empty;
            textNode += "[" + editingSettings.cboTypeSignal.Text + "]  ";
            textNode += "[Кп:" + editingSettings.txtConversionFactor.Text + "]  ";
            textNode += "[" + editingSettings.cboSetValue.Text + "]  ";
            textNode += "T1: ";
            textNode += "[" + editingSettings.cboDetector.Text + ":";
            textNode += editingSettings.txtValue.Text;
            textNode += "  F:" + editingSettings.txtFrequency.Text + "]  ";
            textNode += "\r\n";
            if (editingSettings.IsTwoTone())
            {
                textNode += "T2: ";
                textNode += "[" + editingSettings.cboDetector2.Text + ":";
                textNode += editingSettings.txtValue2.Text;
                textNode += "  F:" + editingSettings.txtFrequency2.Text + "]  ";
            }
            textNode += "[Offset:" + editingSettings.txtOffset.Text + "] ";
            textNode += "[COM: ";
            if (editingSettings.chcDefaultGenerator.Checked)
            {
                textNode += "default]";
            }
            else
            {
                textNode += editingSettings.numComName.Value.ToString() + "]";
            }
            return textNode;
        }
        private static string GetTextNode(string routeName, string chanellA, string channelB)
        {
            string text = routeName;
            var listBox = new List<string>(chanellA.Split('/'));

            if (listBox.Count > 0)
            {
                text += " [Канал А: .../";
                if (listBox.Count > 1)
                {
                    text += listBox[listBox.Count - 2].Replace("%SP%", " ").Replace("%BS%", "/");
                    text += "/";
                }
                text += listBox[listBox.Count - 1].Replace("%SP%", " ").Replace("%BS%", "/");
                text += "] ";
            }

            listBox = new List<string>(channelB.Split('/')); ;
            if (listBox.Count > 0)
            {
                text += "] [Канал B: .../";
                if (listBox.Count > 1)
                {
                    text += listBox[listBox.Count - 2].Replace("%SP%", " ").Replace("%BS%", "/");
                    text += "/";
                }
                text += listBox[listBox.Count - 1].Replace("%SP%", " ").Replace("%BS%", "/");
                text += "]";
            }
            return text;
        }
        private static string GetTextNode(frmCreationDC23Setting editingSettings)
        {
            string text = editingSettings.DC23.GetRouteNameWithoutCharProtection();
            ListBox listBox = editingSettings.GetLstChannaleFirst();

            if (listBox.Items.Count > 0)
            {
                text += " [Канал А: .../";
                if (listBox.Items.Count > 1)
                {
                    text += listBox.Items[listBox.Items.Count - 2];
                    text += "/";
                }
                text += listBox.Items[listBox.Items.Count - 1];
                text += "] ";
            }

            listBox = editingSettings.GetLstChannelSecond();
            if (listBox.Items.Count > 0)
            {
                text += "] [Канал B: .../";
                if (listBox.Items.Count > 1)
                {
                    text += listBox.Items[listBox.Items.Count - 2];
                    text += "/";
                }
                text += listBox.Items[listBox.Items.Count - 1];
                text += "]";
            }
            return text;
        }

        /// <summary>
        /// редактирование настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditSetting_Click(object sender, EventArgs e)
        {
            
        }

       

        private static async Task<frmCreationVibroCalibSetting> GetFrmVibCalib(TreeNodeWithSetting selectedNode)
        {
            var frmVibroCalibSetting = new frmCreationVibroCalibSetting();
            await frmVibroCalibSetting.PushCboDetector();
            await frmVibroCalibSetting.PushCboSetValue();
            frmVibroCalibSetting.cboDetector.SelectedItem = PmData.Detector[(Detector)selectedNode.VibrationStand.Detector];
            frmVibroCalibSetting.cboSetValue.Text = PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, selectedNode.VibrationStand.VibroParametr)];
            frmVibroCalibSetting.txtFrequency.Text = selectedNode.VibrationStand.Frequency.Get_Hz().ToString();
            frmVibroCalibSetting.txtConversionFactor.Text = selectedNode.VibrationStand.Sensitivity.Get_mV_MS2().ToString();
            frmVibroCalibSetting.txtValue.Text = selectedNode.VibrationStand.VibroParametr.Get(selectedNode.VibrationStand.Detector).ToString();
            return frmVibroCalibSetting;
        }

        private static void GetFrmSettingsFromDC23(ManagerDC23 dc23, frmCreationDC23Setting frmCreationDC23Setting)
        {
            frmCreationDC23Setting.GetTxtRoutName().Text = dc23.GetRouteNameWithoutCharProtection();
            frmCreationDC23Setting.GetTxtTimeToAnswer().Text = dc23.TimeToAnswer.ToString() ?? "30";
            frmCreationDC23Setting.GetLstChannaleFirst().Items.AddRange(ManagerDC23.GetListBoxFromAddress(dc23.СhannelFirstAddress).Items);
            frmCreationDC23Setting.GetLstChannelSecond().Items.AddRange(ManagerDC23.GetListBoxFromAddress(dc23.СhannelSecondAddress).Items);
            //foreach (string str in dc23.СhannelFirstAddress.Replace("_", " ").Split('/'))
            //{
            //    if (str == dc23.RouteName)
            //    {
            //        continue;
            //    }
            //    frmCreationDC23Setting.GetLstChannaleFirst().Items.Add(str);
            //}
            //foreach (string str in dc23.СhannelSecondAddress.Replace("_", " ").Split('/'))
            //{
            //    if (str == dc23.RouteName)
            //    {
            //        continue;
            //    }
            //    frmCreationDC23Setting.GetLstChannelSecond().Items.Add(str);
            //}
        }

        private async void СonfigureEditingSettings(DS360SettingVibroSigParam dS360, frmCreationEditingSettings editingSettings)
        {
            DS360SettingConvert_V_to_mV(dS360);

            editingSettings.Text = "Конструирование настройки";
            editingSettings.Type = CallType.Change;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            await editingSettings.InitializecboSetValue();
            await editingSettings.InitializecboDetector();
            await editingSettings.InitializecboDetector2();
            await editingSettings.InitializecboTypeSignal();
            editingSettings.cboDetector.SelectedItem = PmData.Detector[(Detector)dS360.SignalParametrTone1];
            editingSettings.cboDetector2.SelectedItem = PmData.Detector[(Detector)dS360.SignalParametrTone2];
            editingSettings.txtConversionFactor.Text = dS360.Sensitivity.Get_mV_G().ToString();
            editingSettings.txtFrequency.Text = dS360.Frequency.ToString();
            editingSettings.txtOffset.Text = dS360.Offset.ToString();
            editingSettings.cboTypeSignal.SelectedItem = PmData.FunctionTypeSignal[(FunctionTypeSignal)dS360.FunctionType];
            if (dS360.IsComPortDefaultName)
            {
                editingSettings.chcDefaultGenerator.Checked = true;
            }
            else
            {
                editingSettings.chcDefaultGenerator.Checked = false;
                editingSettings.numComName.Value = int.Parse(dS360.ComPortName.Replace("COM", ""));
            }

            ConfigureToVibroparam(dS360, editingSettings);
            editingSettings.cboTypeSignal.SelectedItem = PmData.FunctionTypeSignal[(FunctionTypeSignal)dS360.FunctionType];
            if (editingSettings.IsTwoTone())
            {
                editingSettings.txtFrequency2.Text = dS360.FrequencyB.ToString();
            }
            // добавить обработку Com по дефолту или номеру
        }

        private static void DS360SettingConvert_V_to_mV(DS360SettingVibroSigParam dS360)
        {
            dS360.AmplitudeRMS *= 1000;
            dS360.AmplitudeRMSToneB *= 1000;
            dS360.Offset *= 1000;
        }

        private static void ConfigureToVibroparam(DS360SettingVibroSigParam dS360, frmCreationEditingSettings editingSettings)
        {
            VibroCalc.Frequency.Set_Hz(dS360.Frequency);
            VibroCalc.Sensitivity.Set_mV_G(dS360.Sensitivity.Get_mV_G());
            if (dS360.VibroParametr is Voltage)
            {
                VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = GetVoltage(dS360, dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = GetVoltage(dS360, dS360.SignalParametrTone2).ToString();
                }
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.U];
            }
            if (dS360.VibroParametr is Velocity)
            {
                VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Velocity.Get(dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.Frequency.Set_Hz(dS360.FrequencyB);
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = VibroCalc.Velocity.Get(dS360.SignalParametrTone2).ToString();
                }
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.мм_с];
            }
            if (dS360.VibroParametr is Acceleration)
            {
                VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = GetAcceleration(dS360, dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = GetAcceleration(dS360, dS360.SignalParametrTone2).ToString();
                }

                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.м_с2];
            }
            if (dS360.VibroParametr is Displacement)
            {
                VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Displacement.Get(dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.Frequency.Set_Hz(dS360.FrequencyB);
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = VibroCalc.Displacement.Get(dS360.SignalParametrTone2).ToString();
                }
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.мкм];
            }
        }

        private static double GetVoltage(DS360SettingVibroSigParam dS360, SignalParametrType signalParametrType)
        {
            if (dS360.FunctionType == FunctionType.Square)
            {
                if (signalParametrType == SignalParametrType.RMS ||
                    signalParametrType == SignalParametrType.PIK)
                {
                    return VibroCalc.Voltage.GetRMS();
                }
                if (signalParametrType == SignalParametrType.PIK_PIK)
                {
                    return 2 * VibroCalc.Voltage.GetRMS();
                }
            }
            return VibroCalc.Voltage.Get(signalParametrType);
        }
        private static double GetAcceleration(DS360SettingVibroSigParam dS360, SignalParametrType signalParametrType)
        {
            if (dS360.FunctionType == FunctionType.Square)
            {
                if (signalParametrType == SignalParametrType.RMS ||
                    signalParametrType == SignalParametrType.PIK)
                {
                    return VibroCalc.Acceleration.GetRMS();
                }
                if (signalParametrType == SignalParametrType.PIK_PIK)
                {
                    return 2 * VibroCalc.Acceleration.GetRMS();
                }
            }
            return VibroCalc.Acceleration.Get(signalParametrType);
        }

        /// <summary>
        /// //переместить настройку вверх по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butUp_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// //переместить настройку вниз по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void butDown_Click(object sender, EventArgs e)
        //{

        //}

        internal void butSave_Click(object sender, EventArgs e)
        {
            FreqResp.Clear();
            foreach(DataGridViewRow row in dgvFreqResp.Rows)
            {
                if (row.Cells[freq.Name].Value== null|| row.Cells[coeff.Name].Value==null||
                    string.IsNullOrEmpty(row.Cells[freq.Name].Value.ToString())||
                    string.IsNullOrEmpty(row.Cells[coeff.Name].Value.ToString()))
                {
                    continue;
                }
                FreqResp.Add(double.Parse((string)row.Cells[freq.Name].Value),
                    double.Parse((string)row.Cells[coeff.Name].Value));
            }
            dgvFreqResp.Rows.Clear();
            foreach(var element in FreqResp)
            {
               var index = dgvFreqResp.Rows.Add();
                dgvFreqResp.Rows[index].Cells[freq.Name].Value = element.Key.ToString();
                dgvFreqResp.Rows[index].Cells[coeff.Name].Value = element.Value.ToString();
            }
            SaveName = SaveName.SaveName;
        }

        

        private void butDelete_Click(object sender, EventArgs e)
        {
            //удалить строку-настройку из файла с маршрутами
            
        }

       
        private void treRouteTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode rootNodeRoute = e.Node;
            if (rootNodeRoute == null)
            {
                return;
            }

        }
        //private void lstRouteTree_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void lblRouteTree_Click(object sender, EventArgs e)
        {
        }

        private void butAllDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            SaveName = SaveName.Cancel;
            this.Close();
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
           
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Paste()
        {
            
        }

        private void butUp_Click_1(object sender, EventArgs e)
        {

            //Up();
        }

        private void Up()
        {
            
        }

        private void butDown_Click_1(object sender, EventArgs e)
        {
            //Down();
        }

        private void Down()
        {
            
        }

        private void butUp_MouseEnter(object sender, EventArgs e)
        {
            //butUp.BackgroundImage = Properties.Resources.Стрелка_вверх2;
        }

        private void butUp_MouseLeave(object sender, EventArgs e)
        {
            //butUp.BackgroundImage = Properties.Resources.Стрелка_вверх1;
        }

        private void butDown_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void butDown_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void frmCreationEditingRoute_FormClosed(object sender, FormClosedEventArgs e)
        {



        }

        private void frmCreationEditingRoute_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                if (MessageBox.Show(
                    "Вы уверены, что хотите закрыть без сохранения?",
                    "Закрытие",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void butAddDC23_Click(object sender, EventArgs e)
        {
            
        }
       

        private void treRouteTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treRouteTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treRouteTree_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }

        private void treRouteTree_DoubleClick(object sender, EventArgs e)
        {

        }

        private void treRouteTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private async void butUp_MouseDown(object sender, MouseEventArgs e)
        {
            Up();
            await Task.Delay(150);
            while (false)//butUp.IsMousDown
            {
                Up();
                await Task.Delay(50);
            }
        }

        private async void butDown_MouseDown(object sender, MouseEventArgs e)
        {
            Down();
            await Task.Delay(150);
            while (false) //butDown.IsMousDown
            {
                Down();
                await Task.Delay(50);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
