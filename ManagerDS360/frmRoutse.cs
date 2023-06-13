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
        List<FileInfo> listRoutesFiles = new List<FileInfo>();

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
            ReloadLstRoutes();

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
            if (lstSaveRoutes.SelectedIndex == -1)
            {
                return;
            }
            if (MessageBox.Show("Удалить маршрут из списка маршрутов?", "Сообщение", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            PmData.RouteAddresses.RemoveAt(lstSaveRoutes.SelectedIndex);
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
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
            newfrmCreationEditingRoute.TypeFormOpen = TypeFormOpen.ToСreate;
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
            FileInfo routeFileInfo = PmData.RouteAddresses[lstSaveRoutes.SelectedIndex];
            string fileRoutePath = routeFileInfo.FullName;
            string RoutName = routeFileInfo.Name.Replace(routeFileInfo.Extension, "");
            frmCreationEditingRoute newfrmCreationEditingRoute = new frmCreationEditingRoute();
            newfrmCreationEditingRoute.TypeFormOpen = TypeFormOpen.ToChange;
            newfrmCreationEditingRoute.txtNameRoute.Text = RoutName;
            newfrmCreationEditingRoute.txtNameRoute.Enabled = false;
            newfrmCreationEditingRoute.treRouteTree.LoadTreeNodesWithSeetings(routeFileInfo);
            newfrmCreationEditingRoute.FileInfo = routeFileInfo;
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

        private void butAddRout_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "|*.rout";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            PmData.RouteAddresses.Add(new FileInfo(fileDialog.FileName));
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
        }
    }
}
