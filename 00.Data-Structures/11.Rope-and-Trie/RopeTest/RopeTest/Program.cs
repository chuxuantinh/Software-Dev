using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace RopeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 100000;
            Console.WriteLine($"Iterations: {iterations}");

            BigList<string> rope = new BigList<string>();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < iterations; i++)
            {
                rope.Insert(0, "str");
            }

            Console.WriteLine($"Rope prepend time elapsed: {timer.ElapsedMilliseconds}");

            StringBuilder sb = new StringBuilder();
            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < iterations; i++)
            {
                sb.Insert(0, "str");
            }

            Console.WriteLine($"StringBuilder prepend time elapsed: {timer.ElapsedMilliseconds}");

            rope = new BigList<string>();
            sb = new StringBuilder();

            timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                rope.Add("str");
            }

            Console.WriteLine($"Rope append time elapsed: {timer.ElapsedMilliseconds}");

            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < iterations; i++)
            {
                sb.Append("str");
            }

            Console.WriteLine($"StringBuilder append time elapsed: {timer.ElapsedMilliseconds}");

            rope = new BigList<string>();
            sb = new StringBuilder();

            timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                rope.Insert(rope.Count / 2, "middle");
            }

            Console.WriteLine($"Rope insert in the middle time elapsed: {timer.ElapsedMilliseconds}");

            timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < iterations; i++)
            {
                sb.Insert(sb.Length / 2, "middle");
            }

            Console.WriteLine($"StringBuilder insert in the middle time elapsed: {timer.ElapsedMilliseconds}");
        }
    }
}
