using CustomTestingFramework.Runner;
using System;

namespace MySpecialApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner();
            var resultSet = testRunner.Run(@"F:\softuni\05 CSharp OOP\17.Workshop-Lab9\CustomTestingFramework-Skeleton\MySpecialApp.Tests\bin\Debug\netcoreapp2.1\MySpecialApp.Tests.dll");

            foreach (var item in resultSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
