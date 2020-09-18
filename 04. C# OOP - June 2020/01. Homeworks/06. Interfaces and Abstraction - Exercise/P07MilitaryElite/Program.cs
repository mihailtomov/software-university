using System;
using System.Collections.Generic;
using System.Linq;

namespace P07MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Private> privates = new List<Private>();
            List<Soldier> soldiers = new List<Soldier>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Private")
                {
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    var privateObj = new Private(id, firstName, lastName, salary);
                    privates.Add(privateObj);
                    soldiers.Add(privateObj);
                }
                if (data[0] == "LieutenantGeneral")
                {
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];
                        lieutenantGeneral.Add(privates.First(x => x.Id == privateId));
                    }

                    soldiers.Add(lieutenantGeneral);
                }
                if (data[0] == "Engineer")
                {
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }

                    var engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string partName = data[i];
                        int hoursWorked = int.Parse(data[i + 1]);
                        engineer.Add(new Repair(partName, hoursWorked));
                    }

                    soldiers.Add(engineer);
                }
                if (data[0] == "Commando")
                {
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }

                    var commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string codeName = data[i];
                        string state = data[i + 1];

                        if (state != "inProgress" && state != "Finished")
                        {
                            continue;
                        }
                        commando.Add(new Mission(codeName, state));
                    }

                    soldiers.Add(commando);
                }
                if (data[0] == "Spy")
                {
                    string id = data[1];
                    string firstName = data[2];
                    string lastName = data[3];
                    int codeNumber = int.Parse(data[4]);
                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
