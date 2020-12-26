using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers = new List<Person>();
        }

        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = familyMembers.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestPerson;
        }

        public List<Person> GetAgeMoreThan30()
        {
            return familyMembers.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        }
    }
}
