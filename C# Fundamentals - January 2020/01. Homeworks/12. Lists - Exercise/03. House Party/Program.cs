using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string message = Console.ReadLine();

                string[] splitMessage = message.Split();

                if (splitMessage[2] == "going!")
                {
                    bool isInTheList = false;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] == splitMessage[0])
                        {
                            isInTheList = true;
                            break;
                        }
                    }

                    if (isInTheList == false)
                    {
                        list.Add(splitMessage[0]);
                    }

                    else
                    {
                        Console.WriteLine($"{splitMessage[0]} is already in the list!");
                    }
                }

                if (splitMessage[2] == "not")
                {
                    bool isNotInList = false;

                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j] == splitMessage[0])
                        {
                            list.Remove(splitMessage[0]);
                            break;
                        }

                        if (j == list.Count - 1 && list[j] != splitMessage[0])
                        {
                            isNotInList = true;
                        }
                    }

                    if (isNotInList || list.Count == 0)
                    {
                        Console.WriteLine($"{splitMessage[0]} is not in the list!");
                    }
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
