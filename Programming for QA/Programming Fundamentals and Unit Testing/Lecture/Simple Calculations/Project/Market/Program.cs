namespace Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tomatoPrice = double.Parse(Console.ReadLine());
            double tomatoQuantity = double.Parse(Console.ReadLine());
            double cucumberPrice = double.Parse(Console.ReadLine());
            double cucumberQuantity = double.Parse(Console.ReadLine());

            double result = (tomatoPrice * tomatoQuantity) + (cucumberPrice * cucumberQuantity);

            Console.WriteLine($"{result:F2}");
        }
    }
}
