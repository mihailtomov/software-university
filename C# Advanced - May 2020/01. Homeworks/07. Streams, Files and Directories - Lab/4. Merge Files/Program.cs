using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathOne = Path.Combine("Data", "FileOne.txt");
            string pathTwo = Path.Combine("Data", "FileTwo.txt");

            using FileStream fileOne = new FileStream(pathOne, FileMode.Open);
            using FileStream fileTwo = new FileStream(pathTwo, FileMode.Open);

            using StreamReader fileOneReader = new StreamReader(fileOne);
            using StreamReader fileTwoReader = new StreamReader(fileTwo);

            using StreamWriter output = new StreamWriter("Output.txt");

            string lineOne = fileOneReader.ReadLine();
            string lineTwo = fileTwoReader.ReadLine();

            while (lineOne != null && lineTwo != null)
            {
                output.WriteLine(lineOne);
                output.WriteLine(lineTwo);

                lineOne = fileOneReader.ReadLine();
                lineTwo = fileTwoReader.ReadLine();
            }
        }
    }
}
