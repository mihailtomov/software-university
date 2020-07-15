using System;
using System.Linq;

namespace P01ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            var listyIterator = new ListyIterator<string>();

            string[] splitArgs = command.Split();

            if (splitArgs.Length > 1)
            {
                string[] inputList = new string[splitArgs.Length - 1];
                Array.Copy(splitArgs, 1, inputList, 0, splitArgs.Length - 1);

                listyIterator = new ListyIterator<string>(inputList.ToList());
            }

            while (command != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                if (command == "Print")
                {
                    listyIterator.Print();
                }
                if (command == "PrintAll")
                {
                    listyIterator.PrintAll();
                }

                command = Console.ReadLine();
            }
        }
    }
}
