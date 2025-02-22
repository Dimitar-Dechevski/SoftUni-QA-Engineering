namespace TestApp;
public class PrimeNumbers
{
    public static string GetPrimeNumbersInRange(int startNum, int endNum)
    {
        if (startNum > endNum)
        {
            return "Start number should be bigger than end number.";
        }

        string result = string.Empty;
        for (int i = startNum; i <= endNum; i++)
        {
            bool isPrime = IsPrimeNumber(i);

            if (isPrime)
            {
                result += $"{i} ";
            }
        }

        return result.Trim();
    }

    private static bool IsPrimeNumber(int num)
    {
        if (num == 0 || num == 1)
        {
            return false;
        }

        for (int j = 2; j <= Math.Sqrt(num); j++)
        {
            if (num % j == 0)
            {
                return false;
            }
        }

        return true;
    }
}

