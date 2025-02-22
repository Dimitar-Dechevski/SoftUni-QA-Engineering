using System;

using BoxData;

double length = double.Parse(Console.ReadLine()!);
double width = double.Parse(Console.ReadLine()!);
double height = double.Parse(Console.ReadLine()!);

try
{
    Console.WriteLine(new Box(length, width, height));
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
