namespace Tiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bathWidth = double.Parse(Console.ReadLine());
            double bathHeight = double.Parse(Console.ReadLine());
            double tileWidth = double.Parse(Console.ReadLine());
            double tileHeight = double.Parse(Console.ReadLine());

            double bathArea = bathWidth * bathHeight;
            double allArea = bathArea + (bathArea * 0.10);
            double tileArea = tileWidth * tileHeight;
            double tileQuantity = Math.Round(allArea / tileArea);

            Console.WriteLine(tileQuantity);
        }
    }
}
