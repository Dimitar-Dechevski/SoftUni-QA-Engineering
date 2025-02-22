using System;
using System.Globalization;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startIndex = 1;
            int endIndex = 100;
            List<int> numbers = ReadNumber(startIndex, endIndex);

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static List<int> ReadNumber(int start, int end)
        {
            List<int> elements = new List<int>();

            while (elements.Count < 10)
            {
                try
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num <= start || num >= end)
                    {
                        throw new Exception();
                    }

                    elements.Add(num);
                    start = num;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                }
            }

            return elements;
        }

    }
}