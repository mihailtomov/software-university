using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> predicate = (name, num) =>
            {
                int sum = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                if (sum >= num)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            foreach (var name in names)
            {
                if (predicate(name, n))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
