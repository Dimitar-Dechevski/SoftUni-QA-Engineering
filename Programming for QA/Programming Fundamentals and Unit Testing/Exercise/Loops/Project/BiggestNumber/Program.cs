namespace BiggestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            Console.WriteLine(maxNumber);
        }
    }
}
