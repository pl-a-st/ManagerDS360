using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;

namespace ManagerDS360 {
   
    public partial class frmManagerDS360 : Form {
        

        public frmManagerDS360() 
        {
            InitializeComponent();
        }

        //по крестику спрашивает, закрыть или нет окно
        private void frmManagerDS360_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
             "Вы действительно хотите выйти из программы?",
             "Завершение программы",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void butDefaultGenerator_Click(object sender, EventArgs e)
        {
            frmManagerRoutse frmDefaultGenerator = new frmManagerRoutse();
            frmDefaultGenerator.Type = Type.Control;
            frmDefaultGenerator.ShowDialog();
        }

        private void lblRoute_Click(object sender, EventArgs e)
        {

        }

        private void lblSavedRoutes_Click(object sender, EventArgs e)
        {

        }

        //private void button4_Click(object sender, EventArgs e)
        //{


        //}

        private void butEditingRoute_Click(object sender, EventArgs e)
        {
            frmEditingRoutes editingRoutes = new frmEditingRoutes();
            editingRoutes.ShowDialog();
        }

        private void butNextSetup_Click(object sender, EventArgs e)
        {
            //переместить фокус на след. и запустить след. настройку
        }

        private void butGeneratorControl_Click(object sender, EventArgs e)
        {
            frmCreationEditingSettings editingSettings = new frmCreationEditingSettings();
            editingSettings.ShowDialog();
        }

        private void butBroadcastSettingsGenerator_Click(object sender, EventArgs e)
        {
            //передача настройки в генератор
        }

        private void butAboutProgram_Click(object sender, EventArgs e)
        {
            //появление messageBox
            MessageBox.Show(
         "Мanager DS360. Версия ПО 0.001.\n  Технический отдел - лучший! ",
         "О программе",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1,
          MessageBoxOptions.ServiceNotification);

        }

     
    
        private void cboSavedRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //загрузить выпадающий список сохранённых маршрутов
        }

        private void txtNameGenerator_TextChanged(object sender, EventArgs e)
        {
            //отображение в окошке наименования генератора
            txtNameGenerator.Text = "cboListComPorts_SelectedIndexChanged";
        }

        private void treFieldКouteЕree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void frmManagerDS360_Load(object sender, EventArgs e)
        {
            PushListBox();
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

        }

        private void sbrVerticalFieldКouteЕree_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void sbrHorizontalFieldКouteЕree_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
