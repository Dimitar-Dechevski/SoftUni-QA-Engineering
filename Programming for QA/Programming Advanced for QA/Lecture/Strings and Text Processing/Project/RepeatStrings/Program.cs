namespace RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                int counter = words[i].Length;

                for (int j = 0; j < counter; j++)
                {
                    Console.Write($"{words[i]}");
                }

            }

        }
    }
}
