using System;

namespace P02._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var peshoCircle = new Circle();
            var peshoCircle1 = new Circle();
            var peshoCircle2 = new Circle();

            var goshoRec = new Rectangle();
            var goshoRec1 = new Rectangle();
            var goshoRec2 = new Rectangle();

            var drawer = new DrawingManager();

            drawer.Draw(peshoCircle);
            drawer.Draw(goshoRec);
            drawer.Draw(peshoCircle1);
            drawer.Draw(goshoRec1);
            drawer.Draw(peshoCircle2);
        }
    }
}
