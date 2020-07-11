using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cars = new Dictionary<string, int[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split("|");

                string car = carData[0];
                int mileage = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);

                cars.Add(car, new int[2] {mileage, fuel});
            }

            string command;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splitArgs = command.Split(" : ");

                if (command.Contains("Drive"))
                {
                    string car = splitArgs[1];
                    int distance = int.Parse(splitArgs[2]);
                    int fuel = int.Parse(splitArgs[3]);

                    if (cars[car][1] >= fuel)
                    {
                        cars[car][0] += distance;
                        cars[car][1] -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }

                    if (cars[car][0] >= 100000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car}!");
                    }
                }

                if (command.Contains("Refuel"))
                {
                    string car = splitArgs[1];
                    int fuel = int.Parse(splitArgs[2]);

                    if (cars[car][1] + fuel > 75)
                    {
                        int fuelNeeded = 75 - cars[car][1];
                        cars[car][1] += fuelNeeded;
                        Console.WriteLine($"{car} refueled with {fuelNeeded} liters");
                    }
                    else
                    {
                        cars[car][1] += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                }

                if (command.Contains("Revert"))
                {
                    string car = splitArgs[1];
                    int kilometers = int.Parse(splitArgs[2]);

                    cars[car][0] -= kilometers;

                    if (cars[car][0] < 10000)
                    {
                        cars[car][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }                 
                }
            }

            cars = cars
                .OrderByDescending(kvp => kvp.Value[0])
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var car in cars)
            {
                string currCar = car.Key;
                int currMileage = car.Value[0];
                int currFuel = car.Value[1];

                Console.WriteLine($"{currCar} -> Mileage: {currMileage} kms, Fuel in the tank: {currFuel} lt.");
            }
        }
    }
}
