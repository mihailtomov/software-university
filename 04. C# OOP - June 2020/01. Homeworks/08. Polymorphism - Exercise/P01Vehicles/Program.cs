using System;

namespace P01Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            double busFuel = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            Vehicle car = new Car(carFuel, carConsumption, carCapacity);
            Vehicle truck = new Truck(truckFuel, truckConsumption, truckCapacity);
            Vehicle bus = new Bus(busFuel, busConsumption, busCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Drive")
                {
                    double distance = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        car.Drive(distance, true);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Drive(distance, true);
                    }
                    else
                    {
                        bus.Drive(distance, true);
                    }
                }
                else if (command[0] == "DriveEmpty")
                {
                    double distance = double.Parse(command[2]);
                    bus.Drive(distance, false);
                }
                else
                {
                    double liters = double.Parse(command[2]);

                    if (command[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                    else
                    {
                        bus.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
