namespace FreezingWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int celsius = int.Parse(Console.ReadLine());

            if (celsius <= 0)
            {
                Console.WriteLine("Freezing weather!");
            }
        }
    }
}
