using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(2, 2);
            var circle = new Circle(4);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
        }
    }
}
