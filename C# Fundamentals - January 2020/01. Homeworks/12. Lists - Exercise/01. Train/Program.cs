using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonsList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCapacity = int.Parse(Console.ReadLine());


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] splitCommand = command.Split();

                if (splitCommand[0] == "Add")
                {
                    wagonsList.Add(int.Parse(splitCommand[1]));
                }

                else
                {
                    for (int i = 0; i < wagonsList.Count; i++)
                    {
                        if (maxCapacity - wagonsList[i] >= int.Parse(splitCommand[0]))
                        {
                            wagonsList[i] += int.Parse(splitCommand[0]);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagonsList));
        }
    }
}
