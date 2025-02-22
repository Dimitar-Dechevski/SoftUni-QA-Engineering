namespace USDToEUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dollars = double.Parse(Console.ReadLine());
            double euros = dollars * 0.88;
            Console.WriteLine($"{euros:F2}");
        }
    }
}
