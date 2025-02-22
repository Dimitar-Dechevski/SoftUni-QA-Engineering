namespace ReverseAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int input = int.Parse(Console.ReadLine());
                numbers[i] = input;
            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
