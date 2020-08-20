using RobotService.IO.Contracts;
using System;
using System.IO;

namespace RobotService.IO
{
    public class FileWriter : IWriter
    {
        private string filePath = @"..\..\..\output.txt";

        public void Write(string message)
        {
            File.AppendAllText(filePath, message);
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
