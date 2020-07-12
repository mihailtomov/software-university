using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string tireInfo;

            while ((tireInfo = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = tireInfo.Split();
                Tire[] temp = new Tire[4];
                int index = 0;

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);
                    var tire = new Tire(year, pressure);
                    temp[index] = tire;
                    index++;
                }

                tires.Add(temp);
            }

            string engineInfo;

            while ((engineInfo = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = engineInfo.Split();
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string carInfo;

            while ((carInfo = Console.ReadLine()) != "Show special")
            {
                string[] tokens = carInfo.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car car = 
                    new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            cars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.PressureSum(c.Tires) >= 9)
                .Where(c => c.PressureSum(c.Tires) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
