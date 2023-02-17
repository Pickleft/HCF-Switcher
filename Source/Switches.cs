using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCF_SWITCHER
{
    internal class Switches
    {

        #region Private Functions
        private static async Task SwitchPoints(Point Def, Point New)
        {
            WinApi.SetCursorPos(Def.X, Def.Y);
            await Task.Delay(Config.Delay);
            await Click();
            WinApi.SetCursorPos(New.X, New.Y);
            await Task.Delay(Config.Delay);
            await Click();
            WinApi.SetCursorPos(Def.X, Def.Y);
            await Task.Delay(Config.Delay);
            await Click();
        }

        public static async Task Click()
        {
            WinApi.mouse_event(0x0002, 0, 0, 0, 0);
            await Task.Delay(5);
            WinApi.mouse_event(0x0004, 0, 0, 0, 0);
        }

        public static async Task MSGCLICK() // To Simulate high speed switch this method is obsolete
        {
            WinApi.SendMessage(Calls.Java, 0x201, 0x0001, 0); // 0x0001 (mouse left vkey down)
            await Task.Delay(5);
            WinApi.SendMessage(Calls.Java, 0x202, 0, 0);
        }
        #endregion

        #region Functions
        public static async Task SwitchAll(bool open, bool close)
        {
            if (open)
            {
                System.Windows.Forms.SendKeys.SendWait("e");
                await Task.Delay(Config.CloseAndOpenDelay); // to avoid issues
            }

            SwitchPoints(Calls.Default_H, Calls.New_H).Wait();
            SwitchPoints(Calls.Default_C, Calls.New_C).Wait(); // Used Task.Wait instead of awaiting the call cause Task.Wait blocks the thread instead of pausing it.
            SwitchPoints(Calls.Default_L, Calls.New_L).Wait();
            SwitchPoints(Calls.Default_B, Calls.New_B).Wait();

            Output.WriteLine($"Switched All : [ {DateTime.Now.ToString("hh:ss:fff")} ]", ConsoleColor.DarkCyan);
            if (close)
            {
                await Task.Delay(Config.CloseAndOpenDelay); // to avoid issues
                System.Windows.Forms.SendKeys.SendWait("e");
            }
        }
        #endregion

    }
}
