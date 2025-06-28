using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBot
{
    class TypingEffect
    {
       
        //Method to simulate typing effect
        public static void ShowTyping(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine();
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(60);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

    }
}
