namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;

        [SetUp]
        public void CreateTestObjects()
        {
            productStock = new ProductStock();
            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            }); 
        }

        [Test]
        public void DuplicateLabelAfterAddingNewProduct()
        {
            int countBeforeAdd = productStock.Count;
            productStock.Add(new Product() { Label = "MyProduct", Price = 100m } );
            Assert.That(productStock.Count == countBeforeAdd);
        }

        [Test]
        public void ProductQuantityIncreasedByQuantityAdded()
        {
            int quantityBefore = productStock.FirstOrDefault().Quantity;
            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            });
            Assert.That(productStock.FirstOrDefault().Quantity == 6);
        }

        [Test]
        public void PricePreservedAfterNewProductAdded()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(() => productStock.Add(product), Throws.ArgumentException);
        }

        [Test]
        public void TrueIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            };

            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void FalseIfNotContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct1",
                Quantity = 5,
                Price = 100m
            };

            Assert.That(!productStock.Contains(product));
        }

        [Test]
        public void FindsNthProductINStock()
        {
            var product = new Product()
            {
                Label = "MyProduct1",
                Quantity = 5,
                Price = 100m
            };

            productStock.Add(product);
            var findedProduct = productStock.Find(2);

            Assert.That(findedProduct.Label, Is.EqualTo(product.Label));
        }

        [Test]
        public void ErrorIfProductIndexIsNotValid()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(8));
        }

        [Test]
        public void ProductFoundByLabel()
        {
            var product = productStock.FindByLabel("MyProduct");

            Assert.AreEqual(product, productStock.First());
        }

        [Test]
        public void ErrorIfLabelNotFound()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel("NonExisting"));
        }

        [Test]
        public void EmptyListIfNotFound()
        {
            var products = productStock.FindAllInPriceRange(1.0m, 2.0m);
            Assert.That(products.Count() == 0);
        }

        [Test]
        public void FindAllWithLowestPriceRange()
        {
            var products = productStock.FindAllInPriceRange(100.0m, 200.0m);
            var expectedProduct = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            };
           
            Assert.That(expectedProduct.CompareTo(products.First()) == 0);
        }

        [Test]
        public void FindAllWithHighestPriceRange()
        {
            var products = productStock.FindAllInPriceRange(50.0m, 100.0m);
            var expectedProduct = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            };

            Assert.That(expectedProduct.CompareTo(products.First()) == 0);
        }

        [Test]
        public void TestIfFindAllReturnsInDescendingOrder()
        {
            var product = new Product()
            {
                Label = "MyProduct2",
                Quantity = 5,
                Price = 200m
            };

            productStock.Add(product);

            var products = productStock.FindAllInPriceRange(100.0m, 200.0m);

            Assert.That(product.CompareTo(products.Last()) != 0);
        }

        [Test]
        public void EmptyListIfNotFoundByPrice()
        {
            var products = productStock.FindAllByPrice(1.0m);
            Assert.That(products.Count() == 0);
        }

        [Test]
        public void TestIfFindByPriceWorksCorrectly()
        {
            var product = new Product()
            {
                Label = "MyProduct2",
                Quantity = 5,
                Price = 100m
            };

            productStock.Add(product);

            var products = productStock.FindAllByPrice(100.0m);

            Assert.That(products.Count() == 2);
        }

        [Test]
        public void TestIfFindMostExpensiveProductWorksCorrectly()
        {
            var expectedProduct = new Product()
            {
                Label = "MyProduct2",
                Quantity = 5,
                Price = 200m
            };

            productStock.Add(expectedProduct);

            var actualProduct = productStock.FindMostExpensiveProduct();

            Assert.That(expectedProduct.CompareTo(actualProduct) == 0);
        }

        [Test]
        public void TestIfFindByQuantityReturnsEmpty()
        {
            var products = productStock.FindAllByQuantity(2);
            Assert.IsEmpty(products);
        }

        [Test]
        public void TestIfFindByQuantityWorksCorrectly()
        {
            var product = new Product()
            {
                Label = "MyProduct2",
                Quantity = 1,
                Price = 100m
            };

            productStock.Add(product);

            var products = productStock.FindAllByQuantity(1);
            Assert.That(products.Count() == 2);
        }

        [Test]
        public void TestIfGetEnumeratorWorksCorrectly()
        {
            var product = new Product()
            {
                Label = "MyProduct2",
                Quantity = 1,
                Price = 100m
            };

            productStock.Add(product);
            var products = productStock.GetEnumerator();

            int count = 0;
            while (products.MoveNext())
            {
                count++;
            }

            Assert.That(count == 2);
        }

        [Test]
        public void TestGetIndexer()
        {
            var expectedProduct = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            };
            var actualProduct = productStock[0];

            Assert.That(expectedProduct.CompareTo(actualProduct) == 0);
        }

        [Test]
        public void TestSetIndexer()
        {
            var expectedProduct = new Product()
            {
                Label = "MyProduct2",
                Quantity = 1,
                Price = 100m
            };

            productStock[0] = expectedProduct;

            Assert.That(expectedProduct.CompareTo(productStock[0]) == 0);
        }

        [TearDown]
        public void DestroyObjects()
        {
            productStock = null;
        }
    }
}
