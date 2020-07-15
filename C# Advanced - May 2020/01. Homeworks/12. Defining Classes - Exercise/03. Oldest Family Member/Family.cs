using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = new Person("No name", -1);

            foreach (var person in this.people)
            {
                if (person.Age > oldestPerson.Age)
                {
                    oldestPerson = person;
                }
            }

            return oldestPerson;
        }
    }
}
