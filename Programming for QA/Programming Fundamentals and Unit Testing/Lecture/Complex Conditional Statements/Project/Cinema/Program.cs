namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfMovie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            double price = 0;
            double total = 0;

            if (typeOfMovie.Equals("Premiere"))
            {
                price = 12;
                total = rows * seats * price;
            }
            else if (typeOfMovie.Equals("Normal"))
            {
                price = 7.50;
                total = rows * seats * price;
            }
            else if (typeOfMovie.Equals("Discount"))
            {
                price = 5;
                total = rows * seats * price;
            }

            Console.WriteLine($"{total:F2}");
        }
    }
}
