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

namespace ManagerDS360
{
    public partial class frmCreationEditingRoute : Form
    {
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
            treRouteTree.Nodes.Add(new TreeNode("Настройка Х"));
        }

        private void lblRouteName_Click(object sender, EventArgs e)
        {

        }

        private void txtNameRoute_TextChanged(object sender, EventArgs e)
        {
            //название маршрута
        }

        private void butAddSetting_Click(object sender, EventArgs e)
        {
            frmCreationEditingSettings newfrmCreationEditingSettings = new frmCreationEditingSettings();
            newfrmCreationEditingSettings.Type = Type.Change;
            newfrmCreationEditingSettings.ShowDialog();
        }

        private void butEditSetting_Click(object sender, EventArgs e)
        {
            //редактировать строку
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
            TreeNode selectedNode = treRouteTree.SelectedNode;
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
                else
                {
                    RemoveCheckedNodes(node.Nodes);
                }
            }
            foreach (TreeNode checkedNode in checkedNodes)
            {
                nodes.Remove(checkedNode);
            }
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
    }
}
