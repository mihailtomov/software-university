using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Number> studentList = new List<Number>() {
                new Number() { NumberID = 1, num = int.Parse(Console.ReadLine()) } ,
                new Number() { NumberID = 2, num = int.Parse(Console.ReadLine()) } ,
                new Number() { NumberID = 3, num = int.Parse(Console.ReadLine()) } ,
            };

            var studentsInDescOrder = studentList.OrderByDescending(s => s.num);

            foreach (var std in studentsInDescOrder)
                Console.WriteLine(std.num);
        }
    }

    public class Number
    {
        public int NumberID { get; set; }
        public int num { get; set; }
    }
}