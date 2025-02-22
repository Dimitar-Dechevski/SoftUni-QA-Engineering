namespace NutritionAndCaloricIntakeAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sumCalories = 0;

            if (count <= 0)
            {
                Console.WriteLine(0);
            }

            while (count > 0)
            {
                int calories = int.Parse(Console.ReadLine());
                sumCalories += calories;
                Console.WriteLine(sumCalories);
                count--;
            }

        }
    }
}
