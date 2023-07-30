using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;
using ToolTip = System.Windows.Forms.ToolTip;

namespace ManagerDS360
{
    public partial class frmManagerRoutse : Form
    {
        public frmManagerRoutse()
        {
            InitializeComponent();
        }

        private void lblLisеComPorts_Click(object sender, EventArgs e)
        {
        }

        internal async void frmDefaultGenerator_Load(object sender, EventArgs e)
        {
            ProgressBar progressBar = new ProgressBar();
            Label label = new Label();
            groupBox1.Enabled = false;
            InsertControls(progressBar, label);
            Task<string[]> getComs = new Task<string[]>(() => DS360Setting.FindAllDS360());
            Task.Run(() => getComs.Start());
            await Task.Run(() => getComs.Wait());
            cboListComPorts.Items.AddRange(getComs.Result);
            cboListComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboListComPorts.SelectedIndex = 0;
            groupBox1.Enabled = true;
            progressBar.Dispose();
            label.Dispose();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.butSave, "CTRL+S");
            toolTip1.SetToolTip(this.butCancel, "CTRL+X");
            toolTip1.SetToolTip(this.butFindGenerator, "F5");
        }

        internal void cboListComPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //комбобокс с выбором вариантов
        }

        private async void butFindGenerator_Click(object sender, EventArgs e)
        {
            await FindGenerator();
        }

        private async Task FindGenerator()
        {
            ProgressBar progressBar = new ProgressBar();
            Label label = new Label();
            groupBox1.Enabled = false;
            InsertControls(progressBar, label);
            Task<string[]> getComs = new Task<string[]>(() => DS360Setting.FindAllDS360(true));
            Task.Run(() => getComs.Start());
            await Task.Run(() => getComs.Wait());
            cboListComPorts.Items.Clear();
            cboListComPorts.Items.AddRange(getComs.Result);
            cboListComPorts.SelectedIndex = 0;
            groupBox1.Enabled = true;
            progressBar.Dispose();
            label.Dispose();
        }

        private void InsertControls(ProgressBar progressBar, Label label)
        {
            progressBar.Width = this.Width / 2;
            progressBar.Height = this.Height / 4;
            progressBar.Location = new Point(
                x: this.Width / 2 - progressBar.Width / 2,
                y: this.Height / 2 - progressBar.Height / 2);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 1;
            label.AutoSize = true;
            label.Text = "Идет поиск генераторов";
            label.BackColor = Color.Transparent;
            label.Parent = progressBar;
            label.Location = new Point(
                x: this.Width / 2 - label.PreferredWidth / 2,
                y: progressBar.Location.Y - label.Height );
            this.Controls.Add(progressBar);
            this.Controls.Add(label);
            progressBar.BringToFront();
            label.BringToFront();
        }
        internal void butSave_Click(object sender, EventArgs e)
        {
            //сохранить выбранный генератор как по умолчанию и отправить имя на главную страницу в лейбл
            Save();
            Close();
        }

        private void Save()
        {
            DS360Setting.ComPortDefaultName = cboListComPorts.SelectedItem.ToString();
            frmManagerDS360 frmManagerDS360 = (frmManagerDS360)Application.OpenForms["frmManagerDS360"];
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.S)    // сохранить
            {
                Save();
                Close();
            }
            if (e.Control == true && e.KeyCode == Keys.X)    // закрыть
            {
                Close();
            }
            if (e.KeyCode == Keys.F5)    // обновить
            {
                await FindGenerator();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
