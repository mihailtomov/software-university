using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int array1Sum = 0;
            int indexDiff = 0;
            bool notIdentical = false;

            for (int i = 0; i < array1.Length; i++)
            {
                array1Sum += array1[i];
                if (array1[i] != array2[i])
                {
                    notIdentical = true;
                    indexDiff = i;
                    break;
                }
            }

            if (notIdentical)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {indexDiff} index");
            }

            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {array1Sum}");
            }
        }
    }
}
