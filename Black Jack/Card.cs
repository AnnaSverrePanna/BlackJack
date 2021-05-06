using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Jack
{
    public class Card
    {
        public int Value { get; }
        public SuitType Suit { get; }

        public Card(int value, SuitType suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            string text;

            switch (Value)
            {
                case 1:
                    text = "A";
                    break;

                case 11:
                    text = "Kn";
                    break;

                case 12:
                    text = "Q";
                    break;

                case 13:
                    text = "K";
                    break;

                default:
                    text = Value.ToString();
                    break;

            }

            switch (Suit)
            {
                case SuitType.Club:
                    text += "♣";
                    break;

                case SuitType.Diamond:
                    text += "♦";
                    break;

                case SuitType.Heart:
                    text += "♥";
                    break;

                case SuitType.Spade:
                    text += "♠";
                    break;
            }

            return text;
        }

        public int LowValue
        {
            get
            {
                switch (Value)
                {
                    case 11:
                        return 10;

                    case 12:
                        return 10;

                    case 13:
                        return 10;

                    default:
                        return Value;
                }
            }
        }

        public int HighValue
        {
            get
            {
                var low = LowValue;

                if (low == 1)
                {
                    return 11;
                }

                return low;
            }
        }
    }
}