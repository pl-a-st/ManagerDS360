using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibControls;
using LibDevicesManager;

namespace ManagerDS360
{
    public partial class frmManagerDS360 : Form
    {
        public frmManagerDS360()
        {
            InitializeComponent();

        }

        //по крестику спрашивает, закрыть или нет окно
        private void frmManagerDS360_Closing(object sender, FormClosingEventArgs e)
        {
            //проверка на выходе из ПО
            //DialogResult dialog = MessageBox.Show(
            // "Вы действительно хотите выйти из программы?",
            // "Завершение программы",
            // MessageBoxButtons.YesNo,
            // MessageBoxIcon.Warning);

            //if (dialog == DialogResult.Yes)
            //{
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        internal void butDefaultGenerator_Click(object sender, EventArgs e)
        {
            frmManagerRoutse frmDefaultGenerator = new frmManagerRoutse();
            frmDefaultGenerator.ShowDialog();
            //butDefaultGenerator.Text = "Генератор " + DS360Setting.ComPortDefaultName;
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            butDefaultGenerator.Text = $"Генератор {name}";
        }
        private void lblRoute_Click(object sender, EventArgs e)
        {
            //лейбл Маршрут
        }

        private void lblSavedRoutes_Click(object sender, EventArgs e)
        {
            //ничего не надо
        }

        private void butEditingRoute_Click(object sender, EventArgs e)
        {
            frmEditingRoutes editingRoutes = new frmEditingRoutes();
            editingRoutes.ShowDialog();
            LoadCboSavedRoutes();
        }

        private void butNextSetup_Click(object sender, EventArgs e)
        {
            //переместить фокус на след. и запустить след. настройку
        }

        private void butGeneratorControl_Click(object sender, EventArgs e)
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = Type.Control;
            editingSettings.Text = "Отправка настройки в генератор";
            editingSettings.ShowDialog();
        }

        private void butBroadcastSettingsGenerator_Click(object sender, EventArgs e)
        {
            var selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            if (selectedNode == null)
            {
                return;
            }
            
            if (selectedNode.NodeType != NodeType.Setting)
            {
                return;
            }
            selectedNode.ImageIndex = 2;
            selectedNode.SelectedImageIndex = 2;
            if (selectedNode.DS360Setting.SendDS360Setting() != Result.Success)
            {
                MessageBox.Show(selectedNode.DS360Setting.ResultMessage);
                selectedNode.ImageIndex = 4;
                selectedNode.SelectedImageIndex = 4;
                return;
            }
            selectedNode.ImageIndex = 3;
            selectedNode.SelectedImageIndex = 3;
            //передача настройки в генератор

        }

        private void butAboutProgram_Click(object sender, EventArgs e)
        {
            //появление messageBox
            MessageBox.Show(
         "Мanager DS360. Версия ПО 0.005.\n  Год разработки - 2023.",
         "О программе",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
            //MessageBoxDefaultButton.Button1,
            //MessageBoxOptions.DefaultDesktopOnly);
            /*//Эту часть кода ААС использует для тестирования библиотеки

            DS360Setting generator = new DS360Setting();
            generator.ComPortName = "COM5";
            generator.FunctionType = FunctionType.SineSquare;
            generator.Frequency = 251.25856;
            generator.FrequencyB = 151.26856;
            generator.AmplitudeRMS = 2.35523456;
            generator.AmplitudeRMSToneB = 1.15523456;
            //generator.Offset = 0.0;
            generator.SendDS360Setting();
            //string str = generator.GetIdentificationString();
            //string str2 = "S/n: " + generator.GetSerialNumber();
            MessageBox.Show(generator.ResultMessage, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            */
        }



        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavedRoutes.SelectedIndex == -1)
            {
                return;
            }
            treRouteTree.Nodes.Clear();
            treRouteTree.LoadTreeNodesWithSeetings(PmData.RouteAddresses[cboSavedRoutes.SelectedIndex]);
            //загрузить выпадающий список сохранённых маршрутов из листа
        }

        private void txtNameGenerator_TextChanged(object sender, EventArgs e)
        {
            //отображение в окошке наименования генератора
        }

        internal void frmManagerDS360_Load(object sender, EventArgs e)
        {
            
            LoadCboSavedRoutes();
            PushListBox();
            
            
            butNextSetup.Enabled = false;
            DS360Setting.FindAllDS360();
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            butDefaultGenerator.Text = $"Генератор {name}";
        }

        private void LoadCboSavedRoutes()
        {
            treRouteTree.Nodes.Clear();
            cboSavedRoutes.Items.Clear();
            foreach (var route in PmData.RouteAddresses)
            {
                cboSavedRoutes.Items.Add(route.Name.Replace(route.Extension, ""));
            }
            if (cboSavedRoutes.Items.Count >0)
            {
                cboSavedRoutes.SelectedIndex = 0;
            }
        }

        private void PushListBox()
        {
            //lstRouteSettings.Items.Clear();
            //foreach (Entry entry1 in ProgramData.Entries)
            //{

            //}
        }

        private void lstRouteSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //список параметров в маршруте
        }

        private void sbrVerticalFieldКouteЕree_Scroll(object sender, ScrollEventArgs e)
        {
            //скролл вертикаль
        }

        private void sbrHorizontalFieldКouteЕree_Scroll(object sender, ScrollEventArgs e)
        {
            //скролл горизонт
        }

        internal void lblDefaultGenerator_Click(object sender, EventArgs e)
        {
            //наименование генератора по умолчанию
        }
    }
}
