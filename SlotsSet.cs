using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace HCF_SWITCHER
{
    internal class SlotsSet
    {
        #region Properties
        public static bool Finished { get; protected set; }
        #endregion

        #region Functions
        public static async Task SetArmorPos()
        {
            int Status = (WinApi.GetAsyncKeyState(Config.SetKey) & 1);
            while (Finished == false)
            {
                await Task.Delay(100); // Reduce CPU Usage.
                Status = (WinApi.GetAsyncKeyState(Config.SetKey) & 1);
                if (Status == 1)
                {
                    if (Calls.Default_H.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.Default_H = P;
                        Output.WriteLine(string.Format("[Success] Set Default Helmet Slot Position : [ {0} ]", P), ConsoleColor.Green);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0); // To Return
                    }
                }
                if (Status == 1)
                {
                    if (Calls.Default_C.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.Default_C = P;
                        Output.WriteLine(string.Format("[Success] Set Default ChestPlate Slot Position : [ {0} ]", P), ConsoleColor.Green);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.Default_L.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.Default_L = P;
                        Output.WriteLine(string.Format("[Success] Set Default Leggings Slot Position : [ {0} ]", P), ConsoleColor.Green);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.Default_B.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.Default_B = P;
                        Output.WriteLine(string.Format("[Success] Set Default Boots Slot Position : [ {0} ]", P), ConsoleColor.Green);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.New_H.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.New_H = P;
                        Output.WriteLine(string.Format("[Success] Set New Helmet Slot Position : [ {0} ]", P), ConsoleColor.Cyan);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.New_C.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.New_C = P;
                        Output.WriteLine(string.Format("[Success] Set New ChestPlate Slot Position : [ {0} ]", P), ConsoleColor.Cyan);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.New_L.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.New_L = P;
                        Output.WriteLine(string.Format("[Success] Set New Leggings Slot Position : [ {0} ]", P), ConsoleColor.Cyan);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                    }
                }
                if (Status == 1)
                {
                    if (Calls.New_B.IsEmpty)
                    {
                        WinApi.GetCursorPos(out Point P);
                        Calls.New_B = P;
                        Output.WriteLine(string.Format("[Success] Set New Boots Slot Position : [ {0} ]", P), ConsoleColor.Cyan);
                        Status = (WinApi.GetAsyncKeyState(ConsoleKey.R) & 0);
                        Finished = true;
                    }
                }
            }
        }
        #endregion
    }
}
