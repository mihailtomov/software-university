namespace P07RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Engine = new Engine();
            this.Cargo = new Cargo();
            this.Tires = new Tire[4];

            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public bool PressureChecker(Tire[] tires)
        {
            tires = this.Tires;
            bool isBelowOne = false;

            foreach (var tire in tires)
            {
                if (tire.TirePressure < 1)
                {
                    isBelowOne = true;
                    break;
                }
            }

            return isBelowOne;
        }

        public override string ToString()
        {
            return $"{this.Model}".ToString();
        }
    }
}
