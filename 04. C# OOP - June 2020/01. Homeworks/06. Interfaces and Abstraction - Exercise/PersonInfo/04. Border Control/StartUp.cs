using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identities = new List<IIdentifiable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();

                if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];
                    identities.Add(new Robot(model, id));
                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    identities.Add(new Citizen(name, age, id));
                }
            }

            string digits = Console.ReadLine();

            identities = identities.Where(x => x.Id.EndsWith(digits)).ToList();

            foreach (var identity in identities)
            {
                Console.WriteLine(identity.Id);
            }
        }
    }
}
