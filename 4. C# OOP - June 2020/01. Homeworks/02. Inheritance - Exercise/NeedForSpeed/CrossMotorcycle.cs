namespace NeedForSpeed
{
    internal class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel)
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