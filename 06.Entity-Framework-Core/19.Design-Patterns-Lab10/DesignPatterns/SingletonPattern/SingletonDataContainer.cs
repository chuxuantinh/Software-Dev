using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SingletonPattern
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();
        private static SingletonDataContainer instance = new SingletonDataContainer();

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton oblect.");

            var elements = File.ReadAllLines("capitals.txt");

            for (int i = 0; i < elements.Length; i+= 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }


    }
}
