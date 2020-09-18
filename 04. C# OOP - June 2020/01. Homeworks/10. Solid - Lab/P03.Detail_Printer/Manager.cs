using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee, IManager
    {
        private List<string> documents;
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents => this.documents.AsReadOnly();

        public string Name { get; private set; }

        public void PrintEmployee()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }
    }
}
