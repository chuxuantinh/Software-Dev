using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the WholeWheat Bread (15 minutes).");
        }

        public override void MixIngreadients()
        {
            Console.WriteLine($"Gathering ingredients for WholeWheat bread!");
        }
    }
}
