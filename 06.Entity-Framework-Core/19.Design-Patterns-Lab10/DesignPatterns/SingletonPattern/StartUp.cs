using System;

namespace SingletonPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
        }
    }
}
