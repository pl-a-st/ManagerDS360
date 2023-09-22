using LibDevicesManager.DC23;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerDS360.Controls
{
    public partial class frmCreationDC23Setting : Form
    {
        public ManagerDC23 DC23 = new ManagerDC23();
        public frmCreationDC23Setting()
        {
            InitializeComponent();
        }
    }
}
