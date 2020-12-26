namespace P02._DrawingShape_Before
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    class DrawingManager 
    {
        public void Draw(IShape shape)
        {
            List<IDrawingManager> drawers = new List<IDrawingManager>()
            {
                new CircleDrawer(),
                new RectangleDrawer()
            };

            drawers.First(x => x.isMatch(shape)).Draw(shape);

            
        }
    }
}
