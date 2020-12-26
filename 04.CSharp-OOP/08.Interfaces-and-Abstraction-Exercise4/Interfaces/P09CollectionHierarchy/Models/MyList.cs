using P09CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private readonly List<string> items;

        public MyList()
        {
            this.items = new List<string>();
        }
        public int Used => this.Items.Count;

        public IReadOnlyCollection<string> Items => this.items;

        public int Add(string item)
        {
            this.items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string itemToremove = this.items[0];
            this.items.RemoveAt(0);
            return itemToremove;
        }
    }
}
