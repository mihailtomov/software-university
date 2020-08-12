using System;
using System.Diagnostics.CodeAnalysis;

namespace P05GenericCountMethodString
{
    class Box<T> where T : IComparable
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo<T>([AllowNull] T other) where T : IComparable
        {
            if (this.value.CompareTo(other) > 0)
            {
                return 1;
            }
            else if (this.value.CompareTo(other) == 0)
            {
                return 0;
            }

            return -1;
        }

        public override string ToString()
        {
            return $"{this.value.GetType()}: {this.value}".ToString();
        }
    }
}
