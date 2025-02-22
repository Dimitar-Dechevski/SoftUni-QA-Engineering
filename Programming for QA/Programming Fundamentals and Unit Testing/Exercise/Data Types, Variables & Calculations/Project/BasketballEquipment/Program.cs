namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int basketballTrainingFee = int.Parse(Console.ReadLine());

            double sneakersPrice = basketballTrainingFee - (basketballTrainingFee * 40 / 100);
            double uniformPrice = sneakersPrice - (sneakersPrice * 20 / 100);
            double ballPrice = uniformPrice / 4;
            double accessoriesPrice = ballPrice / 5;

            double totalCosts = sneakersPrice + uniformPrice + ballPrice + accessoriesPrice + basketballTrainingFee;
            Console.WriteLine(totalCosts);
        }
    }
}
