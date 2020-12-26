namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        private string make = "Make";
        private string model = "Model";

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(make, model);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(make, this.phone.Make);
            Assert.AreEqual(model, this.phone.Model);
        }

        [Test]
        public void TestWithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(string.Empty, model);
            });
        }

        [Test]
        public void TestWithEmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, string.Empty);
            });
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            int expectedCount = 2;

            this.phone.AddContact("Pesho", "+3592214587");
            this.phone.AddContact("Gosho", "+3596241854");

            Assert.AreEqual(expectedCount, this.phone.Count);
        }

        [Test]
        public void TestAddingExistingPerson()
        {
            this.phone.AddContact("Pesho", "+3592214587");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "+3592214587"));
        }

        [Test]
        public void AddShouldAddCallableNumber()
        {
            string name = "Pesho";
            string number = "+3592214587";
            string expectedOutput = $"Calling {name} - {number}...";

            this.phone.AddContact(name, number);

            string actualOutput = this.phone.Call(name);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void TestCallingNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Pesho"));
        }
    }
}