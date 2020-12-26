using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return (double)(Math.PI * this.radius * this.radius);
        }

        public override double CalculatePerimeter()
        {
            return (double)(2 * Math.PI * this.radius);
        }

        public override string ToString()
        {
            return "Drawing circle";
        }
    }
}
