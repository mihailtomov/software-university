namespace P01Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            : base (fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 1.6;
        }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (FuelQuantity >= fuelNeeded)
            {
                System.Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
            else
            {
                System.Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += 0.95 * liters;
        }
    }
}
