namespace InchesToCentimetersConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            double centemeters = inches * 2.54;
            Console.WriteLine(centemeters);
        }
    }
}
