using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> entities = new List<IBirthable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split();
                string type = data[0];

                if (type == "Robot")
                {
                    continue;
                }
                if (type == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];
                    entities.Add(new Citizen(name, age, id, birthdate));
                }
                if (type == "Pet")
                {
                    string name = data[1];
                    string birthdate = data[2];
                    entities.Add(new Pet(name, birthdate));
                }
            }

            string year = Console.ReadLine();

            entities = entities.Where(x => x.Birthdate.EndsWith(year)).ToList();

            foreach (var entity in entities)
            {
                Console.WriteLine(entity.Birthdate);
            }
        }
    }
}
