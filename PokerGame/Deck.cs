using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public class Deck : Card
    {
        const int CARD_Count = 52; //Total card count
        private Card[] deck; //All play carding

        public Deck()
        {
            deck = new Card[CARD_Count];
        }
        public Card[] getDeck { get { return deck; } } //get current deck of cards

        //Create 52 cards with 13 values and 4 suits
        public void setUpDeck()
        {
            int i = 0;
            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { mySuit = s, myValue = v };
                    i++;
                }
            }
        }
        //Shuffle the deck using a random index
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;
            for (int shuffle = 0; shuffle < 1000; shuffle++)
            {
                for (int i = 0; i < CARD_Count; i++)
                {   
                    //swap card index.
                    int secCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secCardIndex];
                    deck[secCardIndex] = temp;
                }
            }
        }
    }
}
