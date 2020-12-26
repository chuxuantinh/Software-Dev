using System;

namespace ProtptypePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            sandwichMenu["LoadedBLT"] = new Sandwich("", "", "", "");

            Sandwich bltSandwich = sandwichMenu["BLT"].Clone() as Sandwich;
        }
    }
}
