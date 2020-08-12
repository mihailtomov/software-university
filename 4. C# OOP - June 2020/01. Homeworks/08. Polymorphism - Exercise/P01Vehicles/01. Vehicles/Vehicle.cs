namespace P01Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
