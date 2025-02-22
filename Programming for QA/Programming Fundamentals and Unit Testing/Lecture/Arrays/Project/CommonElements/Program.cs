namespace CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < firstArray.Length; i++)
            {
                foreach (int item in secondArray)
                {
                    if (firstArray[i] == item)
                    {
                        Console.Write($"{item} ");
                        break;
                    }
                }
            }

        }
    }
}
