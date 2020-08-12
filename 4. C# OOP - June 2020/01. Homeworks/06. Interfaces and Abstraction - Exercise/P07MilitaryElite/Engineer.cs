using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IPrivate, IEngineer
    {
        private List<Repair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            repairs = new List<Repair>();
        }

        public decimal Salary { get; private set; }

        public IReadOnlyCollection<Repair> Repairs { get => repairs.AsReadOnly(); }

        public void Add(Repair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in repairs)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
