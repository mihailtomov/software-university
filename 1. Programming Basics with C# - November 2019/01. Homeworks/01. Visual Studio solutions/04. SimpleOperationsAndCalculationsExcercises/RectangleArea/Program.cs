using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            // calculate sides:
            double a = Math.Abs(x2 - x1);
            double b = Math.Abs(y2 - y1);

            Console.WriteLine(a);
            Console.WriteLine(b);
            //area:

            double area = a * b;
           

            //perimeter
            double perimeter = (a + b) * 2;
            Console.WriteLine($"{area:F2}");
            Console.WriteLine(perimeter);
            Console.WriteLine(Math.Round(perimeter, 2));
        }
    }
}
