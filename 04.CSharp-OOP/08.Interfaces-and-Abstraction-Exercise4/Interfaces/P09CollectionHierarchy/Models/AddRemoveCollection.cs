using P09CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemove
    {
        private readonly List<string> items;

        public AddRemoveCollection()
        {
            this.items = new List<string>();
        }

        public IReadOnlyCollection<string> Items => this.items;

        public int Add(string item)
        {
            this.items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemToRemove = this.items[this.items.Count - 1];
            this.items.RemoveAt(this.items.Count - 1);
            return itemToRemove;
        }
    }
}
