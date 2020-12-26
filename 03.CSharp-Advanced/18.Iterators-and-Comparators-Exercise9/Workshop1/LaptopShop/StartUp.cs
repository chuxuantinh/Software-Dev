using System;

namespace LaptopShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string laptopMake = "ASUS";
            string laptopModel = "Rog";
            double laptopDisplaySize = 15.3;
            decimal laptopPrice = 333;
            int laptopRam = 32;
            int laptopSsd = 256;

            Laptop laptop = new Laptop(laptopMake, laptopModel, laptopDisplaySize, laptopPrice, laptopRam, laptopSsd);

            var laptopInfo = laptop.FullInfo();

            //Console.WriteLine(laptopInfo);

            var shop = new Shop();
            shop.AddLaptop(laptop);
            shop.PrintAllLaptops(x => Console.WriteLine(x.FullInfo()));

        }
    }
}
