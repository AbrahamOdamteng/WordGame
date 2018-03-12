namespace WordGame
{
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class ValidWords : IValidWords
    {
        ArrayList a = new ArrayList();

        public ValidWords()
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                stream = Assembly.GetAssembly(typeof(ValidWords)).GetManifestResourceStream("WordGame.wordlist.txt");
                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    a.Add(reader.ReadLine());
                }
            }
            finally
            {
                reader.Dispose();
                stream.Dispose();
            }
        }

        public int Size
        {
            get { return a.Count; }
        }

        public bool Contains(string word)
        {
            return a.Contains(word);
        }
    }
}
