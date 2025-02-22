namespace WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length % 2 == 0)
                .ToList();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

        }
    }
}
