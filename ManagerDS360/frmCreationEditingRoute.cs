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

        private void butAddFolder_Click(object sender, EventArgs e)
        {
            //кнопка добавить папку
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
            }
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

        internal void butAddSetting_Click(object sender, EventArgs e)
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = Type.Change;
            editingSettings.SaveStatus = SaveStatus.Cancel;
            editingSettings.FormClosed += new FormClosedEventHandler(editingSettings_FormClosed);
            editingSettings.Text = "Конструирование настройки";
            editingSettings.ShowDialog();
            if (editingSettings.SaveStatus != SaveStatus.Save)
            {
                return;
            }
            TreeNodeWithSeting treeNode = new TreeNodeWithSeting();
            
            treeNode.DS360Setting= editingSettings.DS360Setting;
            treeNode.Name = "Заглушка";
            treeNode.Text = "Текст заглушка";
            treRouteTree.Nodes.Add(treeNode);
            
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
        }
    }
}
