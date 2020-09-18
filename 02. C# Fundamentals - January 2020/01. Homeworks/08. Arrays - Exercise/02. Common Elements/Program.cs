using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();

            string result = "";
            foreach (var word1 in array2)
            {
                foreach (var word2 in array1)
                {
                    if (word1 == word2)
                    {
                        result += word1 + " ";
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
