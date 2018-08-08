using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers.WindowsControls
{

    public static class ControlFormatInit
    {
        public static void InitTextBox(ref TextBox txt, int maxlen,bool IsNum,int tabindex)
        {
            txt.MaxLength = maxlen;
            if(IsNum)
              txt.KeyPress += Txt_KeyPress;
            txt.TabIndex = tabindex;
        }

        private static void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
