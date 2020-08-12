using System;
using System.Collections.Generic;

namespace P06GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> list = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(element);
                list.Add(box);
            }

            double comparisonElement = double.Parse(Console.ReadLine());

            Console.WriteLine(GetGreaterValuesCount(list, comparisonElement));
        }

        static int GetGreaterValuesCount<T>(List<Box<T>> list, T element) where T : IComparable
        {
            int count = 0;

            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
