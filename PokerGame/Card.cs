using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public class Card
    {
        public enum SUIT
        {
            HEARTS,
            SPADES,
            DIMONDS,
            CLUBS
        }
        public enum VALUE
        {
            //set TWO enum value to 2. This will align the enum count
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE,
            TEN, JACK, QUEEN, KING, ACE 
        }
        //public properties
        public SUIT mySuit { get; set; }
        public VALUE myValue { get; set; }
    }
}
