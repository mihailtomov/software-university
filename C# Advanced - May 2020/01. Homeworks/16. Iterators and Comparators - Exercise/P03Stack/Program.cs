using System;

namespace P03Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> customStack = new CustomStack<string>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    string[] splitArgs = command.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < splitArgs.Length; i++)
                    {
                        customStack.Push(splitArgs[i]);
                    }
                }
                if (command.Contains("Pop"))
                {
                    customStack.Pop();
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
