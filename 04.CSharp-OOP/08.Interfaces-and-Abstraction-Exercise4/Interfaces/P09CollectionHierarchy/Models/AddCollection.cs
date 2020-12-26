using P09CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Models
{
    public class AddCollection : IAdd
    {
        private readonly List<string> items;

        public AddCollection()
        {
            this.items = new List<string>();
        }

        public IReadOnlyCollection<string> Items => this.items;

        public int Add(string item)
        {
            this.items.Add(item);
            return this.items.IndexOf(item);
        }
    }
}
