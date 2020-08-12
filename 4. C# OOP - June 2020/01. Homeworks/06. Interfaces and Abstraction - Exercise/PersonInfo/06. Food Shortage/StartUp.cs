using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IPerson> buyers = new List<IPerson>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];
                    buyers.Add(new Rebel(name, age, group));
                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];
                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
            }

            string buyerName;

            while ((buyerName = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(x => x.Name == buyerName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
