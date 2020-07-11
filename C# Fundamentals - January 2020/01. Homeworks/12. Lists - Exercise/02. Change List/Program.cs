using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numsList = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] splitCommand = command.Split();

                if (splitCommand[0] == "Delete")
                {
                    numsList.RemoveAll(item => item == int.Parse(splitCommand[1]));
                }

                if (splitCommand[0] == "Insert")
                {
                    numsList.Insert(int.Parse(splitCommand[2]), int.Parse(splitCommand[1]));
                }
            }

            Console.WriteLine(string.Join(" ", numsList));
        }
    }
}
