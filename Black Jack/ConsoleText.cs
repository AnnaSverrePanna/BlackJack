using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Jack
{
    class ConsoleText
    {
        public static void CenterText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
}
