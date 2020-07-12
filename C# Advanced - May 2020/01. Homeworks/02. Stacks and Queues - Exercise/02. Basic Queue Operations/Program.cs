using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] threeNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numsToEnqueue = threeNums[0];
            int numsToDequeue = threeNums[1];
            int numToCheck = threeNums[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {
                if (queue.Contains(numToCheck))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
