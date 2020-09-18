using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] pumpData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pumpData);
            }

            int index = 0;
            int totalAmount = 0;
            int counter = 0;

            while (counter != numberOfPumps)
            {
                int currAmount = queue.Peek()[0];
                int currDistance = queue.Peek()[1];

                totalAmount += currAmount;

                if (totalAmount >= currDistance)
                {
                    totalAmount -= currDistance;
                    queue.Enqueue(queue.Dequeue());
                    counter++;
                }
                else
                {
                    index++;
                    totalAmount = 0;
                    for (int i = 0; i < numberOfPumps - counter + 1; i++)
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                    counter = 0;
                }
            }

            Console.WriteLine(index);
        }
    }
}
