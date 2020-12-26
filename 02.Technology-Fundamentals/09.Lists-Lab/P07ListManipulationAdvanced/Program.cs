using System;
using System.Collections.Generic;
using System.Linq;

namespace P06ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> originalNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbers = originalNumbers;
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(tokens[1]);
                        numbers.RemoveAt(indexToRemove);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int indexToInsert = int.Parse(tokens[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;
                    case "Contains":
                        int searchedNumber = int.Parse(tokens[1]);
                        if (numbers.Contains(searchedNumber))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        int number = int.Parse(tokens[2]);
                        if (condition == ">")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x > number)));
                        }
                        else if (condition == ">=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x >= number)));
                        }
                        else if (condition == "<")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x < number)));
                        }
                        else if (condition == "<=")
                        {
                            Console.WriteLine(string.Join(" ", numbers.Where(x => x <= number)));
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            if (numbers != originalNumbers)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }
    }
}
