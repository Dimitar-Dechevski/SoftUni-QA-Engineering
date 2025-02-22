namespace CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, int> characters = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol.Equals(' '))
                {
                    continue;
                }

                if (characters.ContainsKey(symbol))
                {
                    characters[symbol] += 1;
                }
                else
                {
                    characters.Add(symbol, 1);
                }
            }

            foreach (KeyValuePair<char, int> entry in characters)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }

        }
    }
}
