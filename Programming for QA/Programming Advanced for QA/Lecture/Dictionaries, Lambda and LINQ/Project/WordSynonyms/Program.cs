namespace WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(word))
                {
                    words[word].Add(synonym);
                }
                else
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
            }

            foreach (KeyValuePair<string, List<string>> entry in words)
            {
                Console.WriteLine($"{entry.Key} - {string.Join(", ", entry.Value)}");
            }

        }
    }
}
