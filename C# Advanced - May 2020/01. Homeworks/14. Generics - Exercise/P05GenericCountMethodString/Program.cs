using System;
using System.Collections.Generic;

namespace P05GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                Box<string> box = new Box<string>(element);
                list.Add(box);
            }

            string comparisonElement = Console.ReadLine();

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
