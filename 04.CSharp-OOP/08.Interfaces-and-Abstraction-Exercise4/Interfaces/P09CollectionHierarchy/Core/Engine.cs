using P09CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09CollectionHierarchy.Core
{
    public class Engine
    {
        private readonly AddCollection addCollection;
        private readonly AddRemoveCollection addRemoveCollection;
        private readonly MyList myList;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
        }

        public void Run()
        {
            string[] items = Console.ReadLine()
                .Split();

            StringBuilder sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append($"{this.addCollection.Add(item)} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());

            sb.Clear();

            foreach (var item in items)
            {
                sb.Append($"{this.addRemoveCollection.Add(item)} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());

            sb.Clear();

            foreach (var item in items)
            {
                sb.Append($"{this.myList.Add(item)} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());

            sb.Clear();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                sb.Append($"{this.addRemoveCollection.Remove()} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());

            sb.Clear();

            for (int i = 0; i < count; i++)
            {
                sb.Append($"{this.myList.Remove()} ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
