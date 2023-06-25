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
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;

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
            SelectLstRoutes();

        }

        private void SelectLstRoutes()
        {
            lstSaveRoutes.Select();
            if (lstSaveRoutes.Items.Count != 0)
            {
                lstSaveRoutes.SelectedIndex = 0;
            }
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
            SelectLstRoutes();
        }

        private void lblSavedRoutes_Click(object sender, EventArgs e)
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
            SelectLstRoutes();
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
            SelectLstRoutes();
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
            SelectLstRoutes();
        }

        private void butRenameRoute_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSaveRoutes.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            FileInfo routeFileInfo = PmData.RouteAddresses[selectedIndex];
            frmInputName frmInputName = new frmInputName();
            frmInputName.label1.Text = "Введите новое имя маршрута";
            frmInputName.ShowDialog();
            if (frmInputName.SaveName != SaveName.SaveName)
            {
                return;
            }
            string newFullFile = routeFileInfo.DirectoryName + @"\" + frmInputName.txtNameSet.Text + @".rout";
            try
            {
                File.Move(routeFileInfo.FullName, newFullFile);
                MessageBox.Show("Файл переименован");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Не удалось переименовать файл {routeFileInfo.FullName}");
                return;
            }
            PmData.RouteAddresses[selectedIndex] = new FileInfo(newFullFile);
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
            SelectLstRoutes();
        }

        private void butCopyRoute_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstSaveRoutes.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            FileInfo routeFileInfo = PmData.RouteAddresses[selectedIndex];
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Введите новое название файла";
            string newFullFile = string.Empty;

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Не выбрана папка для копирования маршрута");
                return;
            }
            newFullFile = fileDialog.FileName;
            if (!newFullFile.EndsWith(".rout"))
            {
                newFullFile += ".rout";
            }
            try
            {
                File.Copy(routeFileInfo.FullName, newFullFile, true);
                MessageBox.Show("Файл скопирован");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Не удалось скопировать файл {routeFileInfo.FullName}");
                return;
            }
            AddFileInfoToRouteAddresses(newFullFile);
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
        }

        private static void AddFileInfoToRouteAddresses(string newFullFile)
        {
            foreach (var fileInfo in PmData.RouteAddresses)
            {
                if (fileInfo.FullName == newFullFile)
                {
                    return;
                }

            }
            PmData.RouteAddresses.Add(new FileInfo(newFullFile));
        }

        private void lstSaveRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void butUp_Click(object sender, EventArgs e)
        {
            int selectIndex = lstSaveRoutes.SelectedIndex;
            if (selectIndex < 1)
            {
                return;
            }
            FileInfo fileInfo = PmData.RouteAddresses[selectIndex];
            PmData.RouteAddresses.RemoveAt(selectIndex);
            PmData.RouteAddresses.Insert(selectIndex - 1, fileInfo);
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
            lstSaveRoutes.SelectedIndex = selectIndex - 1;
        }

        private void butDown_Click(object sender, EventArgs e)
        {
            int selectIndex = lstSaveRoutes.SelectedIndex;
            if (selectIndex == -1 || selectIndex == lstSaveRoutes.Items.Count - 1)
            {
                return;
            }
            FileInfo fileInfo = PmData.RouteAddresses[selectIndex];
            PmData.RouteAddresses.RemoveAt(selectIndex);
            PmData.RouteAddresses.Insert(selectIndex + 1, fileInfo);
            PmData.SaveRouteAddresses();
            ReloadLstRoutes();
            lstSaveRoutes.SelectedIndex = selectIndex + 1;
        }
    }
}
