using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDevicesManager;



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
    public enum Access
    {
        UnLock,
        Blocked
    }
    public class ModifiedTextBox : TextBox
    {
        private string LastText;
        public Access Access = Access.UnLock;
        protected override void OnTextChanged(EventArgs e)
        {
            if (Access == Access.UnLock)
            {
                if (!double.TryParse(Text, out double result) && Text != "")
                {
                    Access = Access.Blocked;
                    Text = LastText;
                    Access = Access.UnLock;
                    this.SelectionStart = Text.Length;
                    return;
                }
                LastText = Text;
                base.OnTextChanged(e);
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
       
    }
    [Serializable]
    public class TreeNodeWithSeting : TreeNode
    {
        public DS360Setting DS360Setting = new DS360Setting();
    }
    [Serializable]
    public class TreeWi : TreeNode
    {
        public DS360Setting DS360Setting = new DS360Setting();
    }
}
