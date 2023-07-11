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
using ToolTip = System.Windows.Forms.ToolTip;

namespace ManagerDS360
{
    public partial class frmEditingRoutes : Form
    {
        List<FileInfo> listRoutesFiles = new List<FileInfo>();

        public frmEditingRoutes()
        {
            InitializeComponent();
        }

        private void frmEditingRoutes_Load(object sender, EventArgs e)
        {
            ReloadLstRoutes();
            SelectLstRoutes();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.butCreateRoutes, "ALT+S ");
            toolTip1.SetToolTip(this.butDeleteRoute, "CTRL+D ");
            toolTip1.SetToolTip(this.butEditingRoute, "CTRL+E ");
            toolTip1.SetToolTip(this.butRenameRoute, "CTRL+R ");
            toolTip1.SetToolTip(this.butCopyRoute, "CTRL+С ");
            toolTip1.SetToolTip(this.butSearchRoute, "CTRL+F");
            toolTip1.SetToolTip(this.butUp, "U");
            toolTip1.SetToolTip(this.butDown, "J");
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.S)    // создать
            {
                CreateRoutes();
            }
            if (e.Control == true && e.KeyCode == Keys.D)    // удалить
            {
                DeleteRoute();
            }
            if (e.Control == true && e.KeyCode == Keys.E)    // редактировать
            {
                EditingRoute();
            }
            if (e.Control == true && e.KeyCode == Keys.R)    // переименовать
            {
                RenameRoute();
            }
            if (e.Control == true && e.KeyCode == Keys.C)    // копировать
            {
                CopyRoute();
            }
            if (e.Control == true && e.KeyCode == Keys.F)    // поиск
            {
                SearchRoute();
            }
            if (e.KeyCode == Keys.U)    //вверх  
            {
                but_Up_C();
            }
            if (e.KeyCode == Keys.J)    //вниз  
            {
                but_Down_C();
            }
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
        //private void TreeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    TreeNode node = e.Node;
        //    if (node == null)
        //    {
        //        return;
        //    }
        //}

        private void butDeleteRoute_Click(object sender, EventArgs e)
        {
            DeleteRoute();
        }

        private void DeleteRoute()
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

        private void butCreateRoutes_Click(object sender, EventArgs e)
        {
            CreateRoutes();
        }

        private void CreateRoutes()
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
            EditingRoute();
        }

        private void EditingRoute()
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

        private void butSearchRoute_Click(object sender, EventArgs e)
        {
            SearchRoute();
        }

        private void SearchRoute()
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
            RenameRoute();
        }

        private void RenameRoute()
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
            CopyRoute();
        }

        private void CopyRoute()
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
            but_Up_C();
        }

        private void but_Up_C()
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
            but_Down_C();
        }

        private void but_Down_C()
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
