using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class SquareDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            var square = shape as Square;
            Console.WriteLine("I'm Square");
        }

        public bool isMatch(IShape shape)
        {
            if (shape is Square)
            {
                return true;
            }

            return false;
        }
    }
}
