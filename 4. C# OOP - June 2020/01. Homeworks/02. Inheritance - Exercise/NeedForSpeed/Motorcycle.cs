namespace NeedForSpeed
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.FuelConsumption = this.DefaultFuelConsumption;
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}