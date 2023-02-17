using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCF_SWITCHER
{
    internal class Calls
    {
        #region Window
        public static IntPtr Java 
        {
            get
            {
               return WinApi.FindWindow("LWJGL", null);
            }
        }
        #endregion

        #region Defaults
        public static Point Default_H;
        public static Point Default_C;
        public static Point Default_L;
        public static Point Default_B;
        #endregion

        #region New
        public static Point New_H;
        public static Point New_C;
        public static Point New_L;
        public static Point New_B;
        #endregion
    }
}
