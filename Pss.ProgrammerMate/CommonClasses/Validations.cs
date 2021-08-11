using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pss.ProgrammerMate.CommonClasses
{
    public static class Validations
    {
        public static string ReadOnly
        {
            set
            {
            }
            get
            {
                return "Ready only!";
            }


        }

        public static string Required()
        {

            return "Required Field";
        }

        public static string OnlyDigit()
        {

            return "Only Integer Allowed";
        }

        public static string Select()
        {

            return "Select Something";
        }

        public static string Decimal()
        {

            return "Only Decimals Allowed";
        }

        public static string Numeric
        {
            get
            {
                return "Only Numeric value Allowed";
            }
        }


        public static void isNumeric(ErrorProvider epMain, object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                epMain.SetError((Control)sender, Numeric);
                e.Handled = true;
            }
            else
            {
                epMain.Clear();
            }


        }

    }
}
