using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerExercise.Loggers
{
    public class LogFile : IFileLogger
    {
        private string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
        private readonly StringBuilder sb;

        public LogFile()
        {
            sb = new StringBuilder();
        }

        public int Size => sb.ToString().Where(char.IsLetter).Sum(c => c);

        public void Write(string message)
        {
            File.AppendAllText(FilePath, message);
            sb.Append(message);
        }
    }
}
