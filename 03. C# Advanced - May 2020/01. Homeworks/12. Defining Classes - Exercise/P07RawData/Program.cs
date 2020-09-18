using System;
using System.Collections.Generic;
using System.Linq;

namespace P07RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                int index = 0;

                Tire[] tires = new Tire[4];

                for (int j = 5; j < input.Length; j += 2)
                {
                    double tirePressure = double.Parse(input[j]);
                    int tireAge = int.Parse(input[j + 1]);
                    tires[index] = new Tire(tirePressure, tireAge);
                    index++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.CargoType == "fragile")
                    .Where(c => c.PressureChecker(c.Tires) == true)
                    .ToList();

                PrintCars(cars);
            }
            else
            {
                cars = cars
                    .Where(c => c.Cargo.CargoType == "flamable")
                    .Where(c => c.Engine.EnginePower > 250)
                    .ToList();

                PrintCars(cars);
            }
        }

        static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
