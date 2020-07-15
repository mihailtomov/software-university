using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            if (x.Year == y.Year)
            {
                return x.Title.CompareTo(y.Title);
            }

            return y.Year.CompareTo(x.Year);
        }
    }
}
