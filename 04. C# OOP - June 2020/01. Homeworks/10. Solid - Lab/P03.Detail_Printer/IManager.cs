using System.Collections.Generic;

namespace P03.Detail_Printer
{
    public interface IManager
    {
        IReadOnlyCollection<string> Documents { get; }
    }
}
