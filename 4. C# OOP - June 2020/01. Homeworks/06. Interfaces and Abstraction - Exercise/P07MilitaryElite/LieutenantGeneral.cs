using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class LieutenantGeneral : Soldier, IPrivate, ILieutenantGeneral
    {
        private List<Private> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            privates = new List<Private>();
        }
        public decimal Salary { get; private set; }

        public IReadOnlyCollection<Private> Privates { get => privates.AsReadOnly(); }

        public void Add(Private item)
        {
            privates.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var item in privates)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
