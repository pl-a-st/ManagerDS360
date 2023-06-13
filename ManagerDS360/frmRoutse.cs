using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LibControls;

namespace ManagerDS360
{
    public partial class frmEditingRoutes : Form
    {
        List<FileInfo>listRoutesFiles = new List<FileInfo>();

        public frmEditingRoutes()
        {
            InitializeComponent();
        }

        private void butDownRoute_Click(object sender, EventArgs e)
        {
            //перемещение вниз
        }

        private void butUpRoute_Click(object sender, EventArgs e)
        {
            //перемещение вверх
        }

        private void frmEditingRoutes_Load(object sender, EventArgs e)
        {
            //DirectoryInfo directoryInfo = new DirectoryInfo();  //"W:\\8.Технический отдел\\Общая\\Группа C#\\Папка пользователя");
            //if (!directoryInfo.Exists)
            //{
            //    MessageBox.Show("Нет данных о созданных маршрутах!", "Внимание"); 
            //    return;
            //}

            //listRoutesFiles.AddRange(new DirectoryInfo("E:\\SteamLibrary").GetFiles());
            //listRoutesFiles.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#").GetFiles());
            ReloadLstRoutes();

            butUpRoute.Enabled = false;
            butDownRoute.Enabled = false;

            butDeleteRoute.Enabled = false;
            //butEditingRoute.Enabled = false;
            //butSaveRoutes.Enabled = false;
 
        }
        //выбор элемента treeView
        private void TreeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null)
            {
                return;
            }
        }

        private void lstsaveroutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butDeleteRoute_Click(object sender, EventArgs e)
        {
            //удаление маршрута-строки из листа

        }

        private void lblSavedRoutes_Click(object sender, EventArgs e)
        {

        }

        private void sbrHorizontalSaveRoutes_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void sbrVerticalSaveRoutes_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void butSaveRoutes_Click(object sender, EventArgs e)
        {
            //сохранить список маршрутов и их порядок
        }

        private void butCreateRoutes_Click(object sender, EventArgs e)
        {
            //создание нового маршрута
            frmCreationEditingRoute newfrmCreationEditingRoute = new frmCreationEditingRoute();
            newfrmCreationEditingRoute.ShowDialog();
            ReloadLstRoutes();
        }

        private void ReloadLstRoutes()
        {
            lstSaveRoutes.Items.Clear();
            foreach (var file in PmData.RouteAddresses)
            {
                lstSaveRoutes.Items.Add(file.Name);
            }
        }
        /// <summary>
        /// //редактирование маршрута
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditingRoute_Click(object sender, EventArgs e)
        {
            if (lstSaveRoutes.SelectedIndex == -1)
            {
                return;
            }
            string fileRoutePath = PmData.RouteAddresses[lstSaveRoutes.SelectedIndex].FullName;
            frmCreationEditingRoute newfrmCreationEditingRoute = new frmCreationEditingRoute();
            newfrmCreationEditingRoute.txtNameRoute.Enabled = false;
            TreeNodeWithSetting[] treeNodeWithSettings = null;
            newfrmCreationEditingRoute.treRouteTree.Nodes.AddRange(DAO.binReadFileToObject(treeNodeWithSettings, fileRoutePath, out MethodResultStatus methodResultStatus));
            newfrmCreationEditingRoute.ShowDialog();
            ReloadLstRoutes();
        }

        private void treSaveRoutes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //список сохранённых маршрутов
        }

        private void lblSaveRoutes_Click(object sender, EventArgs e)
        {

        }
    }
}
