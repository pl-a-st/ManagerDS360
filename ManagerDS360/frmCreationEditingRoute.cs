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
        private DS360SettingVibroSigParam LastDS360Setting;

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
            this.Refresh();
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

        public static class StaticName
        {
            //Статическая переменная, выступающая как буфер данных для имени настройки
            public static String nameBuffer = String.Empty;
        }

        private void Form_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.S)    // добавить настройку
            {
                AddSetting();
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
            if (e.KeyCode == Keys.Up)    //вверх  
            {
                Up();
            }
            if (e.KeyCode == Keys.Down)    //вниз  
            {
                Down();
            }
        }

        internal void butAddSetting_Click(object sender, EventArgs e)
        {
            AddSetting();
        }

        private void AddSetting()
        {
            if (treRouteTree.SelectedNode != null && (treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType == NodeType.Setting)
            {
                MessageBox.Show("Настройка не может содержать другие элементы!");
                return;
            }
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = CallType.Create;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.FormClosed += new FormClosedEventHandler(editingSettings_FormClosed);
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
        /// <summary>
        /// редактирование настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditSetting_Click(object sender, EventArgs e)
        {
            EditSetting();
        }

        private void EditSetting()
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
                DAO.binWriteObjectToFile(PmData.RouteAddresses, DAO.GetApplicationDataPath(PmData.FileNameRouteAddresses));
            }
            if (MessageBox.Show("Файл маршрута успешно сохранен! Закртыть окно редактирования?", "Сообщение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
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

        private void picButUp_Click(object sender, EventArgs e)
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

        private void picButDown_Click(object sender, EventArgs e)
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

        private void butCpopy_Click(object sender, EventArgs e)
        {
            treRouteTree.CopySelectedNode();
        }

        private void butPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void Paste()
        {
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Folder)
            {
                MessageBox.Show("Настройка не может содержать другие элементы!");
                return;
            }
            treRouteTree.PasteCopyTreeNode();
        }

        private void butUp_Click_1(object sender, EventArgs e)
        {
            Up();
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
            Down();
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
            butUp.BackgroundImage = Properties.Resources.Стрелка_вверх2;
        }

        private void butUp_MouseLeave(object sender, EventArgs e)
        {
            butUp.BackgroundImage = Properties.Resources.Стрелка_вверх1;
        }

        private void butDown_MouseEnter(object sender, EventArgs e)
        {
            butDown.BackgroundImage = Properties.Resources.Стрелка_вниз2;
        }

        private void butDown_MouseLeave(object sender, EventArgs e)
        {
            butDown.BackgroundImage = Properties.Resources.Стрелка_вниз1;
        }
    }
}
