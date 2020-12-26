using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P02HighQualityMistakes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
