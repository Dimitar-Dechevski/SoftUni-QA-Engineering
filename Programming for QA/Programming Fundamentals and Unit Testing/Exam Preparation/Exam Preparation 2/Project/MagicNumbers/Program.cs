using System.Reflection.Metadata.Ecma335;

namespace MagicNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            bool isPrime = false;

            for (int i = 2; i <= n; i++)
            {
                int item = i;
                int sum = 0;
                int element = item;

                while (element > 0)
                {
                    int digit = element % 10;

                    if (digit == 2 || digit == 3 || digit == 5 || digit == 7)
                    {
                        sum += digit;
                        isPrime = true;
                    } else
                    {
                        isPrime = false;
                        break;
                    }

                    element = element / 10;
                }

                if (sum % 2 == 0 && isPrime)
                {
                    numbers.Add(item);
                }

            }

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
