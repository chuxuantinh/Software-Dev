using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03MissionPrivateImpossible
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
