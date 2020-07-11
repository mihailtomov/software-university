using System;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] splitted = command.Split();

                if (splitted[0] == "Complete")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < tasks.Length)
                    {
                        tasks[index] = 0;
                    }
                }

                if (splitted[0] == "Change")
                {
                    int index = int.Parse(splitted[1]);
                    int time = int.Parse(splitted[2]);

                    if (index >= 0 && index < tasks.Length)
                    {
                        tasks[index] = time;
                    }
                }

                if (splitted[0] == "Drop")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < tasks.Length)
                    {
                        tasks[index] = -1;
                    }
                }

                if (splitted[1] == "Completed")
                {
                    int completedCount = 0;

                    for (int i = 0; i < tasks.Length; i++)
                    {
                        if (tasks[i] == 0)
                        {
                            completedCount++;
                        }
                    }

                    Console.WriteLine(completedCount);
                }

                if (splitted[1] == "Incomplete")
                {
                    int incompleteCount = 0;

                    for (int i = 0; i < tasks.Length; i++)
                    {
                        if (tasks[i] != 0 && tasks[i] > 0)
                        {
                            incompleteCount++;
                        }
                    }

                    Console.WriteLine(incompleteCount);
                }

                if (splitted[1] == "Dropped")
                {
                    int droppedCount = 0;

                    for (int i = 0; i < tasks.Length; i++)
                    {
                        if (tasks[i] < 0)
                        {
                            droppedCount++;
                        }
                    }

                    Console.WriteLine(droppedCount);
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] != 0 && tasks[i] > 0)
                {
                    Console.Write($"{tasks[i]} ");
                }
            }
        }
    }
}
