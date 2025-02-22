namespace PetsFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());
            double dogFoodPrice = 2.50;
            double catFoodPrice = 4.00;
            double result = (dogFood * dogFoodPrice) + (catFood * catFoodPrice);
            Console.WriteLine($"{result:F2} lv.");
        }
    }
}
