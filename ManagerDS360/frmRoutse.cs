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

        private void but_down_route_Click(object sender, EventArgs e)
        {

        }

        private void but_up_route_Click(object sender, EventArgs e)
        {

        }

        private void but_editing_routes_Load(object sender, EventArgs e)
        {

            listRoutesFiles.AddRange(new DirectoryInfo("W:\\8.Технический отдел\\Общая\\Группа C#").GetFiles());
            foreach (FileInfo info in listRoutesFiles)
            {
                lstSaveRoutes.Items.Add(info);
            }
        }

        private void lstsaveroutes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butDeleteRoute_Click(object sender, EventArgs e)
        {

        }
    }
}
