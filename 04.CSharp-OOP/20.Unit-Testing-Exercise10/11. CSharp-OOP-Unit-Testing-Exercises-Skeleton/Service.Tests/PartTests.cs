using NUnit.Framework;
//using Service.Models.Parts;
using System;

namespace Tests
{
    public class PartTests
    {
        private string name;
        private decimal cost;
        bool isBroken;
        private Part part;
        private decimal multiplier;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfLaptopPartConstructor1WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = false;
            this.multiplier = 1.5m;

            this.part = new LaptopPart(expectedName, expectedCost);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfLaptopPartConstructor2WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = true;
            this.multiplier = 1.5m;

            this.part = new LaptopPart(expectedName, expectedCost, expectedIsBroken);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfPCPartConstructor1WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = false;
            this.multiplier = 1.2m;

            this.part = new PCPart(expectedName, expectedCost);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfPCPartConstructor2WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = true;
            this.multiplier = 1.2m;

            this.part = new PCPart(expectedName, expectedCost, expectedIsBroken);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfPhonePartConstructor1WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = false;
            this.multiplier = 1.3m;

            this.part = new PhonePart(expectedName, expectedCost);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfPhonePartConstructor2WorksCorrectly()
        {
            string expectedName = "PartName";
            decimal expectedCost = 10.0m;
            bool expectedIsBroken = true;
            this.multiplier = 1.3m;

            this.part = new PhonePart(expectedName, expectedCost, expectedIsBroken);

            Assert.AreEqual(expectedName, this.part.Name);
            Assert.AreEqual(expectedCost * this.multiplier, this.part.Cost);
            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestPartWithEmptyName()
        {
            this.name = "";
            this.cost = 10.0m;

            Assert.Throws<ArgumentException>(() => this.part = new LaptopPart(name, cost));
        }

        [Test]
        public void TestPartWithZeroCost()
        {
            this.name = "PartName";
            this.cost = 0.0m;

            Assert.Throws<ArgumentException>(() => this.part = new LaptopPart(name, cost));
        }

        [Test]
        public void TestPartWithNegativeCost()
        {
            this.name = "PartName";
            this.cost = -1.0m;

            Assert.Throws<ArgumentException>(() => this.part = new LaptopPart(name, cost));
        }

        [Test]
        public void TestIfRepairWorksCorrectly()
        {
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            bool expectedIsBroken = false;

            this.part = new LaptopPart(name, cost, isBroken);
            this.part.Repair();

            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestIfReportWorksCorrectly()
        {
            this.name = "PartName";
            this.cost = 10.00m;
            this.isBroken = true;
            this.multiplier = 1.5m;
            string expectedResult = $"{this.name} - {this.cost * this.multiplier:f2}$" + Environment.NewLine +
                $"Broken: {this.isBroken}";

            this.part = new LaptopPart(name, cost, isBroken);

            Assert.AreEqual(expectedResult, this.part.Report());
        }
    }
}