using System;
using System.Collections.Generic;
using System.Linq;

namespace Black_Jack
{
    public class Deck
    {
        static readonly Random rnd = new Random();
        private readonly int _nrOfDecks;

        public List<Card> Cards { get; } = new List<Card>();

        public Deck(int nrOfDecks)
        {
            _nrOfDecks = nrOfDecks;
            NewDeck(nrOfDecks);
        }

        public void ResetDeck()
        {
            NewDeck(_nrOfDecks);
        }

        private void NewDeck(int nrOfDecks)
        {
            for (int i = 0; i <= nrOfDecks; i++)
            {
                foreach (SuitType suit in Enum.GetValues(typeof(SuitType)))
                {
                    for (int c = 1; c <= 13; c++)
                    {
                        Cards.Add(new Card(c, suit));
                    }
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < 3; i++)
            {
                int n = Cards.Count;

                while (n > 1)
                {
                    n--;
                    int k = rnd.Next(n + 1);
                    Card value = Cards[k];
                    Cards[k] = Cards[n];
                    Cards[n] = value;
                }
            }
        }

        public Card PickACard()
        {
            var card = Cards.First();

            Cards.Remove(card);

            return card;
        }

        
    }
}