using System;
using System.Linq;

namespace P07Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split();

            string[] personBeerInfo = Console.ReadLine()
                .Split();

            string[] numbersInfo = Console.ReadLine()
                .Split();

            string personName = string.Empty;
            string personAddress = string.Empty;
            string personTown = string.Empty;

            if (personInfo.Length == 4)
            {
                personName = personInfo[0] + " " + personInfo[1];
                personAddress = personInfo[2];
                personTown = personInfo[3];
            }
            else
            {
                personName = personInfo[0] + " " + personInfo[1];
                personAddress = personInfo[2];
                personTown = personInfo[3] + " " + personInfo[4];
            }
            

            string personBeerName = personBeerInfo[0];
            int amountOfBeer = int.Parse(personBeerInfo[1]);
            string personBeerDrunkOrNot = personBeerInfo[2];
            bool isDrunk = false;
            if (personBeerDrunkOrNot == "drunk")
            {
                isDrunk = true;
            }
            else if (personBeerDrunkOrNot == "not")
            {
                isDrunk = false;
            }

            string personBankName = numbersInfo[0];
            double personBankAccountBalance = double.Parse(numbersInfo[1]);
            string personBank = numbersInfo[2];

            Tuple<string, string, string> personTuple = new Tuple<string, string, string>(personName, personAddress, personTown);

            Tuple<string, int, bool> personBeerTuple = new Tuple<string, int, bool>(personBeerName, amountOfBeer, isDrunk);

            Tuple<string, double, string> bankTuple = new Tuple<string, double, string>(personBankName, personBankAccountBalance, personBank);

            Console.WriteLine(personTuple.GetInfo());
            Console.WriteLine(personBeerTuple.GetInfo());
            Console.WriteLine(bankTuple.GetInfo());
        }
    }
}
