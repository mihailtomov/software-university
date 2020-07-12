using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public int Count => this.data.Count;
        public string Color { get; set; }
        public int Capacity { get; set; }

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = this.data.FirstOrDefault(x => x.Name == name);
            return this.data.Remove(present);
        }

        public Present GetHeaviestPresent()
        {
            Present present = this.data.OrderByDescending(x => x.Weight).First();
            return present;
        }

        public Present GetPresent(string name)
        {
            return this.data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
