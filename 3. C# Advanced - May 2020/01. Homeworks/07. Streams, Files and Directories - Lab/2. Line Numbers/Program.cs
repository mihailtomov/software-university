using System;
using System.IO;

namespace _2._Line_Numbers
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
                int counter = 1;
                StreamWriter writer = new StreamWriter("Output.txt");

                using (writer)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                    }
                }
            }
        }
    }
}
