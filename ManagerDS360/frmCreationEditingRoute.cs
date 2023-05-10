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

namespace ManagerDS360
{
    public enum SaveName
    {
        SaveName,
        Cancel
    }
    public partial class frmCreationEditingRoute : Form
    {
        public SaveName SaveName;

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
            lblSave.Visible = false;

            List<DS360Setting> dS360Settings = new List<DS360Setting>();

        }

        private void PushListBox()
        {
            //lstRouteTree.Items.Clear();
            //foreach (Entry entry1 in ProgramData.Entries)
            //{

            //}
        }

        private void butAddFolder_Click(object sender, EventArgs e)
        {
            //кнопка добавить папку
            //SaveName = SaveName.Cancel;
            frmInputName frmInputName = new frmInputName();
            frmInputName.ShowDialog();

            if (frmInputName.SaveName == SaveName.SaveName)
            {

                string nameSet = frmInputName.txtNameSet.Text;
                TreeNodeWithSetup treeNodeWithSetup = new TreeNodeWithSetup(nameSet);

                if (treRouteTree.Nodes.Count == 0 || treRouteTree.SelectedNode == null)
                {
                    treRouteTree.Nodes.Add(treeNodeWithSetup);

                    return;
                }
                TreeNodeWithSetup SelectedNodeWithSetup = treRouteTree.SelectedNode as TreeNodeWithSetup;
                SelectedNodeWithSetup.Nodes.Add(treeNodeWithSetup);
                SelectedNodeWithSetup.Expand();

                //treeNodeWithSetup. = true;
            }
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

        internal void butAddSetting_Click(object sender, EventArgs e)
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = Type.Change;
            editingSettings.ShowDialog();

            DS360Setting dS360Setting = new DS360Setting();
            

            double freq1;
            double freq2;
            double voltage = editingSettings.Voltage;

            if (editingSettings.SaveStatus == SaveStatus.Save)
            {

                if (!double.TryParse(editingSettings.txtFrequency.Text, out freq1))
                {
                    MessageBox.Show("Не удалось преобразовать в double");
                    editingSettings.ShowDialog();
                }
                if (!double.TryParse(editingSettings.txtFrequency2.Text, out freq2))
                {
                    MessageBox.Show("Не удалось преобразовать в double");
                    editingSettings.ShowDialog();
                }

            }
            //if (editingSettings.cboTypeSignal.Items == cboTypeSignal.Items.TwoTone)
            //{
            //    //ветка для двух тонов
            //}
            //else //ветка для одного тона
            //{
            //    if (editingSettings.chcDefaultGenerator.IsCheck)
            //    {
            //        dS360Setting = new DS360Setting(voltage);
            //    }

            //    if (!editingSettings.chcDefaultGenerator.IsCheck)
            //    {
            //        dS360Setting = new DS360Setting(voltage);
            //    }
            //}


                //TreeNode treeNode = new TreeNode();
                //treeNode.setup = dS360Setting;
                //treRouteTree.Nodes.Add(treeNode);
                //newfrmCreationEditingSettings.cbo

                ///*treRouteTree*/.Nodes.Add()
        }

        private void butEditSetting_Click(object sender, EventArgs e)
        {
            //редактировать строку c настройкой
        }

        private void butUp_Click(object sender, EventArgs e)
        {
            //переместить вверх по списку

        }

        private void butDown_Click(object sender, EventArgs e)
        {
            //переместить вниз по списку

        }

        internal void butSave_Click(object sender, EventArgs e)
        {
            string pathDyrectoryForRouteFile = DAO.GetFolderNameDialog("Выберите папку для сохранения маршрута.");
            //записать файл с именем и настройками

            //DAO.SerializeObject obj = new SerializeObject();
            List<TreeNode> treeNodes = new List<TreeNode>();
            //treeNodes.AddRange(treRouteTree.Nodes.)



        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            //удалить строку-настройку из файла с маршрутами
            //treRouteTree.Nodes.Clear();
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
            TreeNode node = e.Node;
            if (node == null)
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
    }
}
