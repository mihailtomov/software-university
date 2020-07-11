using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Go Shopping!")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitted[0] == "Urgent")
                {
                    string item = splitted[1];

                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }

                if (splitted[0] == "Unnecessary")
                {
                    string item = splitted[1];

                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }

                if (splitted[0] == "Correct")
                {
                    string oldItem = splitted[1];
                    string newItem = splitted[2];

                    if (groceries.Contains(oldItem))
                    {
                        int indexOfItem = groceries.IndexOf(oldItem);
                        groceries[indexOfItem] = newItem;
                    }

                }
                if (splitted[0] == "Rearrange")
                {
                    string item = splitted[1];

                    if (groceries.Contains(item))
                    {
                        int indexOfItem = groceries.IndexOf(item);
                        groceries.RemoveAt(indexOfItem);
                        groceries.Add(item);
                    }
                }
                    command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
