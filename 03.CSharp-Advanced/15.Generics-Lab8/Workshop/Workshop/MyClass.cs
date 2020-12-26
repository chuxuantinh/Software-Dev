using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class MyClass : IEquatable<MyClass>
    {
        public string Name { get; set; }

        public bool Equals(MyClass other)
        {
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            MyClass item = obj as MyClass;
            if (item != null)
            {
                return Equals(item);
            }
            else
            {
                return false;
            }
        }
    }
}
