using System.Collections.Generic;

namespace P07MilitaryElite
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
        void Add(Private item);
    }
}
