using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Jack
{
    public class Dealer : Player
    {
        public override int BestValue
        {
            get
            {
                return HighValue;
            }
        }

        public override string HandValue()
        {
            var best = HighValue;
            return $" (Value: {best})";
        }
    }
}
