using System.Collections.Generic;

namespace _01.DogVet
{
    public class Owner
    {
        public Owner(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Dogs = new Dictionary<string, Dog>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public Dictionary<string, Dog> Dogs { get; set; }

        public override bool Equals(object obj)
        {
            Owner other = (Owner)obj;
            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}