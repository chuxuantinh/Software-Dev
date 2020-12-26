namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void TestIfCompareToWorksCorrectly1()
        {
            var product1 = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            };
            var product2 = new Product()
            {
                Label = "MyProduct",
                Quantity = 2,
                Price = 100m
            };

            Assert.That(product1.CompareTo(product2) == 0);
        }

        [Test]
        public void TestIfCompareToWorksCorrectly2()
        {
            var product1 = new Product()
            {
                Label = "MyProduct1",
                Quantity = 1,
                Price = 100m
            };
            var product2 = new Product()
            {
                Label = "MyProduct2",
                Quantity = 2,
                Price = 100m
            };

            Assert.That(product1.CompareTo(product2) != 0);
        }

        [Test]
        public void ErrorIfComparingSameProductsWithDifferentPrice()
        {
            var product1 = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 150m
            };
            var product2 = new Product()
            {
                Label = "MyProduct",
                Quantity = 2,
                Price = 100m
            };

            Assert.Throws<ArgumentException>(() => product1.CompareTo(product2));
        }
    }
}