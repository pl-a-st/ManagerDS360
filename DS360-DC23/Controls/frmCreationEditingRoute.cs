﻿using LibDevicesManager;
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
    public enum SaveName
    {
        Cancel,
        SaveName
    }
    public enum TypeFormOpen
    {
        ToСreate,
        ToChange
    }
    public partial class frmCreationEditingRoute : Form
    {
        public SaveName SaveName;
        public TypeFormOpen TypeFormOpen;
        public FileInfo FileInfo;
        private DS360SettingVibroSigParam LastDS360Setting;
        private ManagerDC23 LastDC23 = new ManagerDC23();
        private VibrationStand LastVibStend = new VibrationStand();

        public frmCreationEditingRoute()
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
            cboSettingsType.BeginUpdate();
            cboSettingsType.Items.AddRange(elements);
            cboSettingsType.SelectedIndex = (int)TestedDevice.None;
            cboSettingsType.EndUpdate();
        }
        private void SetToolTipes()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.butAddSetting, "ALT+S");

            toolTip1.SetToolTip(this.butEditSetting, "CTRL+R");
            toolTip1.SetToolTip(this.butCopy, "Alt+C");
            toolTip1.SetToolTip(this.butPaste, "Alt+V");
            toolTip1.SetToolTip(this.butDelete, "CTRL+D");
            toolTip1.SetToolTip(this.butAllDelete, "CTRL+Shift+D");
            toolTip1.SetToolTip(this.butSave, "CTRL+S");
            toolTip1.SetToolTip(this.butCancel, "CTRL+X");
            toolTip1.SetToolTip(this.butUp, "Shift+Up");
            toolTip1.SetToolTip(this.butDown, "Shift+Down");

        }
        /// <summary>
        /// Кнопка добавить папку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }
        private void AddFolder()
        {
           frmInputName frmInputName = new frmInputName();
            frmInputName.ShowDialog();
            if (frmInputName.SaveName != SaveName.SaveName)
            {
                return;
            }
            TreeNodeWithSetting treeNodeWihtSetting = new TreeNodeWithSetting(NodeType.Folder, frmInputName.txtNameSet.Text);
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNodeWihtSetting);
                treRouteTree.SelectedNode = treeNodeWihtSetting;
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
           
            InsertNodeInSpecialPlace(treeNodeWihtSetting, SelectedNodeWithSetup);
        }
        internal void SetNameSetting(frmInputName frmInputName)
        {
            if (this.SaveName == SaveName.SaveName)
            {
                string nameSet = frmInputName.txtNameSet.Text;
                treRouteTree.Nodes.Add(new TreeNode(nameSet));
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
                AddSettingDS360();
            }
            if (e.Control == true && e.KeyCode == Keys.A)    //добавить папку
            {
                AddFolder();
            }
            if (e.Control == true && e.KeyCode == Keys.R)    //редактировать  
            {
                EditSetting();
            }
            if (e.Alt == true && e.KeyCode == Keys.C)       //копировать  
            {
                treRouteTree.CopySelectedNode();
            }
            if (e.Alt == true && e.KeyCode == Keys.V)       //вставить  
            {
                Paste();
            }
            if (e.Control == true && e.KeyCode == Keys.D)       //удалить узел  
            {
                RemoveCheckedNodes(treRouteTree.Nodes);
            }
            if (e.Control == true && e.Shift == true && e.KeyCode == Keys.D)    //удалить всё  
            {
                treRouteTree.Nodes.Clear();
            }
            if (e.Control == true && e.KeyCode == Keys.S)    //сохранить  
            {
                Save();
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

        internal void butAddSetting_Click(object sender, EventArgs e)
        {
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.DS360)
            {
                AddSettingDS360();
            }
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.DC23)
            {
                AddSettingDC23();
            }
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.Folder)
            {
                AddFolder();
            }
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.Message)
            {
                AddMessage();
            }
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.AllDC23InRoute)
            {
                AddAllDC23InRoute();
            }
            if (PmData.GetEnumFromString(PmData.SettingsType, cboSettingsType.SelectedItem.ToString()) == SettingsType.VibroCalib)
            {
                AddStandVibroCalib();
            }
        }
        private async void AddStandVibroCalib()
        {
            var frmVibroCalibSetting = new frmCreationVibroCalibSetting();
            frmVibroCalibSetting.CallType = CallType.Create;
            if (chkUseLastSetting.Checked && LastVibStend.VibroParametr != null)
            {
                await frmVibroCalibSetting.PushCboDetector();
                await frmVibroCalibSetting.PushCboSetValue();
                frmVibroCalibSetting.cboDetector.SelectedItem = PmData.Detector[(Detector)LastVibStend.Detector];
                frmVibroCalibSetting.cboSetValue.Text = PmData.VibrationQuantity[PmData.GetEnumFromVibroParam(PmData.VibroParametr, LastVibStend.VibroParametr)];
                frmVibroCalibSetting.txtFrequency.Text = LastVibStend.Frequency.Get_Hz().ToString();
                frmVibroCalibSetting.txtConversionFactor.Text = LastVibStend.Sensitivity.Get_mV_MS2().ToString();
                frmVibroCalibSetting.txtValue.Text = LastVibStend.VibroParametr.Get(LastVibStend.Detector).ToString();
            }
           
            if (frmVibroCalibSetting.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string textNode = "[" + frmVibroCalibSetting.cboSetValue.SelectedItem.ToString() + "] ";
            textNode += "[" + frmVibroCalibSetting.cboDetector.SelectedItem.ToString() + ":";
            textNode += frmVibroCalibSetting.txtValue.Text + "  ";
            textNode += "F:" + frmVibroCalibSetting.txtFrequency.Text + "]";

            TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.VibroStand, textNode);
            treeNode.VibrationStand = frmVibroCalibSetting.VibrationStand;
            LastVibStend = PmData.CloneObj(frmVibroCalibSetting.VibrationStand);
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNode);
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            InsertNodeInSpecialPlace(treeNode, SelectedNodeWithSetup);
        }
        private void AddAllDC23InRoute()
        {
            //if (treRouteTree.SelectedNode != null && (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Folder)
            //{
            //    MessageBox.Show("Настройка не может содержать другие элементы!");
            //    return;
            //}
            var frmGetNodeAddresses = new frmGetAllNodeAddressesFromRoute();
            if (frmGetNodeAddresses.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < frmGetNodeAddresses.lstAddresses.Items.Count; i += 2)
                {
                    ManagerDC23 dc23 = new ManagerDC23();
                    dc23.TimeToAnswer = 60;
                    dc23.SetRouteName(frmGetNodeAddresses.txtRouteName.Text);
                    dc23.SetСhannelFirstAddress(frmGetNodeAddresses.lstAddresses.Items[i].ToString());
                    string channelB = string.Empty;
                    if (i + 1 < frmGetNodeAddresses.lstAddresses.Items.Count)
                    {
                        channelB = frmGetNodeAddresses.lstAddresses.Items[i + 1].ToString();
                        dc23.SetСhannelSecondAddress(channelB);

                    }
                    string textNode = GetTextNode(frmGetNodeAddresses.txtRouteName.Text,
                        frmGetNodeAddresses.lstAddresses.Items[i].ToString(),
                        channelB);
                    TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.DC23, textNode);
                    treeNode.DC23 = dc23;
                    if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
                    {
                        treRouteTree.Nodes.Add(treeNode);
                        continue;
                    }
                    TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
                    //SelectedNodeWithSetup.Nodes.Add(treeNode);
                    //SelectedNodeWithSetup.Expand();
                    InsertNodeInSpecialPlace(treeNode, SelectedNodeWithSetup);
                }
            }
        }
        private void AddMessage()
        {
            frmInputName frmInputName = GetFrmInputName(out CheckBox stopTest);
            frmInputName.ShowDialog();
            if (frmInputName.SaveName != SaveName.SaveName)
            {
                return;
            }
            TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.Message, frmInputName.txtNameSet.Text);
            treeNode.StopTest = stopTest.Checked;
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNode);
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            InsertNodeInSpecialPlace(treeNode, SelectedNodeWithSetup);
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

        private void AddSettingDS360()
        {

            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = CallType.Create;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.Text = "Конструирование настройки";
            if (chkUseLastSetting.Checked && LastDS360Setting != null)
            {
                var DS360Setting = PmData.CloneObj(LastDS360Setting);
                СonfigureEditingSettings(DS360Setting, editingSettings);
            }
            editingSettings.ShowDialog();
            if (editingSettings.SaveStatus != SaveStatus.Save)
            {
                return;
            }
            string textNode = GetTextNode(editingSettings);
            TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.Setting, textNode);
            treeNode.DS360Setting = editingSettings.DS360Setting;
            LastDS360Setting = PmData.CloneObj(editingSettings.DS360Setting);
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNode);
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            InsertNodeInSpecialPlace(treeNode, SelectedNodeWithSetup);
        }

        private void InsertNodeInSpecialPlace(TreeNodeWithSetting treeNode, TreeNodeWithSetting SelectedNodeWithSetup)
        {
            if (treRouteTree.SelectedNode != null && (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Folder)
            {
                if (SelectedNodeWithSetup.Parent != null)
                {
                    SelectedNodeWithSetup.Parent.Nodes.Insert(SelectedNodeWithSetup.Index + 1, treeNode);
                }
                else
                {
                    SelectedNodeWithSetup.TreeView.Nodes.Insert(SelectedNodeWithSetup.Index + 1, treeNode);
                }
                SelectedNodeWithSetup.Expand();
                SelectedNodeWithSetup.TreeView.SelectedNode = treeNode;
                return;
            }
            SelectedNodeWithSetup.Nodes.Add(treeNode);
            SelectedNodeWithSetup.Expand();
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
            EditSetting();
        }

        async private void EditSetting()
        {
            if (treRouteTree.SelectedNode == null)
            {
                MessageBox.Show("Не выбран узел для редактирования");
                return;
            }
            TreeNodeWithSetting selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            if (selectedNode.NodeType == NodeType.Setting)
            {
                var DS360Setting = PmData.CloneObj(selectedNode.DS360Setting);
                frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
                СonfigureEditingSettings(DS360Setting, editingSettings);

                editingSettings.ShowDialog();
                if (editingSettings.SaveStatus != SaveStatus.Save)
                {
                    return;
                }
                TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
                SelectedNodeWithSetup.Text = GetTextNode(editingSettings);
                SelectedNodeWithSetup.DS360Setting = editingSettings.DS360Setting;
            }
            if (selectedNode.NodeType == NodeType.Folder)
            {
                frmInputName frmInputName = new frmInputName();
                frmInputName.txtNameSet.Text = selectedNode.Text;
                frmInputName.ShowDialog();
                if (frmInputName.SaveName == SaveName.SaveName)
                {
                    selectedNode.Text = frmInputName.txtNameSet.Text;
                }
            }
            if (selectedNode.NodeType == NodeType.DC23)
            {
                frmCreationDC23Setting frmCreationDC23Setting = new frmCreationDC23Setting();
                frmCreationDC23Setting.DC23 = selectedNode.DC23;
                GetFrmSettingsFromDC23(selectedNode.DC23, frmCreationDC23Setting);

                if (frmCreationDC23Setting.ShowDialog() == DialogResult.OK)
                {
                    selectedNode.Text = GetTextNode(frmCreationDC23Setting);
                }
                return;
            }
            if (selectedNode.NodeType == NodeType.Message)
            {
                frmInputName frmInputName = GetFrmInputName(out CheckBox stopTest);
                frmInputName.txtNameSet.Text = selectedNode.Text;
                stopTest.Checked = selectedNode.StopTest;
                if (frmInputName.ShowDialog() == DialogResult.OK)
                {
                    selectedNode.Text = frmInputName.txtNameSet.Text;
                    selectedNode.StopTest = stopTest.Checked;
                }
                return;
            }
            if (selectedNode.NodeType == NodeType.VibroStand)
            {
                var frmVibroCalibSetting = await GetFrmVibCalib(selectedNode);
                frmVibroCalibSetting.CallType = CallType.Change;
                if (frmVibroCalibSetting.ShowDialog() == DialogResult.OK)
                {
                    string textNode = "[" + frmVibroCalibSetting.cboSetValue.SelectedItem.ToString() + "] ";
                    textNode += "[" + frmVibroCalibSetting.cboDetector.SelectedItem.ToString() + ":";
                    textNode += frmVibroCalibSetting.txtValue.Text + "  ";
                    textNode += "F:" + frmVibroCalibSetting.txtFrequency.Text + "]";
                    selectedNode.VibrationStand = frmVibroCalibSetting.VibrationStand;
                    selectedNode.Text = textNode;
                }
            }
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
            Save();
        }

        private void Save()
        {
            if (txtNameRoute.Text == "" || txtNameRoute.Text == string.Empty)
            {
                MessageBox.Show("Не введено название маршрута!");
                return;
            }

            if (TypeFormOpen == TypeFormOpen.ToСreate)
            {
                string pathDyrectoryForRouteFile = DAO.GetFolderNameDialog("Выберите папку для сохранения маршрута.", out MethodResultStatus resultStatus);
                if (resultStatus != MethodResultStatus.Ok)
                {
                    MessageBox.Show("Не выбран путь для сохранения!");
                    return;
                }
                FileInfo = new FileInfo(pathDyrectoryForRouteFile + @"\" + txtNameRoute.Text + ".rout");
            }
            TreeNodeWithSetting[] treeNodeWithSettings = new TreeNodeWithSetting[treRouteTree.Nodes.Count];
            treRouteTree.Nodes.CopyTo(treeNodeWithSettings, 0);
            if (DAO.binWriteObjectToFile(treeNodeWithSettings, FileInfo.FullName) == MethodResultStatus.Fault)
            {
                MessageBox.Show($"Не удалось записать файл {FileInfo.FullName}");
                return;
            }
            if (TypeFormOpen == TypeFormOpen.ToСreate)
            {
                PmData.RouteAddresses.Add(FileInfo);
                DAO.binWriteObjectToFile(PmData.RouteAddresses, DAO.GetApplicationRoutePath(PmData.FileNameRouteAddresses));
            }
            if (MessageBox.Show("Файл маршрута успешно сохранен! Закртыть окно редактирования?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            TypeFormOpen = TypeFormOpen.ToChange;
            txtNameRoute.Enabled = false;
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            //удалить строку-настройку из файла с маршрутами
            RemoveCheckedNodes(treRouteTree.Nodes);
        }

        //удаление из treeView выделенных объектов
        void RemoveCheckedNodes(TreeNodeCollection nodes)
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            treRouteTree.Nodes.Remove(treRouteTree.SelectedNode);
        }
        //выбор элемента в treeView
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
            treRouteTree.Nodes.Clear();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            SaveName = SaveName.Cancel;
            this.Close();
        }

        private void butCopy_Click(object sender, EventArgs e)
        {
            if (chkCopyMany.Checked)
            {
                treRouteTree.CopyCheckNodes();
                return;
            }
            treRouteTree.CopySelectedNode();
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            if (chkCopyMany.Checked)
            {
                treRouteTree.PasteCheckNodes();
                return;
            }
            Paste();
        }

        private void Paste()
        {
            treRouteTree.PasteCopyTreeNode();
        }

        private void butUp_Click_1(object sender, EventArgs e)
        {

            //Up();
        }

        private void Up()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            TreeNode node = treRouteTree.SelectedNode;
            TreeNode parent = treRouteTree.SelectedNode.Parent;
            System.Windows.Forms.TreeView view = treRouteTree.SelectedNode.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, node);
                }
            }
            treRouteTree.SelectedNode = node;
        }

        private void butDown_Click_1(object sender, EventArgs e)
        {
            //Down();
        }

        private void Down()
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            TreeNode node = treRouteTree.SelectedNode;
            TreeNode parent = node.Parent;
            System.Windows.Forms.TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                }
            }
            else if (view != null && view.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, node);
                }
            }
            treRouteTree.SelectedNode = node;
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
            butDown.BackgroundImage = Properties.Resources.Стрелка_вниз2;
        }

        private void butDown_MouseLeave(object sender, EventArgs e)
        {
            butDown.BackgroundImage = Properties.Resources.Стрелка_вниз1;
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
            AddSettingDC23();
        }
        private void AddSettingDC23()
        {
            frmCreationDC23Setting editingSettings = new frmCreationDC23Setting();
            editingSettings.TypeFormOpen = TypeFormOpen.ToСreate;

            if (chkUseLastSetting.Checked && LastDC23 != null)
            {
                GetFrmSettingsFromDC23(LastDC23, editingSettings);
            }
            editingSettings.ShowDialog();
            if (editingSettings.DialogResult != DialogResult.OK)
            {
                return;
            }
            string textNode = GetTextNode(editingSettings);
            TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.DC23, textNode);
            treeNode.DC23 = editingSettings.DC23;
            LastDC23 = PmData.CloneObj(editingSettings.DC23);
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNode);
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            InsertNodeInSpecialPlace(treeNode, SelectedNodeWithSetup);
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
            EditSetting();
        }

        private async void butUp_MouseDown(object sender, MouseEventArgs e)
        {
            Up();
            await Task.Delay(150);
            while (butUp.IsMousDown)
            {
                Up();
                await Task.Delay(50);
            }
        }

        private async void butDown_MouseDown(object sender, MouseEventArgs e)
        {
            Down();
            await Task.Delay(150);
            while (butDown.IsMousDown)
            {
                Down();
                await Task.Delay(50);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            treRouteTree.CheckBoxes = !treRouteTree.CheckBoxes;
        }

        private void cboIgnore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
