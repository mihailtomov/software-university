using System;
using System.Collections.Generic;
using System.Linq;

namespace Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();

                string[] splitted = command.Split();

                if (splitted[0] == "Add")
                {
                    string contact = splitted[1];
                    int index = int.Parse(splitted[2]);

                    if (!contacts.Contains(contact))
                    {
                        contacts.Add(contact);
                    }

                    else
                    {
                        if (index >= 0 && index < contacts.Count)
                        {
                            contacts.Insert(index, contact);
                        }
                    }
                }

                if (splitted[0] == "Remove")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }

                if (splitted[0] == "Export")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int count = int.Parse(splitted[2]);

                    if (startIndex + count < contacts.Count && startIndex != 0)
                    {
                        for (int i = startIndex; i <= count; i++)
                        {
                            Console.Write($"{contacts[i]} ");
                        }

                        Console.WriteLine();
                    }

                    else if (startIndex + count < contacts.Count && startIndex == 0)
                    {
                        for (int i = startIndex; i < count; i++)
                        {
                            Console.Write($"{contacts[i]} ");
                        }

                        Console.WriteLine();
                    }

                    else
                    {
                        for (int i = startIndex; i < contacts.Count; i++)
                        {
                            Console.Write($"{contacts[i]} ");
                        }

                        Console.WriteLine();
                    }
                }

                if (splitted[0] == "Print")
                {
                    if (splitted[1] == "Normal")
                    {
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                        return;
                    }

                    if (splitted[1] == "Reversed")
                    {
                        contacts.Reverse();
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                        return;
                    }
                }
            }
        }
    }
}
