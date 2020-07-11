using System;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int currCounter = 1;
            int index = 0;

            for (int i = 0; i < text.Length - 1; i++)
            {
                char currChar = text[i];
                char nextChar = text[i + 1];

                if (currChar == nextChar)
                {
                    currCounter++;

                    if (currCounter == 2)
                    {
                        index = i;
                    }
                }

                else
                {
                    if (currCounter == 1)
                    {
                        continue;
                    }

                    else
                    {
                        text = text.Remove(index, currCounter - 1);
                        i = -1;
                    }

                    currCounter = 1;
                }

                if (i == text.Length - 2 && currCounter > 1)
                {
                    text = text.Remove(index, currCounter - 1);
                }
            }

            Console.WriteLine(text);
        }
    }
}
