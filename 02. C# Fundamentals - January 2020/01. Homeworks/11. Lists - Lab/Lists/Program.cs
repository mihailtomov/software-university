using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(6);
            list.Add(-51);
            list.Add(33);

            list.Remove(6);
            list.RemoveAt(1);

            Console.WriteLine(list[2]);
            Console.WriteLine(list.Count);
        }
    }
}
