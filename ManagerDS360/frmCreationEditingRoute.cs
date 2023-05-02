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
    public partial class frmCreationEditingRoute : Form
    {
        public frmCreationEditingRoute()
        {
            InitializeComponent();
        }

        private void frmCreationEditingRoute_Load(object sender, EventArgs e)
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

        private void butAddFolder_Click(object sender, EventArgs e)
        {
            //кнопка добавить папку
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

        private void butSave_Click(object sender, EventArgs e)
        {
            //string pathDyrectoryForRouteFile = DAO.GetFolderNameDialog("Выберите папку для сохранения маршрута.");
            //записать файл с именем и настройками
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            //удалить строку-настройку из файла с маршрутами

        }

        private void lstRouteTree_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblRouteTree_Click(object sender, EventArgs e)
        {

        }

        private void treRouteTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //дерево маршрутов со строками

        }
    }
}
