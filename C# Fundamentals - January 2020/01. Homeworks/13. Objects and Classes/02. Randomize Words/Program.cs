using System;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string listOfWords = Console.ReadLine();

            string[] array = listOfWords.Split();

            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int nextIndex = rnd.Next(0, array.Length);
                string curr = array[i];
                array[i] = array[nextIndex];
                array[nextIndex] = curr;
            }

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
