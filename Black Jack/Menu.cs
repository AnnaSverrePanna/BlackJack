using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Black_Jack
{
    class Menu
    {
        int menuPos = 1;
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
                        ConsoleText.CenterText("       RULES       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       LOGIN       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
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
                        ConsoleText.CenterText("       RULES       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
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
                    case 2:
                        BlackjackText();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       RULES       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
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
                    case 3:
                        BlackjackText();
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       LOGIN       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
                        ConsoleText.CenterText("                   ");
                        ConsoleText.CenterText("       RULES       ");
                        ConsoleText.CenterText("                   ");
                        Console.WriteLine();
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
                                #region Rules
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                ConsoleText.CenterText(@"  _____  _    _ _      ______  _____ ");
                                ConsoleText.CenterText(@" |  __ \| |  | | |    |  ____|/ ____|");
                                ConsoleText.CenterText(@" | |__) | |  | | |    | |__  | (___  ");
                                ConsoleText.CenterText(@" |  _  /| |  | | |    |  __|  \___ \ ");
                                ConsoleText.CenterText(@" | | \ \| |__| | |____| |____ ____) |");
                                ConsoleText.CenterText(@" |_|  \_\\____/|______|______|_____/ ");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();

                                ConsoleText.CenterText("Black Jack is a cardgame where you are playing against a dealer. The");
                                ConsoleText.CenterText("goal is to get as near 21 as possible (or over the dealer). The value");
                                ConsoleText.CenterText("of each numbered card is the value of the number. An ace can for the");
                                ConsoleText.CenterText("player both have the value 1 and 11. A king, queen and jack does all");
                                ConsoleText.CenterText("have the value 10. For the dealer every card except ace is worth the");
                                ConsoleText.CenterText("same. For the dealer, the ace is worth 11.");
                                Console.WriteLine();
                                ConsoleText.CenterText("When you create an account you start with $300. You start every round");
                                ConsoleText.CenterText("with betting. If you lose against the dealer, you lose what you have bet.");
                                ConsoleText.CenterText("If you get BlackJack (value 21) you get back three times of what you bet");
                                ConsoleText.CenterText("in the beginning. If you win over the dealer (have a higher value than");
                                ConsoleText.CenterText("the dealer) you get back dubble the amount you bet.");
                                Console.WriteLine();
                                ConsoleText.CenterText("Press any key to return.");

                                Console.ReadKey();
                                #endregion
                                break;
                            case 1:
                                selectedOption = true;
                                break;
                            case 2:
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
                                    Thread.Sleep(750);
                                    break;
                                }

                                if (Regex.IsMatch(createAccountUsername, @"^[a-zA-Z][a-zA-Z0-9]{2,14}$") == false)
                                {
                                    CreateAccountText();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    ConsoleText.CenterText("ERROR:");
                                    ConsoleText.CenterText("Username must be 3-15 char long.");
                                    ConsoleText.CenterText("Username must start with a letter.");
                                    ConsoleText.CenterText("Username can't contain special chars.");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    ConsoleText.CenterText("Press any key to continue.");
                                    Console.ReadLine();
                                    break;
                                }

                                if (Regex.IsMatch(createAccountPassword, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$") == false)
                                {
                                    CreateAccountText();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    ConsoleText.CenterText("ERROR:");
                                    ConsoleText.CenterText("Password must be atleast 6 chars long.");
                                    ConsoleText.CenterText("Password should contain atleast one upper case and one lower case.");
                                    ConsoleText.CenterText("Password should contain atleast one digit.");
                                    ConsoleText.CenterText("Password should contain atleast one special char (#?!@$%^&*-)");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    ConsoleText.CenterText("Press any key to continue.");
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
                            case 3:
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
                        if (menuPos < 3) menuPos++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuPos > 0) menuPos--;
                        break;
                }
            }

            if (menuPos == 1) new Game();
        }

        public static void BlackjackText()
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
        }

        public static void LoginText()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            ConsoleText.CenterText(@"  _      ____   _____ _____ _   _ ");
            ConsoleText.CenterText(@" | |    / __ \ / ____|_   _| \ | |");
            ConsoleText.CenterText(@" | |   | |  | | |  __  | | |  \| |");
            ConsoleText.CenterText(@" | |   | |  | | | |_ | | | | . ` |");
            ConsoleText.CenterText(@" | |___| |__| | |__| |_| |_| |\  |");
            ConsoleText.CenterText(@" |______\____/ \_____|_____|_| \_|");
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
            ConsoleText.CenterText(@"   _____ _____  ______       _______ ______            _____ _____ ____  _    _ _   _ _______ ");
            ConsoleText.CenterText(@"  / ____|  __ \|  ____|   /\|__   __|  ____|     /\   / ____/ ____/ __ \| |  | | \ | |__   __|");
            ConsoleText.CenterText(@" | |    | |__) | |__     /  \  | |  | |__       /  \ | |   | |   | |  | | |  | |  \| |  | |   ");
            ConsoleText.CenterText(@" | |    |  _  /|  __|   / /\ \ | |  |  __|     / /\ \| |   | |   | |  | | |  | | . ` |  | |   ");
            ConsoleText.CenterText(@" | |____| | \ \| |____ / ____ \| |  | |____   / ____ \ |___| |___| |__| | |__| | |\  |  | |   ");
            ConsoleText.CenterText(@"  \_____|_|  \_\______/_/    \_\_|  |______| /_/    \_\_____\_____\____/ \____/|_| \_|  |_|   ");
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
            ConsoleText.CenterText(@"  _____  ______ _      ______ _______ ______            _____ _____ ____  _    _ _   _ _______ ");
            ConsoleText.CenterText(@" |  __ \|  ____| |    |  ____|__   __|  ____|     /\   / ____/ ____/ __ \| |  | | \ | |__   __|");
            ConsoleText.CenterText(@" | |  | | |__  | |    | |__     | |  | |__       /  \ | |   | |   | |  | | |  | |  \| |  | |   ");
            ConsoleText.CenterText(@" | |  | |  __| | |    |  __|    | |  |  __|     / /\ \| |   | |   | |  | | |  | | . ` |  | |   ");
            ConsoleText.CenterText(@" | |__| | |____| |____| |____   | |  | |____   / ____ \ |___| |___| |__| | |__| | |\  |  | |   ");
            ConsoleText.CenterText(@" |_____/|______|______|______|  |_|  |______| /_/    \_\_____\_____\____/ \____/|_| \_|  |_|   ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}