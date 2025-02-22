namespace TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string text = Console.ReadLine();

            for (int i = 0; i < words.Length; i++)
            {
                int count = words[i].Length;
                string asterisks = "";

                for (int j = 1; j <= count; j++)
                {
                    asterisks += "*";
                }

                text = text.Replace(words[i], asterisks);
            }

            Console.WriteLine(text);

        }
    }
}
