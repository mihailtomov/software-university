namespace P01Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base (fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }
    }
}
