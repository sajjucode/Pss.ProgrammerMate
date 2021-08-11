using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pss.ProgrammerMate.Appearances
{
    public static class MenuStyles
    {
        public static Font setMainMenuStyle()
        {
            try
            {
                return new System.Drawing.Font("Californian FB", 10, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
