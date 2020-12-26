namespace P11KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackOfBullets = new Stack<int>(bullets);
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueOfLocks = new Queue<int>(locks);
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int bulletsCounter = 0;
            while (stackOfBullets.Count > 0 && queueOfLocks.Count > 0)
            {
                int currentBulletSize = stackOfBullets.Pop();
                bulletsCounter++;
                int currentLockSize = queueOfLocks.Peek();
                if (currentBulletSize <= currentLockSize)
                {
                    Console.WriteLine("Bang!");
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");    
                }
                if (bulletsCounter % sizeOfGunBarrel == 0 && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (queueOfLocks.Count == 0 && stackOfBullets.Count == 0)
            {
                Console.WriteLine($"0 bullets left. Earned ${valueOfIntelligence - bulletsCounter * priceOfBullet}");
            }
            else if (queueOfLocks.Count == 0)
            {
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${valueOfIntelligence - bulletsCounter * priceOfBullet}");
            }
            else if (stackOfBullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
