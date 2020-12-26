namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PersonCollectionSlow : IPersonCollection
    {
        // TODO: define the underlying data structures here ...

        List<Person> people = new List<Person>();

        public bool AddPerson(string email, string name, int age, string town)
        {
            var person = people.FirstOrDefault(p => p.Email == email);
            if (person == null)
            {
                people.Add(new Person()
                {
                    Email = email,
                    Name = name,
                    Age = age,
                    Town = town
                });
                
            }

            return person == null;
        }

        public int Count { get => people.Count; }
        public Person FindPerson(string email)
        {
            return people.FirstOrDefault(p => p.Email == email);
        }

        public bool DeletePerson(string email)
        {
            var person = people.FirstOrDefault(p => p.Email == email);
            if (person != null)
            {
                return people.Remove(person);
            }
            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            Regex matcher = new Regex($"@({emailDomain})(?!\\S)");
            return people.Where(p => matcher.IsMatch(p.Email)).OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            return people.Where(p => p.Name == name && p.Town == town).OrderBy(p => p.Email);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            return people.Where(p => startAge <= p.Age && p.Age <= endAge).OrderBy(p => p.Age).OrderBy(p => p, new PersonComparer());
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            return people.Where(p => startAge <= p.Age && p.Age <= endAge && p.Town == town).OrderBy(p => p, new PersonComparer());
        }
    }

    internal class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var comp = x.Age.CompareTo(y.Age);
            return comp == 0 ? x.Email.CompareTo(y.Email) : comp;
        }
    }
}
