using NUnit.Framework;
using PokerGame;

namespace Tests
{
    public class PokerGameTester
    {
        [Test]
        public void DetermineWinningHand_ReturnWinnerInfo_IsNotNull()
        {
            //Arrange
            DealCards D = new DealCards();
            //Act
            D.setUpDeck();
            D.ShuffleCards();
            D.getHand();
            D.sortCard();
            var result = D.determineWinningHand();
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void DetermineWinningHand_ReturnWinnerInfo_IsNotEmpty()
        {
            //Arrange
            DealCards D = new DealCards();
            //Act
            D.setUpDeck();
            D.ShuffleCards();
            D.getHand();
            D.sortCard();
            var result = D.determineWinningHand();
            //Assert
            Assert.IsNotEmpty(result);
        }
        [Test]
        public void setupDeck_CreateCompleteDeck_AreEqual()
        {
            //Arrange
            int CardCount = 52;
            DealCards D = new DealCards();
            //Act
            D.setUpDeck();
            D.ShuffleCards();
            var deckSize = D.getDeck.Length;
            //Assert card count is 52
            Assert.AreEqual(CardCount, deckSize);
        }
    }
}