using CounterStrike.IO.Contracts;
using System;
using System.IO;

namespace CounterStrike.IO
{
    public class FileWriter : IWriter
    {
        string filePath = @"..\..\..\output.txt";
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
