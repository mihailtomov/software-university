using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int current = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 0; cols <= rows; cols++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write(current + " ");
                    current++;
                }

                if (isBigger)
                {
                    break;
                }

                Console.WriteLine();        
            }

            //// or

            ////int n = int.Parse(Console.ReadLine());

            ////int current = 1;

            ////int cols = 1;
            ////int printedNums = 0;

            ////for (int rows = 1; rows <= n; rows++)
            ////{
            ////    Console.Write(current + " ");
            ////    printedNums++;
            ////    if (printedNums == cols)
            ////    {
            ////        Console.WriteLine();
            ////        cols++;
            ////        printedNums = 0;
            ////    }
            ////    current++;
            ////    if (current > n)
            ////    {
            ////        return;
            ////    }
            ////}
        }
    }
}
