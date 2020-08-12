using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var employee = new Employee("Pesho");
            var manager = new Manager("Gosho", new string[] { "doc1", "doc2", "doc3" });

            var detailsPrinter = new DetailsPrinter(new List<IEmployee>() { employee, manager });
            detailsPrinter.PrintDetails();
        }
    }
}
