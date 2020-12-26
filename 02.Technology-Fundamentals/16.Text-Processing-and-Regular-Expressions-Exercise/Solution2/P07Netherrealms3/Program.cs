using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3___Nether_Realms
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim(' ');
            }

            foreach (var currentInput in input.OrderBy(a => a))
            {
                MatchCollection miniHealth = Regex.Matches(currentInput, @"[^0-9\+\-\*\/\.]");
                decimal health = 0;
                foreach (Match item in miniHealth)
                {
                    health += char.Parse(item.Value);
                }
                MatchCollection miniDamage = Regex.Matches(currentInput, @"(-)?([0-9]+)[.]?[0-9]*");
                decimal damage = 0;
                foreach (Match item in miniDamage)
                {
                    damage += decimal.Parse(item.Value);
                }
                MatchCollection pois = Regex.Matches(currentInput, @"\*");
                var unj = pois.Count;
                for (int i = 0; i < unj; i++)
                {
                    damage *= 2;
                }
                MatchCollection delt = Regex.Matches(currentInput, @"/");
                var del = delt.Count;
                for (int i = 0; i < del; i++)
                {
                    damage /= 2;
                }
                Console.WriteLine($"{currentInput} - {health} health, {damage:f2} damage ");
            }
        }
    }
}