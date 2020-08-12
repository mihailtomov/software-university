using P03.Detail_Printer;
using System;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void PrintEmployee()
        {
            Console.WriteLine(this.Name);
        }
    }
}
