using System.Text;

namespace P08CarSalesman
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }
        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, int displacement, string efficiency)
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");

            if (this.Displacement != 0)
            {
                sb.AppendLine($"    Displacement: {this.Displacement}");
            }
            else
            {
                sb.AppendLine($"    Displacement: n/a");
            }

            if (this.Efficiency != null)
            {
                sb.Append($"    Efficiency: {this.Efficiency}");
            }
            else
            {
                sb.Append($"    Efficiency: n/a");
            }

            return sb.ToString();
        }
    }
}