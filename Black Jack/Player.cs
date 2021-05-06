using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Black_Jack
{
    public class Player
    {
        public string Name { get; set; }

        public List<Card> Hand { get; } = new List<Card>();

        public Card LastDrawnCard { get; set; }
        public int Points { get; set; }

        public int LowValue
        {
            get
            {
                return Hand.Sum(card => card.LowValue);
            }
        }

        public int HighValue
        {
            get
            {
                return Hand.Sum(card => card.HighValue);
            }
        }

        public virtual int BestValue
        {
            get
            {
                int lowest = 0;
                int highest = 0;

                foreach (var card in Hand)
                {
                    lowest += card.LowValue;

                    if (highest + card.HighValue > 21)
                    {
                        highest += card.LowValue;
                    }
                    else
                    {
                        highest += card.HighValue;
                    }
                }

                if (highest > 21)
                {
                    return lowest;
                }
                else
                {
                    return highest;
                }
            }
        }

        public int MoneyPot { get; set; }

        public int Bet { get; set; }

        public virtual string HandValue()
        {
            var low = LowValue;
            var high = HighValue;
            var best = BestValue;

            if (low != best)
            {
                return $" (Low value: {low}, High value: {high}) Best value: {best}";
            }
            else
            {
                return $" (Value: {best})";
            }
        }

        internal void AddCard(Card card)
        {
            LastDrawnCard = card;
            Hand.Add(card);
        }

        internal void RemoveCard(Card card)
        {
            Hand[Hand.Count - 1] = card;
            Hand.Remove(card);
        }
    }
}