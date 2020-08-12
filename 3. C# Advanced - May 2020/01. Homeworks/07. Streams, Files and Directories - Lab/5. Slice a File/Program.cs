using System;
using System.Collections.Generic;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Data", "sliceMe.txt");

            using (FileStream fileRead = new FileStream(filePath, FileMode.Open))
            {
                int parts = 4;
                List<string> outputFiles = new List<string> {"Part - 1.txt", "Part - 2.txt", "Part - 3.txt", "Part - 4.txt"};

                long pieceSize = (long)Math.Ceiling((double)fileRead.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;

                    using (FileStream fileCreate = new FileStream(outputFiles[i], FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];

                        while (fileRead.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            currentPieceSize += buffer.Length;
                            fileCreate.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
