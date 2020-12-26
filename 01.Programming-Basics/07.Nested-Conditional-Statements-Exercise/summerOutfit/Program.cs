using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int grades = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if (10 <= grades && grades <= 18)
            {
                if (day == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (day == "Afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (18 < grades && grades <= 24)
            {
                if (day == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (day == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (grades >= 25)
            {
                if (day == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (day == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (day == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            Console.WriteLine("It's {0} degrees, get your {1} and {2}.", grades, outfit, shoes);
        }
    }
}
