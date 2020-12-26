using System;
using System.Collections.Generic;
using System.Linq;

namespace P02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Delete")
                {
                    int numberToDelete = int.Parse(tokens[1]);
                    numbers.Remove(numberToDelete);
                }
                else if (tokens[0] == "Insert")
                {
                    int elementToInsert = int.Parse(tokens[1]);
                    int indexToInsert = int.Parse(tokens[2]);
                    numbers.Insert(indexToInsert, elementToInsert);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
