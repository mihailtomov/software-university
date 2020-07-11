using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                int current = arr[i];
                bool isBigInteger = true;

                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (current <= arr[k])
                    {
                        isBigInteger = false;
                        break;
                    }
                }

                if (isBigInteger)
                {
                    result += current + " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}
