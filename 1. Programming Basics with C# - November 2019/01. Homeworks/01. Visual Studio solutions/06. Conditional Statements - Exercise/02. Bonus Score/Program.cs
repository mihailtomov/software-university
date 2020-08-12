using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            double bonus = 0.0;

            if (startingNum <= 100)
            {
                bonus = 5;               
            }

            else if (startingNum > 1000)
            {
                bonus = 0.1 * startingNum;               
            }

            else 
            {
                bonus = 0.2 * startingNum;               
            }        

            if (startingNum % 2 == 0)
            {
                bonus = bonus + 1;               
            }

            else if (startingNum % 10 == 5)
            {
                bonus = bonus + 2;               
            }

            Console.WriteLine(bonus);
            Console.WriteLine(bonus + startingNum);
        }
    }
}
