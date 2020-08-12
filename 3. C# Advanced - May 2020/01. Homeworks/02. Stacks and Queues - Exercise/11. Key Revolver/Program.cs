using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksArr);
            Stack<int> bullets = new Stack<int>(bulletsArr);

            int bulletsFired = 0;

            while (locks.Any() && bullets.Any())
            {
                int currLock = locks.Peek();
                int currBullet = bullets.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    intelligenceValue -= pricePerBullet;
                    bulletsFired++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    intelligenceValue -= pricePerBullet;
                    bulletsFired++;
                }

                if (bulletsFired == sizeOfBarrel && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    bulletsFired = 0;
                }
            }

            if (!bullets.Any() && locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
        }
    }
}
