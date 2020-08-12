using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());

            // hall area:

            double hallArea = L * W;
            double wardrobeArea = Math.Pow(A, 2);
            double benchArea = hallArea / 10;

            double freeSpace = hallArea - wardrobeArea - benchArea;
            freeSpace = freeSpace * 10000;
            double dancers = Math.Floor(freeSpace / 7040);
            Console.WriteLine(dancers);


            //double dancers = freeSpace / 7040;
        }
    }
}
