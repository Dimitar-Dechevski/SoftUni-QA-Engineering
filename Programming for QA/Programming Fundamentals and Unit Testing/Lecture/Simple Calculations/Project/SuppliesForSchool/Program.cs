namespace SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int litersOfBoardClener = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double result = (pens * 5.80) + (markers * 7.20) + (litersOfBoardClener * 1.20);
            double total = result - (result * discount / 100);

            Console.WriteLine(total);
        }
    }
}
