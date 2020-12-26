using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Contracts
{
    public interface IDrawingManager
    {
        void Draw(IShape shape);

        bool isMatch(IShape shape);
    }
}
