namespace WordGameTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WordGame;

    [TestClass]
    public class WordGameServiceTest
    {
        private IValidWords validWords = new ValidWords();
        private WordGameService wordGameService;
        
        [TestInitialize]
        public void Initialize()
        {
            this.wordGameService = new WordGameService("areallylongword", this.validWords);
        }

        [TestMethod]
        public void TestSubmissions()
        {
            Assert.AreEqual(3, this.wordGameService.SubmitWord("player1", "all"));
            Assert.AreEqual(4, this.wordGameService.SubmitWord("player2", "word"));
            Assert.AreEqual(null, this.wordGameService.SubmitWord("player3", "tale"));
            Assert.AreEqual(null, this.wordGameService.SubmitWord("player4", "glly"));
            Assert.AreEqual(6, this.wordGameService.SubmitWord("player5", "woolly"));
            Assert.AreEqual(null, this.wordGameService.SubmitWord("player6", "adder"));
        }

        [TestMethod]
        public void TestGetPlayerNameAtPosition()
        {
            wordGameService.SubmitWord("player1", "all");
            wordGameService.SubmitWord("player2", "word");
            wordGameService.SubmitWord("player5", "woolly");

            var firstPlayer = wordGameService.GetPlayerNameAtPosition(0);
            Assert.AreEqual("player5", firstPlayer);

            var secondPlayer = wordGameService.GetPlayerNameAtPosition(1);
            Assert.AreEqual("player2", secondPlayer);

            var lastPlayer = wordGameService.GetPlayerNameAtPosition(2);
            Assert.AreEqual("player1", lastPlayer);

            var nullPlayer = wordGameService.GetPlayerNameAtPosition(9);
            Assert.IsNull(nullPlayer);
        }

        [TestMethod]
        public void TestGetScoreAtPosition()
        {
            wordGameService.SubmitWord("player1", "all");
            wordGameService.SubmitWord("player2", "word");
            wordGameService.SubmitWord("player5", "woolly");

            var topeScore = wordGameService.GetScoreAtPosition(0);
            Assert.AreEqual(6, topeScore);

            var secondBestScore = wordGameService.GetScoreAtPosition(1);
            Assert.AreEqual(4, secondBestScore);

            var lastPlaceScore = wordGameService.GetScoreAtPosition(2);
            Assert.AreEqual(3, lastPlaceScore);

            var nullScore = wordGameService.GetScoreAtPosition(9);
            Assert.IsNull(nullScore);
        }

        [TestMethod]
        public void TestGetWordEntryAtPosition()
        {
            wordGameService.SubmitWord("player1", "all");
            wordGameService.SubmitWord("player2", "word");
            wordGameService.SubmitWord("player5", "woolly");

            var topWord = wordGameService.GetWordEntryAtPosition(0);
            Assert.AreEqual("woolly", topWord);

            var secondBestWord = wordGameService.GetWordEntryAtPosition(1);
            Assert.AreEqual("word", secondBestWord);

            var lastWord = wordGameService.GetWordEntryAtPosition(2);
            Assert.AreEqual("all", lastWord);

            var nullScore = wordGameService.GetWordEntryAtPosition(9);
            Assert.IsNull(nullScore);
        }

    }
}
