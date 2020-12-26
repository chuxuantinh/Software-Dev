using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private readonly int height;
        private readonly int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return (double)(this.height * this.width);
        }

        public override double CalculatePerimeter()
        {
            return (double)(2 * (this.height + this.width));
        }

        public override string Draw()
        {
            return "Drawing rectangle";
        }
    }
}
