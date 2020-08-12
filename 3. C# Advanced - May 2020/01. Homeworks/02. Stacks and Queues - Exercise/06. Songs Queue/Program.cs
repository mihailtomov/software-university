using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(initialSongs);

            string command = Console.ReadLine();

            while (queue.Count != 0)
            {
                if (command.Contains("Play"))
                {
                    queue.Dequeue();
                }
                if (command.Contains("Add"))
                {
                    command = command.Remove(0, 4);
                    string songToAdd = command;

                    if (!queue.Contains(songToAdd))
                    {
                        queue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
                if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", queue));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
