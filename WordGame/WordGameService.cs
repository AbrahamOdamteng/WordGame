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

        LinkedList<LeaderBoardEntry> LeaderBoard = new LinkedList<LeaderBoardEntry>();


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
            if(position >= LeaderBoard.Count)
            {
                return null;
            }
            return LeaderBoard.ToArray()[position].PlayerName;
        }

        public int? GetScoreAtPosition(int position)
        {
            if (position >= LeaderBoard.Count)
            {
                return null;
            }
            return LeaderBoard.ToArray()[position].Score;
        }

        public string GetWordEntryAtPosition(int position)
        {
            if (position >= LeaderBoard.Count)
            {
                return null;
            }
            return LeaderBoard.ToArray()[position].Word;
        }

        public int? SubmitWord(string playerName, string word)
        {
            if (!ValidWords.Contains(word))
            {
                return null;
            }

            if(CanMakeWordFromLetters(word))
            {
                AddToLeaderBoard(new LeaderBoardEntry(playerName, word));
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

        void AddToLeaderBoard(LeaderBoardEntry entry)
        {
            if (!LeaderBoard.Any())
            {
                LeaderBoard.AddFirst(entry);
            }
            else
            {
                if(LeaderBoard.First.Value.Score < entry.Score)
                {
                    LeaderBoard.AddFirst(entry);
                    return;
                }

                var current = LeaderBoard.Last;
                
                while (current != null)
                {
                    if (current.Value.Score >= entry.Score)
                    {
                        LeaderBoard.AddAfter(current, entry);
                    }
                    current = current.Previous;
                }
            }
        }

    }

    struct LeaderBoardEntry
    {
        internal LeaderBoardEntry(string playerName,string word)
        {
            PlayerName = playerName;
            Word = word;
        }

        internal readonly string PlayerName;
        internal readonly string Word;

        internal int Score { get { return Word.Length; } }
    }
}
