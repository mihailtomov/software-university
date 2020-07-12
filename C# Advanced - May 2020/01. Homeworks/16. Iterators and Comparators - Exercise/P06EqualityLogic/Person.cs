using System;
using System.Diagnostics.CodeAnalysis;

namespace P06EqualityLogic
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0 && this.Age.CompareTo(other.Age) == 0)
            {
                return 0;
            }
            if (this.Name.CompareTo(other.Name) == -1)
            {
                return 1;
            }
            return -1;
        }

        public bool Equals(Person other)
        {
            return other != null &&
                   Name == other.Name &&
                   Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }
    }
}
