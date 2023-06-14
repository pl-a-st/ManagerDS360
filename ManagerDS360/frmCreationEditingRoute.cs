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

        Timer timer;

        List<TreeNode> checkedNodes = new List<TreeNode>();
        public frmCreationEditingRoute()
        {
            InitializeComponent();
        }

        public void frmCreationEditingRoute_Load(object sender, EventArgs e)
        {
            PushListBox();
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
                treRouteTree.SelectedNode = treeNodeWihtSetting;
                return;
            }
            TreeNodeWithSetting SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetting;
            SelectedNodeWithSetup.Nodes.Add(treeNodeWihtSetting);
            SelectedNodeWithSetup.Expand();
           treRouteTree.SelectedNode = treeNodeWihtSetting;
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
            textNode += "[" + editingSettings.cboTypeSignal.Text + "]  ";
            textNode += "[Кп:" + editingSettings.txtConversionFactor.Text + "]  ";
            textNode += "[" + editingSettings.cboSetValue.Text + "]  ";
            textNode += "T1: ";
            textNode += "[" + editingSettings.cboDetector.Text + ":";
            textNode += editingSettings.txtValue.Text;
            textNode += "  F:" + editingSettings.txtFrequency.Text + "]  ";
            if (editingSettings.IsTwoTone())
            {
                textNode += "T2: ";
                textNode += "[" + editingSettings.cboDetector2.Text + ":";
                textNode += editingSettings.txtValue2.Text;
                textNode += "  F:" + editingSettings.txtFrequency2.Text + "]  ";
            }
            textNode += "[Offset:" + editingSettings.txtOffset.Text + "]";
            return textNode;
        }
        /// <summary>
        /// редактирование настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditSetting_Click(object sender, EventArgs e)
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
                editingSettings.FormClosed += new FormClosedEventHandler(editingSettings_FormClosed);
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

        }

        private void СonfigureEditingSettings(DS360SettingVibroSigParam dS360, frmCreationEditingSettings editingSettings)
        {
            DS360SettingConvert_V_to_mV(dS360);

            editingSettings.Text = "Конструирование настройки";
            editingSettings.Type = Type.Change;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.InitializecboDetector();
            editingSettings.InitializecboDetector2();
            editingSettings.InitializecboSetValue();
            editingSettings.InitializecboTypeSignal();
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
                editingSettings.txtValue.Text = VibroCalc.Voltage.Get(dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = VibroCalc.Voltage.Get(dS360.SignalParametrTone2).ToString();
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
                editingSettings.txtValue.Text = VibroCalc.Acceleration.Get(dS360.SignalParametrTone1).ToString();
                if (editingSettings.IsTwoTone())
                {
                    VibroCalc.CalcAll(new Voltage(dS360.AmplitudeRMSToneB, SignalParametrType.RMS));
                    editingSettings.txtValue2.Text = VibroCalc.Acceleration.Get(dS360.SignalParametrTone2).ToString();
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
        /// <summary>
        /// //переместить настройку вверх по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butUp_Click(object sender, EventArgs e)
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
        /// <summary>
        /// //переместить настройку вниз по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butDown_Click(object sender, EventArgs e)
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

        internal void butSave_Click(object sender, EventArgs e)
        {
            if (txtNameRoute.Text == "" || txtNameRoute.Text == string.Empty)
            {
                MessageBox.Show("Не введено название маршрута!");
                return;
            }
            string fullFilePath =string.Empty;
            if (TypeFormOpen == TypeFormOpen.ToСreate)
            {
                string pathDyrectoryForRouteFile = DAO.GetFolderNameDialog("Выберите папку для сохранения маршрута.", out MethodResultStatus resultStatus);
                if (resultStatus != MethodResultStatus.Ok)
                {
                    MessageBox.Show("Не выбран путь для сохранения!");
                    return;
                }
                fullFilePath = pathDyrectoryForRouteFile + @"\" + txtNameRoute.Text + ".rout";
            }
            if (TypeFormOpen == TypeFormOpen.ToChange)
            {
                fullFilePath = FileInfo.FullName;
            }
            TreeNodeWithSetting[] treeNodeWithSettings = new TreeNodeWithSetting[treRouteTree.Nodes.Count];
            treRouteTree.Nodes.CopyTo(treeNodeWithSettings, 0);
            if (DAO.binWriteObjectToFile(treeNodeWithSettings, fullFilePath) == MethodResultStatus.Fault)
            {
                MessageBox.Show($"Не удалось записать файл {fullFilePath}");
                return;
            }
            if (TypeFormOpen == TypeFormOpen.ToСreate)
            {
                FileInfo routFile = new FileInfo(fullFilePath);
                PmData.RouteAddresses.Add(routFile);
                DAO.binWriteObjectToFile(PmData.RouteAddresses, DAO.GetApplicationDataPath(PmData.FileNameRouteAddresses));
            }
            MessageBox.Show("Файл маршрута успешно сохранен!");
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
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            SaveName = SaveName.Cancel;
            this.Close();
        }
    }
}
