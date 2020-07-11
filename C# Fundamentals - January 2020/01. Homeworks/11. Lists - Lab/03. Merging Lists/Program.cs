using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = Console.ReadLine().Split().ToList();
            List<string> list2 = Console.ReadLine().Split().ToList();

            List<string> result = new List<string>();
            MergingTheTwoLists(list1, list2, result);
        }

        private static void MergingTheTwoLists(List<string> list1, List<string> list2, List<string> result)
        {
            int smallerLength = 0;
            int biggerLength = 0;

            if (list1.Count <= list2.Count)
            {
                smallerLength = list1.Count;
                biggerLength = list2.Count;
            }

            else
            {
                smallerLength = list2.Count;
                biggerLength = list1.Count;
            }

            for (int i = 0; i < smallerLength; i++)
            {
                result.Add(list1[i]);
                result.Add(list2[i]);
            }

            for (int i = smallerLength; i < biggerLength; i++)
            {
                if (list1.Count > list2.Count)
                {
                    result.Add(list1[i]);
                }

                else
                {
                    result.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
