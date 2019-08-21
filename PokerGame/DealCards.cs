using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerGame
{
    public class DealCards : Deck
    {
        private Card[] playerOneHand;
        private Card[] playerTwoHand;
        private Card[] sortedPlayerOneHand;
        private Card[] sortedPlayerTwoHand;

        public DealCards() {
            playerOneHand = new Card[5];
            sortedPlayerOneHand = new Card[5];
            playerTwoHand = new Card[5];
            sortedPlayerTwoHand = new Card[5];
        }

        //Get 5 cards for each player
        public void getHand()
        {
            //Get 5 total cards for player one
            for (int i = 0; i < 5; i++) {
                playerOneHand[i] = getDeck[i];
            }
            //Get next 5 cards for player two
            for (int i = 0; i < 5; i++){
                playerTwoHand[i] = getDeck[i + 5];
            }

        }
        public void sortCard()
        {
            //order by number/my value
            var queryPlayerOne = from hand in playerOneHand
                                 orderby hand.myValue
                                 select hand;


            var queryPlayerTwo = from hand in playerTwoHand
                                 orderby hand.myValue
                                 select hand;

            //Convert to list and assign elements of the list to the sorted playerhand arrays
            var index = 0;
            foreach (var element in queryPlayerOne.ToList())
            {
                sortedPlayerOneHand[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in queryPlayerTwo.ToList())
            {
                sortedPlayerTwoHand[index] = element;
                index++;
            }
        }
        public string determineWinningHand() {
            //pass sorted hands to evaluator
            string pokerGameWinner = "";
            HandEval playerOneHandEvaluator = new HandEval(sortedPlayerOneHand);
            HandEval playerTwoHandEvaluator = new HandEval(sortedPlayerTwoHand);

            //get payers one and twos hands
            Hand playerOneHand = playerOneHandEvaluator.EvaluteHand();
            Hand playerTwoHand = playerTwoHandEvaluator.EvaluteHand();

            //Evaluate hands
            if (playerOneHand > playerTwoHand)
            {
                pokerGameWinner = "Player One WINS!";                
            }
            else if (playerTwoHand < playerOneHand)
            {
                pokerGameWinner = "Player Two WINS!";
            }
            else //if they are equal, evaluate 
            {
                if (playerOneHandEvaluator.HandValue.Total > playerTwoHandEvaluator.HandValue.Total)
                {
                    pokerGameWinner = "Player One WINS";
                }
                else if (playerOneHandEvaluator.HandValue.Total < playerTwoHandEvaluator.HandValue.Total)
                {
                    pokerGameWinner = "Player Two WINS";
                }
                else if (playerOneHandEvaluator.HandValue.HighCard < playerTwoHandEvaluator.HandValue.HighCard)
                {
                    pokerGameWinner = "Player One WINS";
                }
                else if (playerOneHandEvaluator.HandValue.HighCard > playerTwoHandEvaluator.HandValue.HighCard)
                {
                    pokerGameWinner = "Player Two WINS";
                }
                else
                {
                    pokerGameWinner = "No winner";
                }
            }           
                return pokerGameWinner;
        }

    }
}
