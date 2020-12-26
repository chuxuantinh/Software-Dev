//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfConstructorsAreWorkingCorrectly()
        {
            string expectedMake = "Renault";
            string expectedModel = "Megan";
            double expectedFuelConsumption = 6.0;
            double expectedFuelAmount = 0.0;
            double expectedFuelCapacity = 200.0;

            this.car = new Car(expectedMake, expectedModel, expectedFuelConsumption, expectedFuelCapacity);

            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
        }

        [Test]
        public void TestWithEmptyMake()
        {
            string make = "";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestWithEmptyModel()
        {
            string make = "Renault";
            string model = "";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestWithZeroFuelConsumption()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 0.0;
            double fuelCapacity = 200.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestWithNegativeFuelConsumption()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = -1.0;
            double fuelCapacity = 200.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestWithZeroFuelCapacity()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 0.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestWithNegativeFuelCapacity()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = -1.0;

            Assert.Throws<ArgumentException>(() => this.car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void TestIfRefuelWorksCorrectly()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double fuelToRefuel = 15.6;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelWithZeroAmountOfFuel()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double fuelToRefuel = 0.0;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        public void TestRefuelWithNegativeAmountOfFuel()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double fuelToRefuel = -1.0;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        public void TestRefuelWithAmountMoreThanCapacity()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double fuelToRefuel = 300.0;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(this.car.FuelCapacity, this.car.FuelAmount);
        }

        [Test]
        public void TestIfDriveWorksCorrectly()
        {
            double expectedFuelAmount = 94.0;
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double distance = 100.0;
            double fuelToRefuel = 100.0;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            this.car.Refuel(fuelToRefuel);
            this.car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void TestDriveWithInsufficientFuel()
        {
            string make = "Renault";
            string model = "Megan";
            double fuelConsumption = 6.0;
            double fuelCapacity = 200.0;
            double distance = 100.0;

            this.car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance)); 
        }
    }
}