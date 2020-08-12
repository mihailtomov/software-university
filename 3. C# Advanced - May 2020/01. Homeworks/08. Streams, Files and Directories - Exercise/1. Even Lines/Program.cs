using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");

            string line;
            int counter = 0;

            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char currCh = line[i];

                    if (currCh == '-' || currCh == '.' || currCh == ',' || currCh == '!' ||currCh == '?')
                    {
                        line = line.Replace(currCh, '@');
                    }
                }

                string[] wordsReversed = line.Split().Reverse().ToArray();

                if (counter++ % 2 == 0)
                {
                    Console.WriteLine(string.Join(" ", wordsReversed));
                }
            }
        }
    }
}
