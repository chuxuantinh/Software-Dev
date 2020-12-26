using P01._HelloWorld;
using System;

namespace P01._HelloWorld_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeting = new HelloWorld();
            greeting.Greeting("pesho", DateTime.Now);
        }

        [TestMethod]
        public static void Test()
        {
            var greeting = new HelloWorld();
            greeting.Greeting("pesho", dateInTwelveAClock);
        }
    }
}
