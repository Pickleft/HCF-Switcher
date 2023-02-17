using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCF_SWITCHER
{
    internal class Output
    {
        public static void WriteLine(object o, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(o.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Write(object o, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.Write(o.ToString());
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
