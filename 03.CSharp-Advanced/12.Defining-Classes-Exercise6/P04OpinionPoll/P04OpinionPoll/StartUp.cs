using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < count; i++)
            {
                string[] personData = Console.ReadLine().Split();
                string personName = personData[0];
                int personAge = int.Parse(personData[1]);
                Person person = new Person(personName, personAge);
                family.AddMember(person);
            }
            List<Person> filteredFamily = family.GetAgeMoreThan30();
            foreach (var member in filteredFamily)
            {
                Console.WriteLine(member);
            }
        }
    }
}
