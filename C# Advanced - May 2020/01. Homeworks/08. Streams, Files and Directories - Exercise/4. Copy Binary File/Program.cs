using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("output.png", FileMode.Create);

            byte[] buffer = new byte[4096];

            while (true)
            {
                int counter = reader.Read(buffer, 0, buffer.Length);

                if (counter == 0)
                {
                    break;
                }

                writer.Write(buffer);
            }
        }
    }
}
