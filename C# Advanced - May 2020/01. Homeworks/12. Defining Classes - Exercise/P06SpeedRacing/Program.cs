using System;
using System.Collections.Generic;

namespace P06SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                if (!cars.ContainsKey(model))
                {
                    cars[model] = new Car();
                    cars[model] = car;
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                string carModel = tokens[1];
                double amountOfKm = double.Parse(tokens[2]);

                cars[carModel].Drive(amountOfKm);
            }

            foreach (var kvp in cars)
            {
                Car car = kvp.Value;
                Console.WriteLine(car);
            }
        }
    }
}
