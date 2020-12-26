using System;

namespace P01._Square_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle();
            ResizeShape(rec);
        }

        public static void ResizeShape(Rectangle rec)
        {
            rec.Height = rec.Height * 10;
        }
    }
}
