using System.Collections.Generic;
using System.Text;

namespace P07MilitaryElite
{
    public class Commando : SpecialisedSoldier, IPrivate, ICommando
    {
        private List<Mission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Corps = corps;
            missions = new List<Mission>();
        }
        public decimal Salary { get; private set; }

        public IReadOnlyCollection<Mission> Missions { get => missions.AsReadOnly(); }

        public void Add(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (var item in missions)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
