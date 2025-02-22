namespace CalculateAverageGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                sum += grade;
            }

            double averageSum = sum / n;
            Console.WriteLine($"{averageSum:F2}");

        }
    }
}
