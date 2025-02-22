namespace AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure.Equals("square")) 
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;
                Console.WriteLine($"{area:F2}");
            }
            else if (figure.Equals("rectangle"))
            {    
                double width = double.Parse(Console.ReadLine());
                double length = double.Parse(Console.ReadLine());
                double area = width * length;
                Console.WriteLine($"{area:F2}");
            }
            else if (figure.Equals("circle"))
            {
                double radius = double.Parse(Console.ReadLine());
                double area = radius * radius * Math.PI;
                Console.WriteLine($"{area:F2}");
            }
        }
    }
}
