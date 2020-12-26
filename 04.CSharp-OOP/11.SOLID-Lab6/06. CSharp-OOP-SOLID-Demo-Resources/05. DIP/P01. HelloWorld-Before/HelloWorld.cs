using System;

namespace P01._HelloWorld
{
    public class HelloWorld
    {
        public string Greeting(string name, DateTime dateNow)
        {
            if (dateNow.Hour < 12)
            {
                return "Good morning, " + name;
            }

            if (dateNow.Hour < 18)
            {
                return "Good afternoon, " + name;
            }

            return "Good evening, " + name;
        }
    }
}
