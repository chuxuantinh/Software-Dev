using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> salads;

        public Restaurant(string name)
        {
            Name = name;
            salads = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            salads.Add(salad);
        }

        public bool Buy(string name)
        {
            bool isPresent = false;
            foreach (var salad in salads)
            {
                if (salad.Name.Contains(name))
                {
                    isPresent = true;
                    salads.Remove(salad);
                    break;
                }
            }
            return isPresent;
            
        }

        public string GetHealthiestSalad()
        {
            var healtiestSalad = salads.OrderByDescending(s => s.GetTotalCalories()).First();
            return healtiestSalad.Name;
        }

        public string GenerateMenu()
        {
            string sb = string.Empty;
            sb += $"{Name} have {salads.Count} salads:";
            foreach (var salad in salads)
            {
                sb += Environment.NewLine + salad.ToString() ;
            }
            sb.TrimEnd();
            return sb;
        }
    }
}
