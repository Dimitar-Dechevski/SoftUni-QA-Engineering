namespace Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylonMeters = int.Parse(Console.ReadLine());
            int paintLiters = int.Parse(Console.ReadLine());
            int thinnerLiters = int.Parse(Console.ReadLine());
            int workHours = int.Parse(Console.ReadLine());

            double bagsPrice = 0.40;
            double nylonCosts = (nylonMeters + 2) * 1.50;
            double paintCosts = (paintLiters + (paintLiters * 10 / 100)) * 14.50;
            double thinnerCosts = thinnerLiters * 5.00;

            double allMaterialCost = nylonCosts + paintCosts + thinnerCosts + bagsPrice;
            double workerCosts = (allMaterialCost * 30 / 100) * workHours;
            double totalCosts = allMaterialCost + workerCosts;

            Console.WriteLine(totalCosts);
        }
    }
}
