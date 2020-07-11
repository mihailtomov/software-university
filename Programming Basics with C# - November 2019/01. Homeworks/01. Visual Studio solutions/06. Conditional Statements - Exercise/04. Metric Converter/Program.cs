using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string enter = Console.ReadLine();
            string exit = Console.ReadLine();

            double centimetersToMm = num * 10;
            double millimetersToM = num / 1000;
            double metersToCm = num * 100;

            double centimetersToM = num / 100;
            double millimetersToCm = num / 10;
            double metersToMm = num * 1000;

            if (enter == "mm" && exit == "m") 
            {
                Console.WriteLine("{0:F3}", millimetersToM);
            }

            else if (enter == "m" && exit == "cm")
            {
                Console.WriteLine("{0:F3}", metersToCm);
            }

            else if (enter == "cm" && exit == "mm")
            {
                Console.WriteLine("{0:F3}", centimetersToMm);
            }

            else if (enter == "cm" && exit == "m")
            {
                Console.WriteLine("{0:F3}", centimetersToM);
            }

            else if (enter == "mm" && exit == "cm")
            {
                Console.WriteLine("{0:F3}", millimetersToCm);
            }

            else if (enter == "m" && exit == "mm")
            {
                Console.WriteLine("{0:F3}", metersToMm);
            }
        }
    }
}
