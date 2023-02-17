using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HCF_SWITCHER
{
    internal class WinApi
    {
        #region External Imports
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point point);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(ConsoleKey vKeys);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr Handle, uint MSG, uint wparm, uint lparm); // obsolete

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.Dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        #endregion
    }
}
