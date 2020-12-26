using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the TwelveGrain Bread (25 minutes).");
        }

        public override void MixIngreadients()
        {
            Console.WriteLine($"Gathering ingredients for TwelveGrain bread!");
        }
    }
}
