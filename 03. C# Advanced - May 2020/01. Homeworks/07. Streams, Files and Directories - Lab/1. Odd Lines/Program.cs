using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "Input.txt");
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                string line;
                int counter = 0;
                StreamWriter writer = new StreamWriter("Output.txt");

                using (writer)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                    }
                }
            }
        }
    }
}
