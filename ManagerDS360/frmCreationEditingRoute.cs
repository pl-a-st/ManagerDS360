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

namespace ManagerDS360
{
    public enum SaveName
    {
        Cancel,
        SaveName
    }
    public partial class frmCreationEditingRoute : Form
    {
        public SaveName SaveName;
        Timer timer;

        List<TreeNode> checkedNodes = new List<TreeNode>();
        public frmCreationEditingRoute()
        {
            InitializeComponent();
        }

        public void frmCreationEditingRoute_Load(object sender, EventArgs e)
        {
            PushListBox();
            butUp.Enabled = false;
            butDown.Enabled = false;
            List<DS360Setting> dS360Settings = new List<DS360Setting>();

        }

        private void PushListBox()
        {
            //lstRouteTree.Items.Clear();
            //foreach (Entry entry1 in ProgramData.Entries)
            //{

            //}
        }
        /// <summary>
        /// Кнопка добавить папку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butAddFolder_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode != null && (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Setting)
            {
                MessageBox.Show("Настройка не может содержать другие элементы!");
                return;
            }
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
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            SelectedNodeWithSetup.Nodes.Add(treeNodeWihtSetting);
            SelectedNodeWithSetup.Expand();
        }
        //обновление окна CreationEditingRoute
        void editingSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            if (editingSettings.SaveStatus == SaveStatus.Save)
            {
                lblSave.Visible = true;
                timer = new Timer();
                timer.Interval = 2000;
                timer.Enabled = true;
                timer.Tick += timeTick;
                editingSettings.SaveStatus = SaveStatus.Cancel;
            }
            this.Refresh();
        }

        //таймер для сохранения
        internal void timeTick(object sender, EventArgs e)
        {
            lblSave.Visible = false;
            timer.Enabled = false;
        }

        //internal void SetNameSetting(frmInputName frmInputName)
        //{
        //    if (this.SaveName == SaveName.SaveName)
        //    {
        //        string nameSet = frmInputName.txtNameSet.Text;
        //        treRouteTree.Nodes.Add(new TreeNode(nameSet));
        //    }
        //    return;
        //}

        private void lblRouteName_Click(object sender, EventArgs e)
        {

        }

        private void txtNameRoute_TextChanged(object sender, EventArgs e)
        {
            //название маршрута
        }

        public static class StaticName
        {
            //Статическая переменная, выступающая как буфер данных для имени настройки
            public static String nameBuffer = String.Empty;
        }

        internal void butAddSetting_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode != null && (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Setting)
            {
                MessageBox.Show("Настройка не может содержать другие элементы!");
                return;
            }
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = Type.Create;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.FormClosed += new FormClosedEventHandler(editingSettings_FormClosed);
            editingSettings.Text = "Конструирование настройки";
            editingSettings.ShowDialog();
            if (editingSettings.SaveStatus != SaveStatus.Save)
            {
                return;
            }
            string textNode = GetTextNode(editingSettings);
            TreeNodeWithSetting treeNode = new TreeNodeWithSetting(NodeType.Setting, textNode);
            treeNode.DS360Setting = editingSettings.DS360Setting;
            if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
            {
                treRouteTree.Nodes.Add(treeNode);
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            SelectedNodeWithSetup.Nodes.Add(treeNode);
            SelectedNodeWithSetup.Expand();

        }

        private static string GetTextNode(frmCreationEditingSettings editingSettings)
        {
            string textNode = string.Empty;
            textNode += "[" + editingSettings.cboTypeSignal.Text + "] ";
            textNode += "[Кп = " + editingSettings.txtConversionFactor.Text + "] ";
            textNode += "[" + editingSettings.cboSetValue.Text + "] ";
            textNode += "[1" + editingSettings.cboDetector.Text + " = ";
            textNode += editingSettings.txtValue.Text + "] ";
            textNode += "[1F = " + editingSettings.txtFrequency.Text + "] ";
            if (editingSettings.txtValue2.Text != "" && editingSettings.txtValue2.Text != string.Empty)
            {
                textNode += "[2" + editingSettings.cboDetector2.Text + " = ";
                textNode += editingSettings.txtValue2.Text + "] ";
                textNode += "[2F = " + editingSettings.txtFrequency2.Text + "] ";
            }
            textNode += "[Offset = " + editingSettings.txtOffset.Text + "] ";
            return textNode;
        }
        /// <summary>
        /// редактирование настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditSetting_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode == null || (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Folder)
            {
                MessageBox.Show("Не выбрана настройка для редактирования");
                return;
            }
            TreeNodeWithSetting selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            configureEditingSettings(selectedNode, editingSettings);
            editingSettings.FormClosed += new FormClosedEventHandler(editingSettings_FormClosed);
            editingSettings.ShowDialog();
            if (editingSettings.SaveStatus != SaveStatus.Save)
            {
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            string textNode = GetTextNode(editingSettings);
            SelectedNodeWithSetup.Text = textNode;
            SelectedNodeWithSetup.DS360Setting = editingSettings.DS360Setting;
        }

        private void configureEditingSettings(TreeNodeWithSetting selectedNode, frmCreationEditingSettings editingSettings)
        {
            editingSettings.Text = "Конструирование настройки";
            editingSettings.Type = Type.Change;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.InitializecboDetector();
            editingSettings.InitializecboDetector2();
            editingSettings.InitializecboSetValue();
            editingSettings.InitializecboTypeSignal();
            editingSettings.cboDetector.SelectedItem = PmData.Detector[(Detector)selectedNode.DS360Setting.SignalParametrTone1];
            editingSettings.cboDetector2.SelectedItem = PmData.Detector[(Detector)selectedNode.DS360Setting.SignalParametrTone2];
            editingSettings.txtConversionFactor.Text = selectedNode.DS360Setting.Sensitivity.Get_mV_G().ToString();
            editingSettings.txtFrequency.Text = selectedNode.DS360Setting.Frequency.ToString();
            editingSettings.txtFrequency2.Text = selectedNode.DS360Setting.FrequencyB.ToString();
            editingSettings.txtOffset.Text = selectedNode.DS360Setting.Offset.ToString();
            ConfigureToVibroparam(selectedNode, editingSettings);
            editingSettings.cboTypeSignal.SelectedItem = PmData.FunctionTypeSignal[(FunctionTypeSignal)selectedNode.DS360Setting.FunctionType];
        }

        private static void ConfigureToVibroparam(TreeNodeWithSetting selectedNode, frmCreationEditingSettings editingSettings)
        {
            VibroCalc.Frequency.Set_Hz(selectedNode.DS360Setting.Frequency);
            VibroCalc.Sensitivity.Set_mV_G(selectedNode.DS360Setting.Sensitivity.Get_mV_G());
            if (selectedNode.DS360Setting.VibroParametr is Voltage)
            {
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Voltage.Get(selectedNode.DS360Setting.SignalParametrTone1).ToString();
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMSToneB, SignalParametrType.RMS));
                editingSettings.txtValue2.Text = VibroCalc.Voltage.Get(selectedNode.DS360Setting.SignalParametrTone2).ToString();
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.U];
            }
            if (selectedNode.DS360Setting.VibroParametr is Velocity)
            {

                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Velocity.Get(selectedNode.DS360Setting.SignalParametrTone1).ToString();
                VibroCalc.Frequency.Set_Hz(selectedNode.DS360Setting.FrequencyB);
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMSToneB, SignalParametrType.RMS));
                editingSettings.txtValue2.Text = VibroCalc.Velocity.Get(selectedNode.DS360Setting.SignalParametrTone2).ToString();
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.мм_с];
            }
            if (selectedNode.DS360Setting.VibroParametr is Acceleration)
            {
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Acceleration.Get(selectedNode.DS360Setting.SignalParametrTone1).ToString();
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMSToneB, SignalParametrType.RMS));
                editingSettings.txtValue2.Text = VibroCalc.Acceleration.Get(selectedNode.DS360Setting.SignalParametrTone2).ToString();
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.м_с2];
            }
            if (selectedNode.DS360Setting.VibroParametr is Displacement)
            {
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMS, SignalParametrType.RMS));
                editingSettings.txtValue.Text = VibroCalc.Displacement.Get(selectedNode.DS360Setting.SignalParametrTone1).ToString();
                VibroCalc.Frequency.Set_Hz(selectedNode.DS360Setting.FrequencyB);
                VibroCalc.CalcAll(new Voltage(selectedNode.DS360Setting.AmplitudeRMSToneB, SignalParametrType.RMS));
                editingSettings.txtValue2.Text = VibroCalc.Displacement.Get(selectedNode.DS360Setting.SignalParametrTone2).ToString();
                editingSettings.cboSetValue.SelectedItem = PmData.PhysicalQuantity[PhysicalQuantity.мкм];
            }
        }

        private void butUp_Click(object sender, EventArgs e)
        {
            //переместить настройку вверх по списку

        }

        private void butDown_Click(object sender, EventArgs e)
        {
            //переместить настройку вниз по списку

        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            string pathDyrectoryForRouteFile = DAO.GetFolderNameDialog("Выберите папку для сохранения маршрута.");
            //записать маршрут в файл (имена и настройки)



            //DAO.SerializeObject obj = new SerializeObject();
            List<TreeNode> treeNodes = new List<TreeNode>();
            //treeNodes.AddRange(treRouteTree.Nodes.)



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
        private void lstRouteTree_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblRouteTree_Click(object sender, EventArgs e)
        {

        }

        internal void lblSave_Click(object sender, EventArgs e)
        {
            //лейбл успешного сохранения
        }

        private void butAllDelete_Click(object sender, EventArgs e)
        {
            //удалить всё
            treRouteTree.Nodes.Clear();
            PhysicalQuantity physicalQuantity = PmData.GetEnumFromString(PmData.PhysicalQuantity, "м/c²");
        }
    }
}
