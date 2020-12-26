using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the SourDough Bread (20 minutes).");
        }

        public override void MixIngreadients()
        {
            Console.WriteLine($"Gathering ingredients for SourDough bread!");
        }
    }
}
