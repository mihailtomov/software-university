using System;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "copyMe.png";
            string zipPath = "../../../archive.zip";
            string extractPath = "../../../../";

            ZipArchive archiveFile = ZipFile.Open(zipPath, ZipArchiveMode.Create);

            using (archiveFile)
            {
                archiveFile.CreateEntryFromFile(file, file);
            }

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
