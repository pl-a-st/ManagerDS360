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
            DirectoryInfo directoryInfo = new DirectoryInfo();  //"W:\\8.Технический отдел\\Общая\\Группа C#\\Папка пользователя");
            if (!directoryInfo.Exists)
            {
                MessageBox.Show("Нет данных о созданных маршрутах!", "Внимание"); 
                return;
            }

                //listRoutesFiles.AddRange(new DirectoryInfo("E:\\SteamLibrary").GetFiles());
            //listRoutesFiles.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#").GetFiles());
            foreach (FileInfo info in listRoutesFiles)
            {
                //lstSaveRoutes.Items.Add(info);
            }
            

        }

        private void lstsaveroutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butDeleteRoute_Click(object sender, EventArgs e)
        {
            //удаление маршрута файлом
            //File.Delete(Path.Combine(folderPath, filename));
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


        }

        private void butEditingRoute_Click(object sender, EventArgs e)
        {
            //редактирование маршрута
        }

        private void treSaveRoutes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //список сохранённых маршрутов
        }
    }
}
