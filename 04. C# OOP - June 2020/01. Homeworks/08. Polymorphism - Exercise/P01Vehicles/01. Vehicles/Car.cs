namespace P01Vehicles
{
    public class Car : Vehicle
    {  
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 0.9;
        }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (FuelQuantity >= fuelNeeded)
            {
                System.Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
            else
            {
                System.Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
