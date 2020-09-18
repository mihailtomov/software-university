namespace P01Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;

            if (FuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual void Drive(double distance, bool airConditioner)
        {
            double fuelNeeded = distance * FuelConsumption;

            if (FuelQuantity >= fuelNeeded)
            {
                System.Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
            else
            {
                System.Console.WriteLine($"{this.GetType().Name} needs refueling");
            }

            if (this.GetType().Name == "Bus" && airConditioner == true)
            {
                FuelConsumption -= 1.4;
            }
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                System.Console.WriteLine("Fuel must be a positive number");
                return;
            }

            double availableSpace = TankCapacity - FuelQuantity;

            if (liters > availableSpace)
            {
                System.Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                if (this.GetType().Name == "Truck")
                {
                    FuelQuantity += 0.95 * liters;
                }
                else
                {
                    FuelQuantity += liters;
                }
            }
        }
    }
}
