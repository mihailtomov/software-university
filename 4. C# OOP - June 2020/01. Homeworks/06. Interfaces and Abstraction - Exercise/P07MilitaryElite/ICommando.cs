using System.Collections.Generic;

namespace P07MilitaryElite
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
        void Add(Mission mission);
    }
}
