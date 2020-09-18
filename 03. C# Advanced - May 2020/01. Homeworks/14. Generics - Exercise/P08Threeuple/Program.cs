using System;

namespace P08Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string firstName = firstLine[0];
            string lastName = firstLine[1];
            string address = firstLine[2];
            string townOne = firstLine[3];

            var result1 = new Threeuple<string, string, string>(firstName + " " + lastName, address, townOne);

            if (firstLine.Length == 4)
            {              
                Console.WriteLine(result1);
            }
            else
            {
                string townTwo = firstLine[4];
                result1.item3 = townOne + " " + townTwo;
                Console.WriteLine(result1);
            }

            string[] secondLine = Console.ReadLine().Split();
            string name = secondLine[0];
            int beer = int.Parse(secondLine[1]);
            string status = secondLine[2];
            bool ifDrunk = false;

            if (status == "drunk")
            {
                ifDrunk = true;
            }

            var result2 = new Threeuple<string, int, bool>(name, beer, ifDrunk);
            Console.WriteLine(result2);

            string[] thirdLine = Console.ReadLine().Split();
            string aName = thirdLine[0];
            double aBankBalance = double.Parse(thirdLine[1]);
            string aBankName = thirdLine[2];

            var result3 = new Threeuple<string, double, string>(aName, aBankBalance, aBankName);
            Console.WriteLine(result3);
        }
    }
}
