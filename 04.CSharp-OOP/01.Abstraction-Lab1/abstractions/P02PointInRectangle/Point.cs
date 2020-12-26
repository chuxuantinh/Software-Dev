using System;
using System.Collections.Generic;
using System.Text;

namespace P02PointInRectangle
{
    public class Point
    {
        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public Point(int coordinateX, int coordinateY)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }
    }
}
