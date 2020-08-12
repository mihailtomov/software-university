namespace NeedForSpeed
{
    internal class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = 8;
            this.FuelConsumption = this.DefaultFuelConsumption;
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}