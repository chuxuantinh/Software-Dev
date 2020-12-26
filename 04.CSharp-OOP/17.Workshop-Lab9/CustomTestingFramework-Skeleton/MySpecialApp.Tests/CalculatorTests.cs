using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;
using System;

namespace MySpecialApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldSumSuccessfullyTwoValues()
        {
            int a = 10;
            int b = 20;
            int expectedResult = 30;

            Calculator calculator = new Calculator();
            var actualResult = calculator.Sum(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ShouldDevideSuccessfullyTwoValues()
        {
            int a = 10;
            int b = 10;
            int expectedResult = 1;

            Calculator calculator = new Calculator();
            var actualResult = calculator.Devide(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
