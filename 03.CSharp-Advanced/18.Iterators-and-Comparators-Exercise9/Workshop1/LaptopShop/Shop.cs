using System;
using System.Collections.Generic;
using System.Text;

namespace LaptopShop
{
    public class Shop
    {
        private Dictionary<string, List<Laptop>> laptops;

        public Shop()
        {
            laptops = new Dictionary<string, List<Laptop>>();
        }

        public int Count => laptops.Count;

        public void AddLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptops.ContainsKey(laptop.Make))
            {
                laptops.Add(laptop.Make, new List<Laptop>());
            }

            laptops[laptop.Make].Add(laptop);
        }

        public bool RemoveLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptops.ContainsKey(laptop.Make))
            {
                return false;
            }

            if (!laptops[laptop.Make].Contains(laptop))
            {
                return false;
            }

            bool isRemove = laptops[laptop.Make].Remove(laptop);

            if (laptops[laptop.Make].Count == 0)
            {
                isRemove = laptops.Remove(laptop.Make);
            }

            return isRemove;
        }

        public void PrintAllLaptops(Action<Laptop> action)
        {
            foreach (var (make, dictLaptops) in laptops)
            {
                foreach (var laptop in dictLaptops)
                {
                    action(laptop);
                }
            }
        }

        public bool ContainsLaptop(Laptop laptop)
        {
            IfNullThrowException(laptop);

            if (!laptops.ContainsKey(laptop.Make))
            {
                return false;
            }

            if (!laptops[laptop.Make].Contains(laptop))
            {
                return false;
            }

            return true;
        }

        private void IfNullThrowException(Laptop laptop)
        {
            if (laptop == null)
            {
                throw new ArgumentNullException(nameof(laptop), "Object cannot be null");
            }
        }
    }
}
