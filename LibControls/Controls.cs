using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibControls
{
    public class GreyButton : Button
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.BackColor = Color.Blue;
        }
    }

}
