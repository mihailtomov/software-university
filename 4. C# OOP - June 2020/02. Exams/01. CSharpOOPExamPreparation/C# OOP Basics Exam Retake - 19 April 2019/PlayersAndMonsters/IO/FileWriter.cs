using PlayersAndMonsters.IO.Contracts;
using System;
using System.IO;

namespace PlayersAndMonsters.IO
{
    public class FileWriter : IWriter
    {
        string path = @"..\..\..\output.txt";
        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            File.AppendAllText(path, message + Environment.NewLine);
        }
    }
}
