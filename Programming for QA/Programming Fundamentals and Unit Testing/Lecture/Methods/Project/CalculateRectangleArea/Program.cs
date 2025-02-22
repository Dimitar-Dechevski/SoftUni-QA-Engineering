namespace CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int area = CalculateRectangleArea(width, length);
            Console.WriteLine(area);
        }

        static int CalculateRectangleArea(int width, int length)
        {
            int area = width * length;
            return area;
        }
    }
}
