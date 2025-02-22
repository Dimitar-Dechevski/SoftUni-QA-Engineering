namespace VacationExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string season = Console.ReadLine();
            string accommodationType = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double total = 0;
            double discount = 0;
            double price = 0;

            if (season.Equals("Spring"))
            {
                discount = 0.20;

                if (accommodationType.Equals("Hotel"))
                {
                    price = 30;
                }
                else if (accommodationType.Equals("Camping"))
                {
                    price = 10;
                }
            }
            else if (season.Equals("Summer"))
            {
                if (accommodationType.Equals("Hotel"))
                {
                    price = 50;
                }
                else if (accommodationType.Equals("Camping"))
                {
                    price = 30;
                }
            }
            else if (season.Equals("Autumn"))
            {
                discount = 0.30;

                if (accommodationType.Equals("Hotel"))
                {
                    price = 20;
                }
                else if (accommodationType.Equals("Camping"))
                {
                    price = 15;
                }
            }
            else if (season.Equals("Winter"))
            {
                discount = 0.10;

                if (accommodationType.Equals("Hotel"))
                {
                    price = 40;
                }
                else if (accommodationType.Equals("Camping"))
                {
                    price = 10;
                }
            }

            total = (days * price) - (days * price * discount);
            Console.WriteLine($"{total:F2}");

        }
    }
}
