using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> lastTextVersion = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    string someString = command[1];
                    text.Append(someString);
                    lastTextVersion.Push(text.ToString());
                }
                if (command[0] == "2")
                {
                    int count = int.Parse(command[1]);
                    text = text.Remove(text.Length - count, count);
                    lastTextVersion.Push(text.ToString());
                }
                if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);
                }
                if (command[0] == "4")
                {
                    if (lastTextVersion.Count > 1)
                    {
                        lastTextVersion.Pop();
                        StringBuilder oldText = new StringBuilder();
                        oldText.Append(lastTextVersion.Peek());
                        text = oldText;
                    }
                    else
                    {
                        text = new StringBuilder();
                    }
                }
            }
        }
    }
}
