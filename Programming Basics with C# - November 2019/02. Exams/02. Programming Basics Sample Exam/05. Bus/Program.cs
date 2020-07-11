using System;

namespace _05._Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPassengersNum = int.Parse(Console.ReadLine());
            int busStopsCount = int.Parse(Console.ReadLine());

            int oddPassengersSum = 0;
            int evenPassengerSum = 0;

            for (int i = 1; i <= 2 * busStopsCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenPassengerSum += num;
                }

                else
                {
                    oddPassengersSum += num;
                }
            }

            int finalPassengerSum = startingPassengersNum + evenPassengerSum - oddPassengersSum;

            if (busStopsCount % 2 != 0)
            {
                finalPassengerSum += 2;
            }
            Console.WriteLine($"The final number of passengers is : {finalPassengerSum}");
        }
    }
}
