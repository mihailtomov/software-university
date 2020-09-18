using System;
using System.Collections.Generic;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("text.txt");
            List<string> result = new List<string>();
            int counter = 1;

            for (int i = 0; i < text.Length; i++)
            {
                int lettersCount = 0;
                int punctuationMarksCount = 0;

                string line = text[i];

                for (int j = 0; j < line.Length; j++)
                {
                    char currCh = line[j];

                    if (Char.IsLetter(currCh))
                    {
                        lettersCount++;
                    }
                    else if (Char.IsPunctuation(currCh))
                    {
                        punctuationMarksCount++;
                    }
                }

                result.Add($"Line {counter++}: {line} ({lettersCount})({punctuationMarksCount})");
            }

            File.WriteAllLines("output.txt", result);
        }
    }
}
