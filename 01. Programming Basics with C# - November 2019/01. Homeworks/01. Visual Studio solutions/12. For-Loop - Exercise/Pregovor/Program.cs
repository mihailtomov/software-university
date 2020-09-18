using System;

namespace Pregovor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello");
            }

            Console.WriteLine("While: ");
            int j = 0;
            while (j < 10)
            {
                Console.WriteLine("Hello");
                j++;
            }

 

            //    int n = int.Parse(Console.ReadLine());
            //    double evenSum = 0;
            //    double evenMax = double.MinValue;
            //    double evenMin = double.MaxValue;
            //    double oddSum = 0;
            //    double oddMax = double.MinValue;
            //    double oddMin = double.MaxValue;

            //    for (int i = 1; i <= n; i++)
            //    {
            //        double num = double.Parse(Console.ReadLine());
            //        if (i % 2 == 0)
            //        {
            //            evenSum += num;
            //            if (num > evenMax)
            //            {
            //                evenMax = num;
            //            }
            //            if (num < evenMin)
            //            {
            //                evenMin = num;
            //            }
            //        }
            //        else
            //        {
            //            oddSum += num;
            //            if (num > oddMax)
            //            {
            //                oddMax = num;
            //            }
            //            if (num < oddMin)
            //            {
            //                oddMin = num;
            //            }
            //        }
            //    }

            //    Console.WriteLine($"OddSum={oddSum:F2},");
            //    if (oddMin == double.MaxValue)
            //    {
            //        Console.WriteLine($"OddMin=No,");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"OddMin={oddMin:F2},");
            //    }
            //    if (oddMax == double.MinValue)
            //    {
            //        Console.WriteLine($"OddMax=No,");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"OddMax={oddMax:F2},");
            //    }
            //    Console.WriteLine($"EvenSum={evenSum:F2},");
            //    if (evenMin == double.MaxValue)
            //    {
            //        Console.WriteLine($"EvenMin=No,");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"EvenMin={evenMin:F2},");
            //    }
            //    if (evenMax == double.MinValue)
            //    {
            //        Console.WriteLine($"EvenMax=No");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"EvenMax={evenMax:F2}");
            //    }
            //}
        }
    }
}
