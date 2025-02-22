namespace OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> words = new Dictionary<string, int>();

            for (int i = 0; i < input.Count; i++)
            {
                string word = input[i].ToLower();

                if (words.ContainsKey(word))
                {
                    words[word] = words[word] + 1;
                }
                else
                {
                    words.Add(word, 1);
                }
            }

            foreach (KeyValuePair<string, int> entry in words)
            {
                if (entry.Value % 2 == 1)
                {
                    Console.Write(entry.Key + " ");
                }
            }

        }
    }
}
