namespace Collection_of_Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollection : IPersonCollection
    {
        // TODO: define the underlying data structures here ...
        private Dictionary<string, Person> byEmail = new Dictionary<string, Person>();
        private Dictionary<string, SortedSet<Person>> byEmailDomain = new Dictionary<string, SortedSet<Person>>();
        private Dictionary<string, SortedSet<Person>> byNameTown = new Dictionary<string, SortedSet<Person>>();
        private SortedDictionary<int, Dictionary<string, SortedSet<Person>>> byAgeTown = new SortedDictionary<int, Dictionary<string, SortedSet<Person>>>();

        public bool AddPerson(string email, string name, int age, string town)
        {
            var p = FindPerson(email);
            if (p != null)
            {
                return false;
            }
            var person = new Person()
            {
                Email = email,
                Age = age,
                Name = name,
                Town = town
            };

            byEmail[email] = person;

            var emailDomain = email.Split('@')[1];
            byEmailDomain.AppendValueToKey(emailDomain, person);

            var nameTown = GetNameTown(person);
            byNameTown.AppendValueToKey(nameTown, person);

            byAgeTown.EnsureKeyExists(age);
            byAgeTown[age].AppendValueToKey(town, person);

            return true;
        }

        private string GetNameTown(Person person)
        {
            return GetNameTown(person.Name, person.Town);
        }

        private string GetNameTown(string name, string town)
        {
            return $"{name}_{town}";
        }

        public int Count { get => byEmail.Count; }
        public Person FindPerson(string email)
        {
            if (byEmail.ContainsKey(email))
            {
                return byEmail[email];
            }
            return null;
        }

        public bool DeletePerson(string email)
        {
            var person = FindPerson(email);
            if (person != null)
            {
                var age = person.Age;
                var town = person.Town;

                var emailDomain = email.Split('@')[1];
                byEmailDomain[emailDomain].Remove(person);
                byEmailDomain.CleanupValueForKey(emailDomain);

                var nameTown = GetNameTown(person);
                byNameTown[nameTown].Remove(person);
                byNameTown.CleanupValueForKey(nameTown);

                byAgeTown[age][town].Remove(person);
                byAgeTown[age].CleanupValueForKey(town);
                byAgeTown.CleanupValueForKey(age);

                byEmail.Remove(email);
                return true;
            }

            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            return byEmailDomain.GetValuesForKey(emailDomain);
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var key = GetNameTown(name, town);
            return byNameTown.GetValuesForKey(key);
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            SortedSet<int> ages = new SortedSet<int>(byAgeTown.Keys);
            var resultKeys = ages.GetViewBetween(startAge, endAge);
            return resultKeys.SelectMany(k => byAgeTown[k].Values.SelectMany(v => v).OrderBy(p => p.Email));
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
        {
            SortedSet<int> ages = new SortedSet<int>(byAgeTown.Keys);
            var resultKeys = ages.GetViewBetween(startAge, endAge);
            return resultKeys.SelectMany(k => byAgeTown[k].GetValuesForKey(town).OrderBy(p => p.Email));
        }
    }
}
