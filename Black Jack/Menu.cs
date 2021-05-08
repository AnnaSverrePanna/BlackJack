using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Black_Jack
{
    class Menu
    {
        int menuPos = 0;
        bool selectedOption = false;
        public Menu()
        {
            BlackjackText();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleText.CenterText("Starting game...");
            try
            {
                SaveSystem.LoadSave();
            }
            catch (Exception e)
            {
                BlackjackText();
                Console.ForegroundColor = ConsoleColor.Red;
                ConsoleText.CenterText("Can't connect to database!");
                ConsoleText.CenterText("Check your internet connection and try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            BlackjackText();

            while (selectedOption == false)
            {
                switch (menuPos)
                {
                    case 0:
                        BlackjackText();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       LOGIN       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   CREATE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   DELETE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        break;
                    case 1:
                        BlackjackText();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       LOGIN       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   CREATE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   DELETE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        break;
                    case 2:
                        BlackjackText();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       LOGIN       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   CREATE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("   DELETE ACCOUNT  ");
                        ConsoleText.CenterText("                   ");
                        break;
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        switch (menuPos)
                        {
                            case 0:
                                selectedOption = true;
                                break;
                            case 1:
                                #region CreateAccount
                                CreateAccountText();
                                
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                ConsoleText.CenterText("                   ");
                                ConsoleText.CenterText("     Username:     ");
                                ConsoleText.CenterText("                   ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.White;
                                string createAccountUsername = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine();
                                Console.WriteLine();
                                ConsoleText.CenterText("                   ");
                                ConsoleText.CenterText("     Password:     ");
                                ConsoleText.CenterText("                   ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                string createAccountPasswordFirst = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine();
                                Console.WriteLine();
                                ConsoleText.CenterText("                   ");
                                ConsoleText.CenterText(" Confirm Password: ");
                                ConsoleText.CenterText("                   ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                string createAccountPassword = Console.ReadLine();
                                Console.ResetColor();

                                if (createAccountPasswordFirst != createAccountPassword)
                                {
                                    CreateAccountText();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    ConsoleText.CenterText("Passwords doesn't match. Try again!");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    break;
                                }

                                switch (SaveSystem.CreateUser(createAccountUsername, createAccountPassword))
                                {
                                    case true:
                                        CreateAccountText();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        ConsoleText.CenterText("Account created!");
                                        Console.ResetColor();
                                        Thread.Sleep(750);
                                        break;
                                    case false:
                                        CreateAccountText();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        ConsoleText.CenterText("Username is already taken!");
                                        Console.ResetColor();
                                        Thread.Sleep(750);
                                        break;
                                }
                                #endregion
                                break;
                            case 2:
                                #region DeleteAccount
                                DeleteAccountText();

                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                ConsoleText.CenterText("                   ");
                                ConsoleText.CenterText("     Username:     ");
                                ConsoleText.CenterText("                   ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.White;
                                string deleteAccountUsername = Console.ReadLine();
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine();
                                Console.WriteLine();
                                ConsoleText.CenterText("                   ");
                                ConsoleText.CenterText("     Password:     ");
                                ConsoleText.CenterText("                   ");
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition((Console.WindowWidth - 9) / 2, Console.CursorTop);
                                Console.ForegroundColor = ConsoleColor.Black;
                                string deleteAccountPassword = Console.ReadLine();
                                Console.ResetColor();

                                switch (SaveSystem.DeleteUser(deleteAccountUsername, deleteAccountPassword))
                                {
                                    case true:
                                        DeleteAccountText();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        ConsoleText.CenterText("Account deleted successfully!");
                                        Console.ResetColor();
                                        Thread.Sleep(750);
                                        break;
                                    case false:
                                        Thread.Sleep(750);
                                        break;
                                }
                                #endregion
                                break;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (menuPos < 2) menuPos++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuPos > 0) menuPos--;
                        break;
                }          
            }

            if (menuPos == 0) new Game();
        }

        private void BlackjackText()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleText.CenterText(@"  ____  _               _____ _  __    _         _____ _  __ ");
            ConsoleText.CenterText(@" |  _ \| |        /\   / ____| |/ /   | |  /\   / ____| |/ / ");
            ConsoleText.CenterText(@" | |_) | |       /  \ | |    | ' /    | | /  \ | |    | ' /  ");
            ConsoleText.CenterText(@" |  _ <| |      / /\ \| |    |  < _   | |/ /\ \| |    |  <   ");
            ConsoleText.CenterText(@" | |_) | |____ / ____ \ |____| . \ |__| / ____ \ |____| . \  ");
            ConsoleText.CenterText(@" |____/|______/_/    \_\_____|_|\_\____/_/    \_\_____|_|\_\ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void LoginText()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleText.CenterText(@"  _    ___   ___ ___ _  _ ");
            ConsoleText.CenterText(@" | |  / _ \ / __|_ _| \| |");
            ConsoleText.CenterText(@" | |_| (_) | (_ || || .` |");
            ConsoleText.CenterText(@" |____\___/ \___|___|_|\_|");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void CreateAccountText()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleText.CenterText(@"   ___ ___ ___   _ _____ ___     _   ___ ___ ___  _   _ _  _ _____ ");
            ConsoleText.CenterText(@"  / __| _ \ __| /_\_   _| __|   /_\ / __/ __/ _ \| | | | \| |_   _|");
            ConsoleText.CenterText(@" | (__|   / _| / _ \| | | _|   / _ \ (_| (_| (_) | |_| | .` | | |  ");
            ConsoleText.CenterText(@"  \___|_|_\___/_/ \_\_| |___| /_/ \_\___\___\___/ \___/|_|\_| |_|  ");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void DeleteAccountText()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleText.CenterText(@"  ___  ___ _    ___ _____ ___     _   ___ ___ ___  _   _ _  _ _____ ");
            ConsoleText.CenterText(@" |   \| __| |  | __|_   _| __|   /_\ / __/ __/ _ \| | | | \| |_   _|");
            ConsoleText.CenterText(@" | |) | _|| |__| _|  | | | _|   / _ \ (_| (_| (_) | |_| | .` | | |  ");
            ConsoleText.CenterText(@" |___/|___|____|___| |_| |___| /_/ \_\___\___\___/ \___/|_|\_| |_|  ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
