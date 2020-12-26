using System;
using System.Collections.Generic;
using System.Text;

namespace P01GenericBoxOfString
{
    public class Box<TItem> where TItem : IComparable<TItem>
    {
        private List<TItem> boxCollection;

        public Box()
        {
            boxCollection = new List<TItem>();
        }

        public int CountGreater { get; private set; }

        public void Add(TItem item)
        {
            boxCollection.Add(item);
        }

        public void Compare(TItem item)
        {
            foreach (var currentItem in boxCollection)
            {
                if (currentItem.CompareTo(item) > 0)
                {
                    CountGreater++;
                }
            }
        }

        public void Swap(int x, int y)
        {
            TItem tempValue = boxCollection[x];
            boxCollection[x] = boxCollection[y];
            boxCollection[y] = tempValue;
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
