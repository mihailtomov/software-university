using System;

namespace _01._Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSouvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());

            double benzeneCostPerLiter = 1.85;
            double litersNeeded = 7 * (420 / 100 + 0.2);

            double distanceTotalCost = litersNeeded * benzeneCostPerLiter;

            double foodAndSouverirsTotalCost = 3 * (moneyForFood + moneyForSouvenirs);

            double firstDayInHotel = moneyForHotel * 0.9;
            double secondDayInHotel = moneyForHotel * 0.85;
            double thirdDayInHotel = moneyForHotel * 0.8;

            double hotelTotalCost = firstDayInHotel + secondDayInHotel + thirdDayInHotel;

            double totalTripCost = distanceTotalCost + foodAndSouverirsTotalCost + hotelTotalCost;

            Console.WriteLine($"Money needed: {totalTripCost:f2}");
        }
    }
}
