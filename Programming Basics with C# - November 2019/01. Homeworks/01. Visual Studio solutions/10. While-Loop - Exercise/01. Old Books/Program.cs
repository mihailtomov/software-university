using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int libraryCapacity = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isBookFound = false;

            while (libraryCapacity > counter)
            {
                string currentBook = Console.ReadLine();

                if (currentBook == favouriteBook)
                {
                    isBookFound = true;
                    break;
                }
                counter++;
            }

            if (isBookFound)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}
