using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int commandsNumber = int.Parse(Console.ReadLine());
        ShoppingCenter center = new ShoppingCenter();

        for (int i = 0; i < commandsNumber; i++)
        {
            string line = Console.ReadLine();

            int firstSpace = line.IndexOf(" ");

            string command = line.Substring(0, firstSpace);
            string[] arguments = line.Substring(firstSpace + 1).Split(';');

            switch (command)
            {
                case "AddProduct":
                    string name = arguments[0];
                    decimal price = decimal.Parse(arguments[1]);
                    string producer = arguments[2];

                    Product p = new Product(name, price, producer);
                    center.Add(p);
                    Console.WriteLine("Product added");
                    break;
                case "DeleteProducts":
                    if (arguments.Length == 1)
                    {
                        int count = center.DeleteProductsByProducer(arguments[0]);
                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count.ToString() + " products deleted");
                        }
                    }
                    else
                    {
                        int count = center.DeleteProductsByProducerAndName(arguments[0], arguments[1]);
                        if (count == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine(count.ToString() + " products deleted");
                        }
                    }
                    break;
                case "FindProductsByName":
                    List<Product> result = center.FindProductsByName(arguments[0]).ToList();
                    if (result.Count != 0)
                    {
                        Console.WriteLine(string.Join("\n", result));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
                case "FindProductsByProducer":
                    List<Product> result2 = center.FindProductsByProducer(arguments[0]).ToList();
                    if (result2.Count != 0)
                    {
                        Console.WriteLine(string.Join("\n", result2));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
                case "FindProductsByPriceRange":
                    IEnumerable<Product> result3 = center.FindProductsByPriceRange(decimal.Parse(arguments[0]), decimal.Parse(arguments[1])).OrderBy(x => x);
                    if (result3.Any())
                    {
                        Console.WriteLine(string.Join("\n", result3));
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                    break;
            }
        }

        
    }
}

