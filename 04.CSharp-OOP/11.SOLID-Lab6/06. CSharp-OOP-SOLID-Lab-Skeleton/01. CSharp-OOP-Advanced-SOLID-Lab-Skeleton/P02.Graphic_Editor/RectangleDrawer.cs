using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class RectangleDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            var rectangle = shape as Rectangle;
            Console.WriteLine("I'm Recangle");
        }

        public bool isMatch(IShape shape)
        {
            if (shape is Rectangle)
            {
                return true;
            }

            return false;
        }
    }
}
