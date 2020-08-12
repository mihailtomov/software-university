namespace NeedForSpeed
{
    internal class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel)
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