using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bookShelf = Console.ReadLine().Split('&').ToList();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] splitted = command.Split(" | ");

                if (splitted[0] == "Add Book")
                {
                    string bookName = splitted[1];

                    if (!bookShelf.Contains(bookName))
                    {
                        bookShelf.Insert(0, bookName);
                    }
                }

                if (splitted[0] == "Take Book")
                {
                    string bookName = splitted[1];

                    if (bookShelf.Contains(bookName))
                    {
                        bookShelf.Remove(bookName);
                    }
                }

                if (splitted[0] == "Swap Books")
                {
                    string bookName1 = splitted[1];
                    string bookName2 = splitted[2];

                    if (bookShelf.Contains(bookName1) && bookShelf.Contains(bookName2))
                    {
                        int indexBook1 = bookShelf.IndexOf(bookName1);
                        int indexBook2 = bookShelf.IndexOf(bookName2);

                        string temp = bookShelf[indexBook1];
                        bookShelf[indexBook1] = bookShelf[indexBook2];
                        bookShelf[indexBook2] = temp;
                    }
                }

                if (splitted[0] == "Insert Book")
                {
                    string bookName = splitted[1];

                    bookShelf.Add(bookName);
                }

                if (splitted[0] == "Check Book")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < bookShelf.Count)
                    {
                        Console.WriteLine(bookShelf[index]);
                    }
                }

                    command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", bookShelf));
        }
    }
}
