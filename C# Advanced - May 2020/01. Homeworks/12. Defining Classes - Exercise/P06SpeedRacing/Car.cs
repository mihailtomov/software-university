namespace P06SpeedRacing
{
    public class Car
    {
        public Car()
        {
            this.TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
            : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance{ get; set; }

        public void Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumptionPerKilometer * distance;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += distance;
            }
            else
            {
                System.Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}".ToString();
        }
    }
}
