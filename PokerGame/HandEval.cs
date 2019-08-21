using System;
using System.Collections.Generic;
using System.Text;

namespace PokerGame
{
    public enum Hand
    {
        nothing,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind
    }
    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }
    public class HandEval : Card
    {
        private int heartSum;
        private int diamondSum;
        private int clubSum;
        private int spadSum;
        private Card[] cards;
        private HandValue handValues;

        public HandEval(Card[] sortedHand)
        {
            heartSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadSum = 0;
            cards = new Card[5];
            cards = sortedHand;
            HandValue = new HandValue();
        }
        public HandValue HandValue
        {
            get { return handValues; }
            set { handValues = value; }
        }
        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }
        public Hand EvaluteHand()
        {
            //get suit count
            getSuitCount();
            if (FourOfAKind())
                return Hand.FourOfAKind;
            else if (Fullhouse())
                return Hand.FullHouse;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (threeOfAKind())
                return Hand.ThreeOfAKind;
            else if (twoPairs())
                return Hand.TwoPair;
            else if (OnePair())
                return Hand.OnePair;
            //If the hand is nothing, choose play with the highest card
            handValues.HighCard = (int)cards[4].myValue;
            return Hand.nothing;

        }

        public void getSuitCount()
        {
            //evaluate array of cards
            foreach (var c in cards)
            {
                if (c.mySuit == Card.SUIT.CLUBS)
                {
                    clubSum++;
                }
                else if (c.mySuit == Card.SUIT.DIMONDS)
                {
                    diamondSum++;
                }
                else if (c.mySuit == Card.SUIT.HEARTS)
                {
                    heartSum++;
                }
                else if (c.mySuit == Card.SUIT.SPADES)
                {
                    spadSum++;
                }
            }
        }
        private bool FourOfAKind()
        {
            //If the first 4 card equal vlaues of the four card and the last card is the highest
            if (cards[0].myValue == cards[1].myValue && cards[1].myValue == cards[2].myValue && cards[2].myValue == cards[3].myValue)
            {
                handValues.Total = (int)cards[1].myValue * 4;
                //store the highest card incase the other play has 4 of a kind 
                handValues.HighCard = (int)(cards[4].myValue);
                return true;
            }
            //second index position has matching values 1-4 
            else if (cards[1].myValue == cards[2].myValue && cards[1].myValue == cards[3].myValue && cards[1].myValue == cards[4].myValue)
            {
                handValues.Total = (int)cards[1].myValue * 4;
                //highest none matching card
                handValues.HighCard = (int)cards[0].myValue;
                return true;
            }
            return false;
        }
        public bool Fullhouse()
        {
            //Check to see if the first three cards are the same and check to see if the last two cards are the same
            //Checkt to see if the first two cards and the last 3 cards are the same
            if ((cards[0].myValue == cards[1].myValue && cards[0].myValue == cards[2].myValue && cards[3].myValue == cards[4].myValue) ||
                (cards[0].myValue == cards[1].myValue && cards[0].myValue == cards[2].myValue && cards[3].myValue == cards[4].myValue))
            {
                handValues.Total = (int)(cards[0].myValue) + (int)(cards[1].myValue) + (int)(cards[2].myValue) + (int)(cards[3].myValue) + (int)(cards[4].myValue);
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            //check to see if all suits are the same
            if (heartSum == 5 || clubSum == 5 || spadSum == 5 || diamondSum == 5)
            {
                //save one of the card values as the totals
                handValues.Total = (int)cards[0].myValue;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            // 5 cards are in sequence 
            if (cards[0].myValue + 1 == cards[1].myValue && cards[1].myValue + 1 == cards[2].myValue && cards[2].myValue + 1 == cards[3].myValue && cards[3].myValue + 1 == cards[4].myValue)
            {
                //Last card is highest. We will need to compare this value, if both hands are the same
                handValues.Total = (int)(cards[4].myValue);
            }
            return false;
        }
        private bool threeOfAKind()
        {
            //check to see if the 1-3 cards are the same
            //check to see if 2-4 are the same
            //checl to see if 3-5 are the same
            if (cards[0].myValue == cards[1].myValue && cards[0].myValue == cards[2].myValue ||
               cards[1].myValue == cards[2].myValue && cards[1].myValue == cards[3].myValue)
            {
                handValues.Total = (int)cards[2].myValue * 3;
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[2].myValue == cards[3].myValue && cards[2].myValue == cards[4].myValue)
            {
                handValues.Total = (int)cards[2].myValue * 3;
                handValues.HighCard = (int)cards[2].myValue;
                return true;
            }
            return false;
        }
        private bool twoPairs()
        {
            //if 1,2 and 3,4 match
            //if 1,2 and 4,5 match
            //if 2,3 and 4,5 match
            if (cards[0].myValue == cards[1].myValue && cards[2].myValue == cards[3].myValue)
            {
                handValues.Total = ((int)cards[1].myValue * 2) + ((int)cards[3].myValue * 2);
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[0].myValue == cards[1].myValue && cards[3].myValue == cards[4].myValue)
            {
                handValues.Total = ((int)cards[1].myValue * 2) + ((int)cards[3].myValue * 2);
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[1].myValue == cards[2].myValue && cards[3].myValue == cards[4].myValue)
            {
                handValues.Total = ((int)cards[1].myValue * 2) + ((int)cards[3].myValue * 2);
                handValues.HighCard = (int)cards[2].myValue;
                return true;
            }
            return false;
        }
        private bool OnePair()
        {
            //if 1,2 match
            //if 3,4 match
            //if 4,5 match

            if (cards[0].myValue == cards[1].myValue)
            {
                handValues.Total = (int)cards[0].myValue * 2;
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[1].myValue == cards[2].myValue)
            {
                handValues.Total = (int)cards[0].myValue * 2;
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[2].myValue == cards[3].myValue)
            {
                handValues.Total = (int)cards[0].myValue * 2;
                handValues.HighCard = (int)cards[4].myValue;
                return true;
            }
            else if (cards[3].myValue == cards[4].myValue)
            {
                handValues.Total = (int)cards[3].myValue * 2;
                handValues.HighCard = (int)cards[2].myValue;
                return true;
            }
            return false;
        }
    }
}
