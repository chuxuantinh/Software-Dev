using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class CircleDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            var circle = shape as Circle;
            Console.WriteLine("I'm Circle");
        }

        public bool isMatch(IShape shape)
        {
            if (shape is Circle)
            {
                return true;
            }

            return false;
        }
    }
}
