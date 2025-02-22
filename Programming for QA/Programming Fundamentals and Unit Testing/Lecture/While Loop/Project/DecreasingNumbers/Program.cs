namespace DecreasingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n > 0)
            {
                Console.WriteLine(n);
                n--;
            }
        }
    }
}
