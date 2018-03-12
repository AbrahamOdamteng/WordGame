namespace WordGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WordGameService : IWordGameService
    {
        object lockObject = new object();
        readonly IEnumerable<char> Letters;
        IValidWords ValidWords;

        public WordGameService(string letters, IValidWords validWords)
        {
            Letters = letters.OrderBy(c => c).ToArray();
            ValidWords = validWords;
        }

        public WordGameService(char[] letters, IValidWords validWords)
        {
            Letters = letters.OrderBy(c => c).ToArray();
            ValidWords = validWords;

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

            if (!ValidWords.Contains(word))
            {
                return null;
            }


            if(CanMakeWordFromLetters(word))
            {
                return word.Count();
            }
            return null;

        }

        bool CanMakeWordFromLetters(string word)
        {
            var stack = new Stack<char>(word.OrderByDescending(c => c));
            foreach (var c in Letters)
            {
                if(c == stack.Peek())
                {
                    stack.Pop();
                    if (!stack.Any()) return true;
                }
            }

            if (stack.Any()) return false;
            return true;
        }

    }
}
