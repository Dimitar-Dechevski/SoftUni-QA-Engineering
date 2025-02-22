namespace DaysInMinutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int minutes = (days * 24) * 60;
            Console.WriteLine($"Minutes = {minutes}");
        }
    }
}
