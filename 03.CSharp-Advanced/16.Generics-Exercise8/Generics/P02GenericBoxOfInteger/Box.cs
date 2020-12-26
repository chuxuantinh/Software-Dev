using System;
using System.Collections.Generic;
using System.Text;

namespace P01GenericBoxOfString
{
    public class Box<TItem>
    {
        private List<TItem> boxCollection;

        public Box()
        {
            boxCollection = new List<TItem>();
        }
        public void Add(TItem item)
        {
            boxCollection.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var text in boxCollection)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
