namespace P01Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override void Drive(double distance, bool airConditioner)
        {
            if (airConditioner == true)
            {
                FuelConsumption += 1.4;
            }

            base.Drive(distance, airConditioner);
        }
    }
}
