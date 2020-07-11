using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> diary = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split("->");
              
                if (splitArgs[0] != "Remove")
                {
                    if (!splitArgs[2].Contains(","))
                    {
                        string store = splitArgs[1];
                        string item = splitArgs[2];

                        if (!diary.ContainsKey(store))
                        {
                            diary[store] = new List<string>();
                            diary[store].Add(item);
                        }
                        else
                        {
                            diary[store].Add(item);
                        }
                    }
                    else
                    {
                        string store = splitArgs[1];
                        string itemsList = splitArgs[2];
                        string[] items = itemsList.Split(',');

                        if (!diary.ContainsKey(store))
                        {
                            diary[store] = new List<string>();

                            for (int i = 0; i < items.Length; i++)
                            {
                                string currItem = items[i];
                                diary[store].Add(currItem);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < items.Length; i++)
                            {
                                string currItem = items[i];
                                diary[store].Add(currItem);
                            }
                        }
                    }
                    
                }
           
                if (splitArgs[0] == "Remove")
                {
                    string store = splitArgs[1];

                    if (diary.ContainsKey(store))
                    {
                        diary.Remove(store);
                    }
                }
            }

            diary = diary
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenByDescending(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Stores list:");

            foreach (var store in diary)
            {
                string currStore = store.Key;
                List<string> items = store.Value;

                Console.WriteLine(currStore);

                foreach (var item in items)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
