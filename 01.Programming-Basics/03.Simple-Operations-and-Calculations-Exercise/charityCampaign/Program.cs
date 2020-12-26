using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int numberOfBakers = int.Parse(Console.ReadLine());
            int numberOfCakes = int.Parse(Console.ReadLine());
            int numberOfWaffels = int.Parse(Console.ReadLine());
            int numberOfPancakes = int.Parse(Console.ReadLine());
            double priceOfCakes = numberOfCakes * 45;
            double priceOfWaffels = numberOfWaffels * 5.80;
            double priceOfPancakes = numberOfPancakes * 3.20;
            double pricePerDay = (priceOfCakes + priceOfWaffels + priceOfPancakes) * numberOfBakers;
            double priceOfCampaign = pricePerDay * days;
            double priceAfterCosts = priceOfCampaign * 7 / 8.0;
            Console.WriteLine("{0:f2}", priceAfterCosts);
        }
    }
}
