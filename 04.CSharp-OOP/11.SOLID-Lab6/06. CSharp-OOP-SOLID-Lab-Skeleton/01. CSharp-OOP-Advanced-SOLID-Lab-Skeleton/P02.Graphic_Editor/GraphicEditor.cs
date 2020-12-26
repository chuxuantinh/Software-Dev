using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            List<IDrawingManager> drawers = new List<IDrawingManager>()
            {
                new CircleDrawer(),
                new RectangleDrawer(),
                new SquareDrawer()
            };

            drawers.First(x => x.isMatch(shape)).Draw(shape);
        }
    }
}
