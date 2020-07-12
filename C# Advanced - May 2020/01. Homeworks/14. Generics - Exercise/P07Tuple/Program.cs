using System;

namespace P07Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string firstName = firstLine[0];
            string lastName = firstLine[1];
            string address = firstLine[2];

            var result1 = new P07Tuple.Tuple<string, string>(firstName + " " + lastName, address);
            Console.WriteLine(result1);

            string[] secondLine = Console.ReadLine().Split();
            string name = secondLine[0];
            int beer = int.Parse(secondLine[1]);

            var result2 = new P07Tuple.Tuple<string, int>(name, beer);
            Console.WriteLine(result2);

            string[] thirdLine = Console.ReadLine().Split();
            int anInteger = int.Parse(thirdLine[0]);
            double aDouble = double.Parse(thirdLine[1]);

            var result3 = new P07Tuple.Tuple<int, double>(anInteger, aDouble);
            Console.WriteLine(result3);
        }
    }
}
