namespace SummerOutfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int temperature = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string clothing = "";
            string shoes = "";

            if (temperature >= 10 && temperature <= 18)
            {
                if (timeOfDay.Equals("Morning"))
                {
                    clothing = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (timeOfDay.Equals("Afternoon"))
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeOfDay.Equals("Evening"))
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (temperature > 18 && temperature <= 24)
            {
                if (timeOfDay.Equals("Morning"))
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
                else if (timeOfDay.Equals("Afternoon"))
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeOfDay.Equals("Evening"))
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (temperature >= 25)
            {
                if (timeOfDay.Equals("Morning"))
                {
                    clothing = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (timeOfDay.Equals("Afternoon"))
                {
                    clothing = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (timeOfDay.Equals("Evening"))
                {
                    clothing = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {temperature} degrees, get your {clothing} and {shoes}.");

        }
    }
}
