using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Console.ReadLine().Split('\\');

            string file = filePath[filePath.Length - 1];

            string[] fileComponents = file.Split('.');

            string fileName = fileComponents[0];
            string fileExtension = fileComponents[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
