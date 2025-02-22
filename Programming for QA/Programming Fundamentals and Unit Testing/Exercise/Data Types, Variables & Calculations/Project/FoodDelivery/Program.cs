namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegetarianMenu = int.Parse(Console.ReadLine());

            double deliveryPrice = 2.50;
            double chickenMenuCosts = chickenMenu * 10.35;
            double fishMenuCosts = fishMenu * 12.40;
            double vegetarianMenuCosts = vegetarianMenu * 8.15;

            double allMenuCosts = chickenMenuCosts + fishMenuCosts + vegetarianMenuCosts;
            double dessertCosts = allMenuCosts * 20 / 100;
            double totalCosts = allMenuCosts + dessertCosts + deliveryPrice;

            Console.WriteLine(totalCosts);
        }
    }
}
