using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibControls;
using LibDevicesManager;

namespace ManagerDS360
{
    public partial class frmManagerDS360 : Form
    {
        ToolTip PicPlayToolTip = new ToolTip();
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

            SendNodeSetting();
            //передача настройки в генератор
        }

        private void SendNodeSetting()
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
                selectedNode.ImageIndex = 3;
                selectedNode.SelectedImageIndex = 3;
                return;
            }
            selectedNode.ImageIndex = 4;
            selectedNode.SelectedImageIndex = 4;
        }

        private void butAboutProgram_Click(object sender, EventArgs e)
        {


        }



        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavedRoutes.SelectedIndex == -1)
            {
                return;
            }
            treRouteTree.Nodes.Clear();
            treRouteTree.LoadTreeNodesWithSeetings(PmData.RouteAddresses[cboSavedRoutes.SelectedIndex]);
            GetToolToPicPlay();
            //загрузить выпадающий список сохранённых маршрутов из листа
        }

        private void txtNameGenerator_TextChanged(object sender, EventArgs e)
        {
            //отображение в окошке наименования генератора
        }

        internal async void frmManagerDS360_Load(object sender, EventArgs e)
        {
            LoadCboSavedRoutes();
            PushListBox();
            foreach (Control c in this.Controls)
            {
                c.Enabled = false;
            }
            Panel panel = new Panel();
            InsertControls(panel, new ProgressBar(), new Label());
            Task<string[]> getComes = new Task<string[]>(() => DS360Setting.FindAllDS360(true));
            await Task.Run(() => getComes.Start());
            await Task.Run(() => getComes.Wait());
            DS360Setting.ComPortDefaultName = getComes.Result[0];
            string name = DS360Setting.ComPortDefaultName;
            if (name == "NONE")
            {
                name = "не выбран";
            }
            butDefaultGenerator.Text = $"Генератор {name}";
            panel.Dispose();
            foreach (Control c in this.Controls)
            {
                c.Enabled = true;
            }
        }
        private void InsertControls(Panel panel, ProgressBar progressBar, Label label)
        {
            panel.Height = (int)(this.Height/3);
            panel.Width = (int)(this.Width / 2);
            panel.BackColor = Color.DarkGray;
            panel.Location = new Point(
                x: this.Width / 2 - panel.Width / 2,
                y: this.Height / 2 - panel.Height / 2);
            progressBar.Width = this.Width / 3;
            progressBar.Height = this.Height / 6;
            progressBar.Location = new Point(
                x: panel.Width / 2 - progressBar.Width / 2,
                y: panel.Height / 2 - progressBar.Height / 2);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 1;
            label.AutoSize = true;
            label.Font = new Font("Verdana",9, FontStyle.Regular);
            label.Text = "Идет поиск генераторов";
            label.BackColor = Color.Transparent;
            label.Parent = progressBar;
            label.Location = new Point(
                x: panel.Width / 2 - label.PreferredWidth / 2,
                y: progressBar.Location.Y - label.Height);
            panel.Controls.Add(progressBar);
            panel.Controls.Add(label);
            this.Controls.Add(panel);
            panel.BringToFront();
            progressBar.BringToFront();
            label.BringToFront();
        }
        private void LoadCboSavedRoutes()
        {
            treRouteTree.Nodes.Clear();
            cboSavedRoutes.Items.Clear();
            foreach (var route in PmData.RouteAddresses)
            {
                cboSavedRoutes.Items.Add(route.Name.Replace(route.Extension, ""));
            }
            if (cboSavedRoutes.Items.Count > 0)
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

        private void cboSavedRoutes_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cboSavedRoutes_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void cboSavedRoutes_Click(object sender, EventArgs e)
        {
            cboSavedRoutes.DroppedDown = true;
        }

        private void cboSavedRoutes_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SendNodeSetting();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            picPlay.Image = Properties.Resources.Play2;
        }

        private void frmManagerDS360_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            picPlay.Image = Properties.Resources.Play;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            picNext.Image = Properties.Resources.следующий_2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Properties.Resources.следующий;
        }

        private void treRouteTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetToolToPicPlay();
        }

        private void GetToolToPicPlay()
        {
            TreeNodeWithSetting selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            PicPlayToolTip.RemoveAll();
            PicPlayToolTip.SetToolTip(picPlay, GetTextToToll(selectedNode));
        }

        private string GetTextToToll(TreeNodeWithSetting selectedNode)
        {

            if (selectedNode == null)
            {
                return "Испытание: не выбрано!\nНастройка: не выбрана";

            }
            if (selectedNode.NodeType == NodeType.Folder)
            {
                return $"Испытание: {selectedNode.Text}\nНастройка: не выбрана";

            }
            if (selectedNode.NodeType == NodeType.Setting)
            {
                return $"Испытание: {GetNodeParentName(selectedNode)}\n{selectedNode.Text}";
            }
            return "Испытание: не выбрано!\n\nНастройка: не выбрана";
        }

        private string GetNodeParentName(TreeNodeWithSetting selectedNode)
        {
            if (selectedNode.Parent is TreeNodeWithSetting)
            {
                return selectedNode.Parent.Text;
            }
            return "нет";
        }

        private void picPrevious_MouseEnter(object sender, EventArgs e)
        {
            picPrevious.Image = Properties.Resources.предыдущий_2;
        }

        private void picPrevious_MouseLeave(object sender, EventArgs e)
        {
            picPrevious.Image = Properties.Resources.предыдущий;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            var buildDateTime = new DateTime(2000, 1, 1).Add(
                new TimeSpan(TimeSpan.TicksPerDay * version.Build + TimeSpan.TicksPerSecond * 2 * version.Revision));
            MessageBox.Show(
                $"Мanager DS360. Версия ПО {version.ToString()}\n  Дата разработки - {buildDateTime.ToShortDateString()}.",
                "О программе",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void редактированиеМаршрутовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEditingRoutes editingRoutes = new frmEditingRoutes();
            editingRoutes.ShowDialog();
            LoadCboSavedRoutes();
        }
    }
}
