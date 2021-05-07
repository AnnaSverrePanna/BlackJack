using System;
using System.Collections.Generic;
using System.Text;
using Black_Jack.Interface;

namespace Black_Jack
{
    class Testing_stuff
    {
        /*
        Console.WriteLine("Welcome to Blackjack!");
        Console.WriteLine("Do you want to:");
        Console.WriteLine(" 1. Login");
        Console.WriteLine(" 2. Create Account");
        Console.WriteLine(" 3. Delete Account");
        */
        public static void PrintTextNice(string[] textToPrint)
        {
            //Border offset
            int border = 2;

            //Determine longest string in Array
            string longestStringInArray = "";
            for (int i = 0; i < textToPrint.Length; i++)
            {
                if (textToPrint[i].Length > longestStringInArray.Length)
                {
                    longestStringInArray = textToPrint[i];
                }
            }

            //Find out and calculate Width and depth of given string array.
            Rectangle rect = new Rectangle(
                Console.WindowWidth / 2,
                Console.WindowHeight / 2,
                longestStringInArray.Length + border,
                textToPrint.Length + border * 2
                );

            ////Fill the frame
            for (int frameWidth = 0; frameWidth < rect.width; frameWidth++)
            {
                for (int frameHeigth = 0; frameHeigth < rect.height; frameHeigth++)
                {
                    Console.SetCursorPosition(
                        frameWidth + rect.x - rect.width / 2 - border / 2,
                        frameHeigth + rect.y - rect.height / 2 - border / 2);
                    Console.Write("O");
                }
            }
            //Replace the inside
            for (int frameWidth = border; frameWidth < rect.width - border; frameWidth++)
            {
                for (int frameHeigth = border; frameHeigth < rect.height - border; frameHeigth++)
                {
                    Console.SetCursorPosition(
                        frameWidth + rect.x - rect.width / 2 - border / 2,
                        frameHeigth + rect.y - rect.height / 2 - border / 2);
                    Console.Write(" ");
                }
            }

            //Print the text
            for (int i = 0; i < textToPrint.Length; i++)
            {
                Console.SetCursorPosition(rect.x - rect.width / 2 + border, rect.y - border * 2 + i);
                Console.Write(textToPrint[i]);
            }
        }
    }
}
