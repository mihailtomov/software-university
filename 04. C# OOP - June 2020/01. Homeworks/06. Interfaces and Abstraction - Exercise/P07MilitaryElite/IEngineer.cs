using System.Collections.Generic;

namespace P07MilitaryElite
{
    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
        void Add(Repair repair);
    }
}
