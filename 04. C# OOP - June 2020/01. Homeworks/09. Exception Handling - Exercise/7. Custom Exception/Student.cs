using System.Linq;

namespace _7._Custom_Exception
{
    public class Student
    {
        private string name;
        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (value.Any(ch => !char.IsLetter(ch)))
                {
                    throw new InvalidPersonNameException("A student name cannot contain special characters or numeric values.");
                }
                this.name = value;
            }
        }
        public string Email { get; private set; }
    }
}
