namespace WorkingHours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if (day.Equals("Monday")
                 || day.Equals("Tuesday")
                 || day.Equals("Wednesday")
                 || day.Equals("Thursday")
                 || day.Equals("Friday")
                 || day.Equals("Saturday"))
            {
                if (hour >= 10 && hour <= 18)
                {
                    Console.WriteLine("open");
                }
                else
                {
                    Console.WriteLine("closed");
                }
            }
            else if (day.Equals("Sunday"))
            {
                Console.WriteLine("closed");
            }
        }
    }
}
