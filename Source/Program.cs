using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HCF_SWITCHER
{
    internal class Program
    {
        static bool auto_open;
        static bool auto_close;

        static void Main(string[] args)
        {
            Output.WriteLine("Input Bind To Set Armor Slots: ", ConsoleColor.White);
            Config.SetKey = Console.ReadKey().Key;
            Output.WriteLine("\nInput Bind To Set Armor Slots: ", ConsoleColor.White);
            Config.SwitchKey = Console.ReadKey().Key;
            Output.WriteLine("\nOpen Inv Automatically (Y / N)", ConsoleColor.White);
            ConsoleKey c = Console.ReadKey().Key;
            Output.WriteLine("\nClose Inv Automatically (Y / N)", ConsoleColor.White);
            ConsoleKey c1 = Console.ReadKey().Key;
            Output.WriteLine("\nDelay Between Mouse Location & Clicks (usually 25, increase if issues w/ ping): ", ConsoleColor.White);
            Config.Delay = int.Parse(Console.ReadLine());
            Output.WriteLine("\nDelay Between Inventory Functions & Mouse Funtions (usually 25, increase if issues w/ ping): ", ConsoleColor.White);
            Config.CloseAndOpenDelay = int.Parse(Console.ReadLine());
            if (c == ConsoleKey.Y)
            {
                auto_open = true;
            }
            else
            {
                auto_open = false;
            }
            if (c1 == ConsoleKey.Y)
            {
                auto_close = true;
            }
            else
            {
                auto_close = false;
            }
            Output.WriteLine("\n  > Done.", ConsoleColor.Green);
            Thread.Sleep(500);
            Init();
        }

        public static void Init()
        {
            Console.Clear();
            Output.WriteLine(@"
   ___                        ____       _ __      __          
  / _ | ______ _  ___  ____  / __/    __(_) /_____/ /  ___ ____
 / __ |/ __/  ' \/ _ \/ __/ _\ \| |/|/ / / __/ __/ _ \/ -_) __/
/_/ |_/_/ /_/_/_/\___/_/   /___/|__,__/_/\__/\__/_//_/\__/_/   
                                                               by Pickleft#1853", ConsoleColor.Red);
            Output.WriteLine($"\n    > Bind [{Config.SetKey}] To Set Armor Slots", ConsoleColor.Cyan);
            Output.WriteLine($"\n    > Bind [{Config.SwitchKey}] To Switch Armor After Setting", ConsoleColor.Cyan);
            Output.WriteLine($"\n    > Auto Open Inventory Is [{auto_open}]", ConsoleColor.Cyan);
            Output.WriteLine($"\n    > Auto Close Inventory Is [{auto_close}]", ConsoleColor.Cyan);
            Output.WriteLine($"\n    =======================================\n", ConsoleColor.Cyan);
            SlotsSet.SetArmorPos().Wait();
            KeyListener().Wait();
        }

        private async static Task KeyListener()
        {
            while (true)
            {
                await Task.Delay(100); // Reduce CPU Usage.
                int Status = (WinApi.GetAsyncKeyState(Config.SwitchKey) & 1);
                if (Status == 1)
                {
                    await Switches.SwitchAll(auto_open, auto_close);
                }
            }
        }
    }
}
