using System.Collections.Generic;

namespace _02.FitGym
{
    public class Trainer
    {
        public Trainer(int id, string name, int popularity)
        {
            this.Id = id;
            this.Name = name;
            this.Popularity = popularity;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public HashSet<Member> Members { get; set; } = new HashSet<Member>();

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Trainer;
        //    if (other == null)
        //    {
        //        return false;
        //    }

        //    return this.Id == other.Id;
        //}

        //public override int GetHashCode()
        //{
        //    return this.Id;
        //}

        public override bool Equals(object obj)
        {
            Trainer other = (Trainer)obj;
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}