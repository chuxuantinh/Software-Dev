using System;
using System.Collections.Generic;
using System.Linq;

namespace P07OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);
                People people = new People(name, id, age);
                peoples.Add(people);
                input = Console.ReadLine();
            }
            List<People> orderedPeoples = peoples.OrderBy(p => p.Age).ToList();
            foreach (People people in orderedPeoples)
            {
                Console.WriteLine($"{people.Name} with ID: {people.ID} is {people.Age} years old.");
            }
        }
    }

    class People
    {
        public People(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age {get; set;}
    }
}
