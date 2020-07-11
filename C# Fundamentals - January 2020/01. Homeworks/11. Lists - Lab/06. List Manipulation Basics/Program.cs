using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            string[] splitCommand = command.Split();
            ListAfterApplyingCommands(integers, ref command, ref splitCommand);
        }

        private static void ListAfterApplyingCommands(List<int> integers, ref string command, ref string[] splitCommand)
        {
            while (command != "end")
            {
                splitCommand = command.Split();

                if (splitCommand[0] == "Add")
                {
                    integers.Add(int.Parse(splitCommand[1]));
                }

                if (splitCommand[0] == "Remove")
                {
                    integers.Remove(int.Parse(splitCommand[1]));
                }

                if (splitCommand[0] == "RemoveAt")
                {
                    integers.RemoveAt(int.Parse(splitCommand[1]));
                }

                if (splitCommand[0] == "Insert")
                {
                    integers.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
