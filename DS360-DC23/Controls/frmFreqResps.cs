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
    public partial class frmFreqResps : Form
    {
        List<FileInfo> listRoutesFiles = new List<FileInfo>();

        public frmFreqResps()
        {
            InitializeComponent();
        }

        private void frmEditingRoutes_Load(object sender, EventArgs e)
        {
            ReloadLstFreqResp();
            SelectLstFreqResp();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.butCreateFreqResp, "ALT+S ");
            toolTip1.SetToolTip(this.butDeleteFreqResp, "CTRL+D ");
            toolTip1.SetToolTip(this.butEditingFreqResp, "CTRL+E ");
            toolTip1.SetToolTip(this.butRenameFreqResp, "CTRL+R ");
            toolTip1.SetToolTip(this.butCopyFreqResp, "CTRL+С ");
            toolTip1.SetToolTip(this.butSearchFreqResp, "CTRL+F");
            toolTip1.SetToolTip(this.butUp, "U");
            toolTip1.SetToolTip(this.butDown, "J");
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.S)    // создать
            {
                CreateFreqResps();
            }
            if (e.Control == true && e.KeyCode == Keys.D)    // удалить
            {
                DeleteFreqResp();
            }
            if (e.Control == true && e.KeyCode == Keys.E)    // редактировать
            {
                EditinFreqResp();
            }
            if (e.Control == true && e.KeyCode == Keys.R)    // переименовать
            {
                RenameFreqResp();
            }
            if (e.Control == true && e.KeyCode == Keys.C)    // копировать
            {
                CopyFreqResp();
            }
            if (e.Control == true && e.KeyCode == Keys.F)    // поиск
            {
                SearchFreqResp();
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

        private void SelectLstFreqResp()
        {
            lstSaveFreqResp.Select();
            if (lstSaveFreqResp.Items.Count != 0)
            {
                lstSaveFreqResp.SelectedIndex = 0;
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

        private void butFrqResp_Click(object sender, EventArgs e)
        {
            DeleteFreqResp();
        }

        private void DeleteFreqResp()
        {
            if (lstSaveFreqResp.SelectedIndex == -1)
            {
                return;
            }
            if (MessageBox.Show("Удалить маршрут из списка маршрутов?", "Сообщение", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            PmData.FreqRespAddresses.RemoveAt(lstSaveFreqResp.SelectedIndex);
            PmData.SaveFreqRespAddresses();
            ReloadLstFreqResp();
            SelectLstFreqResp();
        }

        private void lblSavedRoutes_Click(object sender, EventArgs e)
        {
        }

        private void butCreateRoutes_Click(object sender, EventArgs e)
        {
            CreateFreqResps();
        }

        private void CreateFreqResps()
        {
            //создание нового маршрута
            frmCreationEditingFreqResp frmCreationEditingFreqResp = new frmCreationEditingFreqResp();
            frmCreationEditingFreqResp.TypeFormOpen = TypeFormOpen.ToСreate;
            frmCreationEditingFreqResp.ShowDialog();
            ReloadLstFreqResp();
            SelectLstFreqResp();
        }

        private void ReloadLstFreqResp()
        {
            lstSaveFreqResp.Items.Clear();
            foreach (var file in PmData.FreqRespAddresses)
            {
                lstSaveFreqResp.Items.Add(file.Name);
            }
        }
        /// <summary>
        /// редактирование маршрута
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEditingRoute_Click(object sender, EventArgs e)
        {
            EditinFreqResp();
        }

        private void EditinFreqResp()
        {
            if (lstSaveFreqResp.SelectedIndex == -1)
            {
                return;
            }
            FileInfo routeFileInfo = PmData.FreqRespAddresses[lstSaveFreqResp.SelectedIndex];
            //string fileRoutePath = routeFileInfo.FullName;
            string FreqRespName = routeFileInfo.Name.Replace(routeFileInfo.Extension, "");
            frmCreationEditingFreqResp form = new frmCreationEditingFreqResp();
            form.TypeFormOpen = TypeFormOpen.ToChange;
            form.txtNameFreqResp.Text = FreqRespName;
            form.txtNameFreqResp.Enabled = false;

            form.FreqResp = DAO.binReadFileToObject(form.FreqResp, routeFileInfo.FullName, out MethodResultStatus result);
            
            form.FileInfo = routeFileInfo;
            form.ShowDialog();
            ReloadLstFreqResp();
            SelectLstFreqResp();
        }

        private void butSearchRoute_Click(object sender, EventArgs e)
        {
            SearchFreqResp();
        }

        private void SearchFreqResp()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "|*.fresp";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            PmData.FreqRespAddresses.Add(new FileInfo(fileDialog.FileName));
            PmData.SaveFreqRespAddresses();
            ReloadLstFreqResp();
            SelectLstFreqResp();
        }

        private void butRenameRoute_Click(object sender, EventArgs e)
        {
            RenameFreqResp();
        }

        private void RenameFreqResp()
        {
            int selectedIndex = lstSaveFreqResp.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            FileInfo routeFileInfo = PmData.FreqRespAddresses[selectedIndex];
            frmInputName frmInputName = new frmInputName();
            frmInputName.label1.Text = "Введите новое имя АЧХ";
            frmInputName.ShowDialog();
            if (frmInputName.SaveName != SaveName.SaveName)
            {
                return;
            }
            string newFullFile = routeFileInfo.DirectoryName + @"\" + frmInputName.txtNameSet.Text + @".fresp";
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
            PmData.FreqRespAddresses[selectedIndex] = new FileInfo(newFullFile);
            PmData.SaveFreqRespAddresses();
            ReloadLstFreqResp();
            SelectLstFreqResp();
        }

        private void butCopyRoute_Click(object sender, EventArgs e)
        {
            CopyFreqResp();
        }

        private void CopyFreqResp()
        {
            int selectedIndex = lstSaveFreqResp.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            FileInfo routeFileInfo = PmData.FreqRespAddresses[selectedIndex];
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Введите новое название файла";
            string newFullFile = string.Empty;

            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Не выбрана папка для копирования маршрута");
                return;
            }
            newFullFile = fileDialog.FileName;
            if (!newFullFile.EndsWith(".fresp"))
            {
                newFullFile += ".fresp";
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
            AddFileInfoToFreqRespAddresses(newFullFile);
            PmData.SaveRouteAddresses();
            ReloadLstFreqResp();
        }

        private static void AddFileInfoToFreqRespAddresses(string newFullFile)
        {
            foreach (var fileInfo in PmData.FreqRespAddresses)// todo проверить необходимость цикла
            {
                if (fileInfo.FullName == newFullFile)
                {
                    return;
                }

            }
            PmData.FreqRespAddresses.Add(new FileInfo(newFullFile));
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
            int selectIndex = lstSaveFreqResp.SelectedIndex;
            if (selectIndex < 1)
            {
                return;
            }
            FileInfo fileInfo = PmData.RouteAddresses[selectIndex];
            PmData.RouteAddresses.RemoveAt(selectIndex);
            PmData.RouteAddresses.Insert(selectIndex - 1, fileInfo);
            PmData.SaveRouteAddresses();
            ReloadLstFreqResp();
            lstSaveFreqResp.SelectedIndex = selectIndex - 1;
        }

        private void butDown_Click(object sender, EventArgs e)
        {
            but_Down_C();
        }

        private void but_Down_C()
        {
            int selectIndex = lstSaveFreqResp.SelectedIndex;
            if (selectIndex == -1 || selectIndex == lstSaveFreqResp.Items.Count - 1)
            {
                return;
            }
            FileInfo fileInfo = PmData.RouteAddresses[selectIndex];
            PmData.RouteAddresses.RemoveAt(selectIndex);
            PmData.RouteAddresses.Insert(selectIndex + 1, fileInfo);
            PmData.SaveRouteAddresses();
            ReloadLstFreqResp();
            lstSaveFreqResp.SelectedIndex = selectIndex + 1;
        }

        private void frmFreqResps_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
