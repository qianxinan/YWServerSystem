using System;
using System.Collections.Generic;
using System.Text;

namespace FKServer
{
    public static  class P
    {
        public static void p(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("["+DateTime.Now.ToString("MM-dd hh:mm")+"] "+text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FKServer>");
        } 
        public static void d(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[" + DateTime.Now.ToString("MM-dd hh:mm") + "] " + text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FKServer>");
        }
        public static void i(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[" + DateTime.Now.ToString("MM-dd hh:mm") + "] " + text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FKServer>");
        }
        public static void e(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[" + DateTime.Now.ToString("MM-dd hh:mm") + "] " + text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FKServer>");
        }        
        public static void w(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[" + DateTime.Now.ToString("MM-dd hh:mm") + "] " + text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("FKServer>");
        }

    }
}
