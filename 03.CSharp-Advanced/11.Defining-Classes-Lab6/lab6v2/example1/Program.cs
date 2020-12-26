using System;

namespace P01Car
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car(10);
            Console.WriteLine($"My car is {myCar.Model}");
            myCar.Make = "Renault";
            myCar.Model = "Megan";
            Console.WriteLine($"My car is {myCar.Model}");
            Console.WriteLine($"My car age is {myCar.Year}");
            Console.WriteLine($"My car age is {myCar.RealAge()}");
            myCar.GetOld(5);
            Console.WriteLine($"My car age is {myCar.Year}");
        }
    }
}
