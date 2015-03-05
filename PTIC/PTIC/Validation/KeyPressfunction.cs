using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.VC.Validation
{
    public class KeyPressfunction
    {
        public static void CheckInt(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        public static void CheckChar(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        public static void CheckFloat(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
