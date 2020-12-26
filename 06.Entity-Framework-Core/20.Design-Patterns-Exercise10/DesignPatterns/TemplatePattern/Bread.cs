using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngreadients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {GetType().Name} bread!");
        }

        public void Make()
        {
            MixIngreadients();
            Bake();
            Slice();
        }
    }
}
