namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int element = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(element);
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
