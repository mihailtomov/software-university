using System;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Action<int> printNum = num => Console.Write($"{num} ");
            Func<int, int[], bool> ifDisibleByDividers = (num, arr) =>
            {
                bool isDivisible = false;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (num % arr[i] == 0)
                    {
                        isDivisible = true;
                    }
                    else
                    {
                        isDivisible = false;
                        break;
                    }
                }

                return isDivisible;
            };

            for (int i = 1; i <= endOfRange; i++)
            {
                int number = i;

                if (ifDisibleByDividers(number, dividers))
                {
                    printNum(number);
                }
            }
        }
    }
}
