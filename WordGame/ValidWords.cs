namespace WordGame
{
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class ValidWords : IValidWords
    {
        //CODE-REVIEW:bad variable name. need something more descriptive
        ArrayList a = new ArrayList();

        public ValidWords()
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {

                //CODE-REVIEW: Use System.IO.File.ReadAllLines() instead of this.
                stream = Assembly.GetAssembly(typeof(ValidWords)).GetManifestResourceStream("WordGame.wordlist.txt");
                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    a.Add(reader.ReadLine());
                }
            }
            finally
            {
                //CODE-REVIEW: This will not be needed if you use System.IO.File.ReadAllLines();
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
