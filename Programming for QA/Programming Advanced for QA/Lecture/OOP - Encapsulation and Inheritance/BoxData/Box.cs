using System;
using System.Text;

namespace BoxData;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double SurfaceArea()
    {
        double area = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        return area;
    }

    public double Volume()
    {
        double volume = Length * Width * Height;
        return volume;
    }

    public override string ToString()
    {
        return $"Surface Area – {SurfaceArea():F2}{Environment.NewLine}Volume – {Volume():F2}";
    }

}


