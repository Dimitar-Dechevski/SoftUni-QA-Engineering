namespace Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            int n = int.Parse(Console.ReadLine());

            while (number <= n)
            {
                Console.WriteLine(number);
                number = 2 * number + 1;
            }
        }
    }
}
