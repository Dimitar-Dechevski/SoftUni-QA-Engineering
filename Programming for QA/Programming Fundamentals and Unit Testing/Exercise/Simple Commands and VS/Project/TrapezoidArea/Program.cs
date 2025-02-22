namespace TrapezoidArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int area = (sideA + sideB) / 2 * height;
            Console.WriteLine(area);
        }
    }
}
