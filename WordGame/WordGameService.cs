namespace WordGame
{
    using System;

    public class WordGameService : IWordGameService
    {
        public WordGameService(string letters, IValidWords validWords)
        {
            throw new NotImplementedException();
        }

        public WordGameService(char[] letters, IValidWords validWords)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerNameAtPosition(int position)
        {
            throw new NotImplementedException();
        }

        public int? GetScoreAtPosition(int position)
        {
            throw new NotImplementedException();
        }

        public string GetWordEntryAtPosition(int position)
        {
            throw new NotImplementedException();
        }

        public int? SubmitWord(string playerName, string word)
        {
            throw new NotImplementedException();
        }
    }
}
