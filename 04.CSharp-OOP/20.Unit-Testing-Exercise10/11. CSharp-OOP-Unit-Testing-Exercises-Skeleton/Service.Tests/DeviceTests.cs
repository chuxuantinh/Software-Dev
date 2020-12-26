using NUnit.Framework;
//using Service.Models.Devices;
//using Service.Models.Parts;
using System;

namespace Service.Tests
{
    public class DeviceTests
    {
        private string make;
        private Device device;
        private string name;
        private decimal cost;
        bool isBroken;
        private Part part;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfLaptopConstructorWorksCorrectly()
        {
            string expectedMake = "DeviceMake";

            this.device = new Laptop(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void TestIfLaptopAddPartWorksCorrectly()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void TestLaptopAddPartWithInvalidType()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new PCPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void TestIfPCConstructorWorksCorrectly()
        {
            string expectedMake = "DeviceMake";

            this.device = new PC(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void TestIfPCAddPartWorksCorrectly()
        {
            this.make = "DeviceMake";
            this.device = new PC(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new PCPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void TestPCAddPartWithInvalidType()
        {
            this.make = "DeviceMake";
            this.device = new PC(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void TestIfPhoneConstructorWorksCorrectly()
        {
            string expectedMake = "DeviceMake";

            this.device = new Phone(expectedMake);

            Assert.AreEqual(expectedMake, this.device.Make);
            Assert.IsNotNull(this.device.Parts);
        }

        [Test]
        public void TestIfPhoneAddPartWorksCorrectly()
        {
            this.make = "DeviceMake";
            this.device = new Phone(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new PhonePart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.That(this.device.Parts, Has.Member(this.part));
        }

        [Test]
        public void TestPhoneAddPartWithInvalidType()
        {
            this.make = "DeviceMake";
            this.device = new Phone(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void TestDeviceWithEmptyName()
        {
            this.make = "";
            Assert.Throws<ArgumentException>(() => this.device = new Laptop(this.make));
        }

        [Test]
        public void TestDeviceAddPartWithExistingPart()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(() => this.device.AddPart(this.part));
        }

        [Test]
        public void TestIfDeviceRemovePartWorksCorrectly()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);
            this.device.RemovePart(this.part.Name);

            Assert.That(this.device.Parts, !Has.Member(part));
        }

        [Test]
        public void TestDeviceRemovePartWithEmptyName()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "";

            Assert.Throws<ArgumentException>(() => this.device.RemovePart(this.name));
        }

        [Test]
        public void TestDeviceRemovePartWithNonExistingPart()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "NonExisting";

            Assert.Throws<InvalidOperationException>(() => this.device.RemovePart(this.name));
        }

        [Test]
        public void TestIfDeviceRepairPartWorksCorrectly()
        {
            bool expectedIsBroken = false;
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = true;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);
            this.device.RepairPart(this.name);

            Assert.AreEqual(expectedIsBroken, this.part.IsBroken);
        }

        [Test]
        public void TestDeviceRepairPartWithEmptyName()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "";

            Assert.Throws<ArgumentException>(() => this.device.RepairPart(this.name));
        }

        [Test]
        public void TestDeviceRepairPartWithNonExistingPart()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "NonExisting";

            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart(this.name));
        }

        [Test]
        public void TestDeviceRepairPartWithNonBrokenPart()
        {
            this.make = "DeviceMake";
            this.device = new Laptop(this.make);
            this.name = "PartName";
            this.cost = 10.0m;
            this.isBroken = false;
            this.part = new LaptopPart(name, cost, isBroken);

            this.device.AddPart(this.part);

            Assert.Throws<InvalidOperationException>(() => this.device.RepairPart(this.name));
        }
    }
}
