namespace MandatoryLiterature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int timeForAllPages = allPages / pagesPerHour;
            int timePerDays = timeForAllPages / days;

            Console.WriteLine(timePerDays);
        }
    }
}
