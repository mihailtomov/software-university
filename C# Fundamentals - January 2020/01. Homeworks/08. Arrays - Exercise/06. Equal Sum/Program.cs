using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isEqualSum = false;

            for (int curr = 0; curr < array.Length; curr++)
            {
                int rightSum = 0;

                for (int i = curr + 1; i < array.Length; i++)
                {
                    rightSum += array[i];
                }

                int leftsum = 0;

                for (int i = curr - 1; i >= 0; i--)
                {
                    leftsum += array[i];
                }


                if (rightSum == leftsum)
                {
                    Console.WriteLine(curr);
                    isEqualSum = true;
                }
            }

            if (isEqualSum == false)
            {
                Console.WriteLine("no");
            }
        }
    }
}
