using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            DefaultGenerator();
        }

        private void DefaultGenerator()
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

        private void butGeneratorControl_Click(object sender, EventArgs e)
        {
            GeneratorControl();
        }

        private static void GeneratorControl()
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.Type = CallType.Control;
            editingSettings.Text = "Отправка настройки в генератор";
            editingSettings.ShowDialog();
        }

        private void butBroadcastSettingsGenerator_Click(object sender, EventArgs e)
        {
            SendNodeSetting();   //передача настройки в генератор
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

        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavedRoutes.SelectedIndex == -1)
            {
                return;
            }
            treRouteTree.Nodes.Clear();
            treRouteTree.LoadTreeNodesWithSeetings(PmData.RouteAddresses[cboSavedRoutes.SelectedIndex]);
            GetToolToPicPlay();
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
            Task getComes = new Task(() => DS360Setting.SetFirstDS360AsDefault());
            await Task.Run(() => getComes.Start());
            await Task.Run(() => getComes.Wait());
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
            panel.Height = (int)(this.Height / 3);
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
            label.Font = new Font("Verdana", 9, FontStyle.Regular);
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
            FileInfo[] routes = PmData.RouteAddresses.ToArray();
            string[] fileNames = new string[routes.Length];
            for (int i=0;i<routes.Length; i++)
            {
                fileNames[i]= routes[i].Name.Replace(routes[i].Extension, "");
            }
            cboSavedRoutes.Items.AddRange(fileNames);
            if (cboSavedRoutes.Items.Count > 0)
            {
                cboSavedRoutes.SelectedIndex = 0;
            }
        }

        private void PushListBox()
        {
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
        private void treRouteTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GetToolToPicPlay();
        }

        private void GetToolToPicPlay()
        {
            TreeNodeWithSetting selectedNode = treRouteTree.SelectedNode as TreeNodeWithSetting;
            PicPlayToolTip.RemoveAll();
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void редактированиеМаршрутовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEditingRoutes editingRoutes = new frmEditingRoutes();
            editingRoutes.ShowDialog();
            LoadCboSavedRoutes();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
        }
        private TreeNode GetNextParentNode(TreeNode selectedNode)
        {
            if (selectedNode.Parent is TreeNode)
            {
                if (selectedNode.Parent.NextNode != null)
                {
                    return selectedNode.Parent.NextNode;
                }
                return GetNextParentNode(selectedNode.Parent);
            }
            return selectedNode;
        }
        private void butNext_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectNextSetting();
            SendNodeSetting();
        }

        private void SelectNextSetting()
        {
            if (treRouteTree.SelectedNode.NextVisibleNode == null)
            {
                return;
            }
            if (!treRouteTree.SelectedNode.NextVisibleNode.IsExpanded)
            {
                treRouteTree.SelectedNode.NextVisibleNode.Expand();
            }
            treRouteTree.SelectedNode = treRouteTree.SelectedNode.NextVisibleNode;
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Setting)
            {
                SelectNextSetting();
            }
        }
        private void SelectPreviousSetting()
        {
            if (treRouteTree.SelectedNode.PrevVisibleNode == null)
            {
                return;
            }
            if (!treRouteTree.SelectedNode.PrevVisibleNode.IsExpanded)
            {
                treRouteTree.SelectedNode.PrevVisibleNode.Expand();
            }
            treRouteTree.SelectedNode = treRouteTree.SelectedNode.PrevVisibleNode;
            if ((treRouteTree.SelectedNode as TreeNodeWithSetting).NodeType != NodeType.Setting)
            {
                SelectPreviousSetting();
            }

        }

        private void picPrevious_Click(object sender, EventArgs e)
        {
            treRouteTree.SelectedNode = treRouteTree.SelectedNode.PrevVisibleNode;
            //if (treRouteTree.SelectedNode == null)
            //{
            //    return;
            //}
            //treRouteTree.SelectedNode = GerPrevousNode(treRouteTree.SelectedNode);
        }

        private void butNext_MouseEnter(object sender, EventArgs e)
        {
            butNext.BackgroundImage = Properties.Resources.следующий_2;
        }

        private void butNext_MouseLeave(object sender, EventArgs e)
        {
            butNext.BackgroundImage = Properties.Resources.следующий;
        }

        private void butNext_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butNext);
        }

        private void SetButClikSize(Button but)
        {
            but.Location = new Point(but.Location.X + 1, but.Location.Y + 1);
            but.Size = new Size(but.Width - 2, but.Height - 2);
        }

        private void butNext_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butNext);
        }

        private void SetButAfterClickSize(Button but)
        {
            but.Location = new Point(but.Location.X - 1, but.Location.Y - 1);
            but.Size = new Size(but.Width + 2, but.Height + 2);
        }

        private void butPrevious_Click(object sender, EventArgs e)
        {
            if (treRouteTree.SelectedNode == null)
            {
                return;
            }
            SelectPreviousSetting();
            SendNodeSetting();
        }

        private void butPrevious_MouseEnter(object sender, EventArgs e)
        {
            butPrevious.BackgroundImage = Properties.Resources.предыдущий_2;
        }

        private void butPrevious_MouseLeave(object sender, EventArgs e)
        {
            butPrevious.BackgroundImage = Properties.Resources.предыдущий;
        }

        private void butPrevious_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butPrevious);
        }

        private void butPrevious_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butPrevious);
        }

        private void butPlay_Click(object sender, EventArgs e)
        {
            SendNodeSetting();
        }

        private void butPlay_MouseEnter(object sender, EventArgs e)
        {
            butPlay.BackgroundImage = Properties.Resources.Play2;
        }

        private void butPlay_MouseLeave(object sender, EventArgs e)
        {
            butPlay.BackgroundImage = Properties.Resources.Play;
        }

        private void butPlay_MouseDown(object sender, MouseEventArgs e)
        {
            SetButClikSize(butPlay);
        }

        private void butPlay_MouseUp(object sender, MouseEventArgs e)
        {
            SetButAfterClickSize(butPlay);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
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
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.G)    // управление
            {
                GeneratorControl();
            }
            if (e.Control == true && e.KeyCode == Keys.D)    // по умолчанию
            {
                DefaultGenerator();
            }
        }

        private void buttonForPicture1_Enter(object sender, EventArgs e)
        {
            buttonForPicture1.BackgroundImage = Properties.Resources.Логотип_ВАСТ_цветной;
        }

        private void buttonForPicture1_MouseLeave(object sender, EventArgs e)
        {
            buttonForPicture1.BackgroundImage = Properties.Resources.Логотип_ВАСТ;
        }

        private void buttonForPicture1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void buttonForPicture1_Click(object sender, EventArgs e)
        {

        }
    }
}
