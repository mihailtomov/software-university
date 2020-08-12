using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./";
            string givenExtension = ".";

            string[] files = Directory.GetFiles(path, $"*{givenExtension}*");

            SortedDictionary<string, Dictionary<string, double>> info = 
                new SortedDictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            { 
                FileInfo fileInfo = new FileInfo(file);
                string fileName = fileInfo.Name;
                string fileExtension = fileInfo.Extension;
                double fileSize = fileInfo.Length / 1024.0;

                if (!info.ContainsKey(fileExtension))
                {
                    info[fileExtension] = new Dictionary<string, double>();
                    info[fileExtension][fileName] = fileSize;
                }
                else
                {
                    info[fileExtension][fileName] = fileSize;
                }
            }

            var filtered = info
                .OrderByDescending(kvp => kvp.Value.Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            StringBuilder result = new StringBuilder();

            foreach (var kvp in filtered)
            {
                string extension = kvp.Key;
                Dictionary<string, double> fileInfo = kvp.Value;

                result.AppendLine(extension);

                fileInfo = fileInfo
                    .OrderBy(kvp => kvp.Value)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var file in fileInfo)
                {
                    string fileName = file.Key;
                    double fileSize = file.Value;

                    result.AppendLine($"{fileName} - {fileSize:f3}kb");
                }
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string resultPath = Path.Combine(desktopPath, "report.txt");
            File.WriteAllText(resultPath, result.ToString());
        }
    }
}
