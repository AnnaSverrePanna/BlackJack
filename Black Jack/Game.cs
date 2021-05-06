using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Black_Jack
{
    //Anna(BlackJack) och William(Save/Login system)
    public enum SuitType
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

    public enum GameStatus
    {
        Won,
        Lost,
        Playing,
        Tie,
        BlackJack
    }

    public class Game
    {
        private Player _player;
        private Dealer _dealer;
        private Deck _deck;
        private GameStatus _status;

        private bool loggedIn = false;

        public Game()
        {
            BeforeStart();

            bool keepPlaying = true;
            while (keepPlaying)
            {
                TheGame();

                if (PlayAgain() == false)
                {
                    keepPlaying = false;
                }
                Reset();
            }
        }

        private void AccountSystem()
        {
            while (loggedIn == false)
            {

                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2,
                Console.WindowHeight / 3);
                Console.WriteLine("Welcome to Blackjack!");
                Console.WriteLine("Do you want to:");
                Console.WriteLine(" 1. Login");
                Console.WriteLine(" 2. Create Account");
                Console.WriteLine(" 3. Delete Account");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Login");
                        Console.Write("Username: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string loginPassword = Console.ReadLine();

                        switch (SaveSystem.Login(loginUsername, loginPassword))
                        {
                            case true:
                                Console.Clear();

                                _player.Name = SaveSystem.loggedInUser.Username;
                                _player.MoneyPot = SaveSystem.loggedInUser.Money;
                                _player.Points = SaveSystem.loggedInUser.PlayerPoints;
                                _dealer.Points = SaveSystem.loggedInUser.DealerPoints;

                                Console.WriteLine("Logged in successfully!");
                                Thread.Sleep(750);
                                loggedIn = true;
                                break;
                            case false:
                                Thread.Sleep(750);
                                break;
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Create account");
                        Console.Write("Username: ");
                        string createAccountUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string createAccountPassword = Console.ReadLine();

                        switch (SaveSystem.CreateUser(createAccountUsername, createAccountPassword))
                        {
                            case true:
                                Console.Clear();
                                Console.WriteLine("Account created!");
                                Thread.Sleep(750);
                                break;
                            case false:
                                Console.Clear();
                                Console.WriteLine("Username is already taken!");
                                Thread.Sleep(750);
                                break;
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Delete account");
                        Console.Write("Username: ");
                        string deleteAccountUsername = Console.ReadLine();
                        Console.Write("Password: ");
                        string deleteAccountPassword = Console.ReadLine();

                        switch (SaveSystem.DeleteUser(deleteAccountUsername, deleteAccountPassword))
                        {
                            case true:
                                Console.Clear();
                                Console.WriteLine("Account deleted successfully!");
                                Thread.Sleep(750);
                                break;
                            case false:
                                Thread.Sleep(750);
                                break;
                        }
                        break;
                }
            }
        }

        private void Save()
        {
            SaveSystem.Save(_player.Name, _player.MoneyPot, _player.Points, _dealer.Points);
        }

        private bool PlayAgain()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"You now have ${_player.MoneyPot}");
            Console.WriteLine("Do you want to exit (Press any key) or restart the game (Press R)?");

            var keypressed = Console.ReadKey();

            if (keypressed.Key == ConsoleKey.R)
            {
                Console.Clear();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void WaitForEnter()
        {
            while (true)
            {
                Console.WriteLine("Press enter to start!");
                var keypressed = Console.ReadKey();

                if (keypressed.Key == ConsoleKey.Enter)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        private void BeforeStart()
        {
            _player = new Player();
            _dealer = new Dealer();

            _player.Points = 0;
            _player.MoneyPot = 300;

            _dealer.Points = 0;

            SaveSystem.LoadSave();
            AccountSystem();

            Console.WriteLine();
            var nrOfDecks = ChooseNrOfDecks();
            _deck = new Deck(nrOfDecks);

            WaitForEnter();
        }

        private void TheGame()
        {
            Console.Clear();
            _deck.Shuffle();

            _status = GameStatus.Playing;
            WriteOutPointsAndMoney();

            Betting();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Your turn");
            Console.ForegroundColor = ConsoleColor.White;
            PlayerFirstDraws();

            while (_status == GameStatus.Playing)
            {
                if (_player.BestValue < 21)
                {
                    DrawOrStay();

                    if (_player.BestValue < 21)
                    {
                        DealersTurn();
                    }

                    WinOrLose();
                }
                else if (_player.BestValue > 21)
                {
                    DealerWins();
                }
                else if (_player.BestValue == 21)
                {
                    PlayerWin();
                }
            }

            Reset();
        }

        public int ChooseNrOfDecks()
        {
            Console.WriteLine("Write the number of decks you want.");
            Console.WriteLine("The minimum is 5 so you can't have a number less than 5.");
            Console.WriteLine();

            var nrOfDecks = Convert.ToInt32(Console.ReadLine());

            if (nrOfDecks >= 5)
            {
                Console.WriteLine();
                Console.WriteLine($"Okay, then we will play with {nrOfDecks} decks of cards");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"You can't have {nrOfDecks} decks because the minimum is 5 decks.");
            }

            return nrOfDecks;
        }

        private void DrawOrStay()
        {
            while (_player.BestValue < 21)
            {
                Console.Write("Do you want to draw (Press D) or stay (Press S)?");
                var keypressed = Console.ReadKey();

                if (keypressed.Key == ConsoleKey.D)
                {
                    Console.WriteLine();
                    PlayerDraw();
                }
                else if (keypressed.Key == ConsoleKey.S)
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.Write("You have:");
                    foreach (var card in _player.Hand)
                    {
                        Console.Write($" {card}");
                    }
                    Console.Write(_player.HandValue());
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        private void PlayerDraw()
        {
            Console.WriteLine();
            Console.WriteLine();
            var pickedCard = _deck.PickACard();

            _player.AddCard(pickedCard);

            Console.WriteLine($"It is: {pickedCard.ToString()}");
            Thread.Sleep(1000);

            Console.Write("You have:");
            foreach (var card in _player.Hand)
            {
                Console.Write($" {card}");
            }

            Console.Write(_player.HandValue());
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        private void PlayerFirstDraws()
        {
            //First Card
            var firstCard = _deck.PickACard();
            _player.AddCard(firstCard);
            _player.HandValue();
            Console.WriteLine($"It is {firstCard}");
            Thread.Sleep(1000);

            //Second Card
            var pickedCard = _deck.PickACard();
            _player.AddCard(pickedCard);

            Console.WriteLine($"It is: {pickedCard}");
            Thread.Sleep(1000);

            Console.Write("You have:");
            foreach (var card in _player.Hand)
            {
                Console.Write($" {card}");
            }

            Console.Write(_player.HandValue());
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        private void DealersTurn()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dealers turn:");
            Console.ForegroundColor = ConsoleColor.White;

            DealerFirstDraws();

            while (_dealer.HighValue < 17)
            {
                DealerDraw();
            }
        }

        private void DealerFirstDraws()
        {
            //First Card
            var firstCard = _deck.PickACard();
            _dealer.AddCard(firstCard);
            _dealer.HandValue();
            Console.WriteLine($"It is {firstCard}");
            Thread.Sleep(1000);

            //Second Card
            var pickedCard = _deck.PickACard();
            _dealer.AddCard(pickedCard);

            Console.WriteLine($"It is: {pickedCard}");
            Thread.Sleep(1000);

            Console.Write("Dealer has:");
            foreach (var card in _dealer.Hand)
            {
                Console.Write($" {card}");
            }

            Console.Write(_dealer.HandValue());
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        private void DealerDraw()
        {
            var pickedCard = _deck.PickACard();

            _dealer.AddCard(pickedCard);

            Console.WriteLine($"Dealer shows: {pickedCard.ToString()}");
            Thread.Sleep(1000);

            Console.Write("Dealer has:");
            foreach (var card in _dealer.Hand)
            {
                Console.Write($" {card} ");
            }
            Console.Write(_dealer.HandValue());
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        private void DealerWins()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You Lose");
            Console.ForegroundColor = ConsoleColor.White;

            _status = GameStatus.Lost;
            _dealer.Points += 1;
            Save();
        }

        private void PlayerWin()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Win");
            Console.ForegroundColor = ConsoleColor.White;

            if (_player.BestValue == 21)
            {
                _status = GameStatus.BlackJack;
                _player.MoneyPot += 3 * _player.Bet;
                _player.Points += 1;
            }
            else if (_player.BestValue < 21)
            {
                _status = GameStatus.Won;
                _player.MoneyPot += 2 * _player.Bet;
                _player.Points += 1;
            }
            Save();
        }

        private void Tie()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Its a tie");
            Console.ForegroundColor = ConsoleColor.White;

            _status = GameStatus.Tie;
            _player.MoneyPot += _player.Bet;
            Save();
        }

        private void WinOrLose()
        {
            if (_player.BestValue == 21)
            {
                PlayerWin();
            }
            else if (_player.BestValue < 21)
            {
                if (_dealer.BestValue <= 21)
                {
                    if (_player.BestValue > _dealer.BestValue)
                    {
                        PlayerWin();
                    }
                    else if (_player.BestValue < _dealer.BestValue)
                    {
                        DealerWins();
                    }
                    else if (_player.BestValue == _dealer.BestValue)
                    {
                        if (_dealer.BestValue == 20)
                        {
                            Tie();
                        }
                        else
                        {
                            DealerWins();
                        }
                    }
                }
                else if (_dealer.BestValue > 21)
                {
                    PlayerWin();
                }
            }
            else if (_player.BestValue > 21)
            {
                DealerWins();
            }
        }

        private void Betting()
        {
            Console.WriteLine($"How much do you want to bet of your ${_player.MoneyPot}");
            bool WaitingForBet = true;

            while (WaitingForBet)
            {
                _player.Bet = Int32.Parse(Console.ReadLine());

                if (_player.Bet <= _player.MoneyPot && _player.Bet > 0)
                {
                    WaitingForBet = false;
                }
                else if (_player.Bet > _player.MoneyPot)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You cant bet ${_player.Bet} because you only have ${_player.MoneyPot} in your pot");
                    Console.WriteLine($"How much do you want to bet of your ${_player.MoneyPot}");
                }
                else if (_player.Bet <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You cant bet ${_player.Bet} because you cant bet 0 or less money");
                    Console.WriteLine($"How much do you want to bet of your ${_player.MoneyPot}");
                }
            }

            _player.MoneyPot -= _player.Bet;
        }

        private void WriteOutPointsAndMoney()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Your points: {_player.Points}");
            Console.WriteLine($"Your Pot is ${_player.MoneyPot}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Dealers points: {_dealer.Points}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
        }

        private void Reset()
        {
            _deck.ResetDeck();

            bool RemoveCards = true;
            int PlayerLastCard;
            int DealerLastCard;

            while (RemoveCards)
            {
                PlayerLastCard = _player.Hand.Count - 1;
                DealerLastCard = _dealer.Hand.Count - 1;

                if (_player.Hand.Count - 1 > -1)
                {
                    _player.Hand.Remove(_player.Hand[PlayerLastCard]);
                }
                else
                {
                    if (_dealer.Hand.Count - 1 > -1)
                    {
                        _dealer.Hand.Remove(_dealer.Hand[DealerLastCard]);
                    }
                    else
                    {
                        _status = GameStatus.Playing;
                        RemoveCards = false;
                    }
                }
            }
        }
    }
}
