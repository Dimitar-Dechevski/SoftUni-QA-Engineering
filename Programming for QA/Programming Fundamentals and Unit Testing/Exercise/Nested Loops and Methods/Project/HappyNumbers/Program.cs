namespace HappyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= n; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit <= n; secondDigit++)
                {
                    for (int thirdDigit = 0; thirdDigit <= n; thirdDigit++)
                    {
                        for (int fourthDigit = 0; fourthDigit <= n; fourthDigit++)
                        {
                            int sumFirstTwoDigits = firstDigit + secondDigit;
                            int sumLastTwoDigits = thirdDigit + fourthDigit;
                            if (sumFirstTwoDigits == sumLastTwoDigits && sumFirstTwoDigits == n)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
