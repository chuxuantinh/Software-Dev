namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        List<Computer> computers = new List<Computer>();
        Dictionary<int, Computer> byNumber = new Dictionary<int, Computer>();
        Dictionary<Brand, HashSet<Computer>> byBrand = new Dictionary<Brand, HashSet<Computer>>();
        Dictionary<string, HashSet<Computer>> byColor = new Dictionary<string, HashSet<Computer>>();

        public void CreateComputer(Computer computer)
        {
            if (byNumber.ContainsKey(computer.Number))
            {
                throw new ArgumentException(); 
            }
            byNumber[computer.Number] = computer;

            if (!byBrand.ContainsKey(computer.Brand))
            {
                byBrand[computer.Brand] = new HashSet<Computer>();
            }

            byBrand[computer.Brand].Add(computer);

            if (!byColor.ContainsKey(computer.Color))
            {
                byColor[computer.Color] = new HashSet<Computer>();
            }

            byColor[computer.Color].Add(computer);

            computers.Add(computer);
        }

        public bool Contains(int number)
        {
            return byNumber.ContainsKey(number);
        }

        public int Count()
        {
            return computers.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            return byNumber[number];
        }

        public void Remove(int number)
        {
            if (!byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            var computerForRemoval = byNumber[number];

            computers.Remove(computerForRemoval);
            byNumber.Remove(number);
            byBrand[computerForRemoval.Brand].Remove(computerForRemoval);
            if (byBrand[computerForRemoval.Brand].Count == 0)
            {
                byBrand.Remove(computerForRemoval.Brand);
            }
            byColor[computerForRemoval.Color].Remove(computerForRemoval);
            if (byColor[computerForRemoval.Color].Count == 0)
            {
                byColor.Remove(computerForRemoval.Color);
            }
        }

        public void RemoveWithBrand(Brand brand)
        {
            if(!byBrand.ContainsKey(brand))
            {
                throw new ArgumentException();
            }

            var computerForRemove = byBrand[brand].Select(computers => computers.Number).ToList();
            foreach (var number in computerForRemove)
            {
                Remove(number);
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            var computerForUpgrade = GetComputer(number);
            computerForUpgrade.RAM = computerForUpgrade.RAM < ram ? ram : computerForUpgrade.RAM;
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            if (!byBrand.ContainsKey(brand))
            {
                return Enumerable.Empty<Computer>();
            }

            return byBrand[brand].OrderByDescending(c => c.Price);

        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            return computers.Where(c => c.ScreenSize == screenSize).OrderByDescending(c => c.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            if (!byColor.ContainsKey(color))
            {
                return Enumerable.Empty<Computer>();
            }

            return byColor[color].OrderByDescending(c => c.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            return computers.Where(c => minPrice <= c.Price && c.Price <= maxPrice).OrderByDescending(c => c.Price);
        }
    }
}
