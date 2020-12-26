using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitMotorcycle motorcycle;
        private UnitRider rider;
        private string riderName;
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfMotorcycleConstructorWorksCorrectly()
        {
            string expectedModel = "Model";
            int expectedHorsePower = 10;
            double expectedCubicCentimeters = 10.0;

            this.motorcycle = new UnitMotorcycle(expectedModel, expectedHorsePower, expectedCubicCentimeters);

            Assert.AreEqual(expectedModel, this.motorcycle.Model);
            Assert.AreEqual(expectedHorsePower, this.motorcycle.HorsePower);
            Assert.AreEqual(expectedCubicCentimeters, this.motorcycle.CubicCentimeters);
        }

        [Test]
        public void TestIfRiderConstructorWorksCorrectly()
        {
            string expectedRiderName = "RiderName";
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;

            this.motorcycle = new UnitMotorcycle(this.model, this.horsePower, this.cubicCentimeters);
            this.rider = new UnitRider(expectedRiderName, this.motorcycle);

            Assert.AreEqual(expectedRiderName, this.rider.Name);
            Assert.AreEqual(this.motorcycle, this.rider.Motorcycle);
        }

        [Test]
        public void TestRiderWithEmptyName()
        {
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;

            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            Assert.Throws<ArgumentNullException>(() => this.rider = new UnitRider(null, this.motorcycle));
        }

        [Test]
        public void TestIfRaceEntryConstructorWorksCorrectly()
        {
            int expectedCounter = 0;

            this.raceEntry = new RaceEntry();

            Assert.AreEqual(expectedCounter, this.raceEntry.Counter);
        }

        [Test]
        public void TestIfRaceEntryCounterWorksCorrectly()
        {
            int expectedCounter = 1;
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            this.riderName = "RiderName";
            this.rider = new UnitRider(this.riderName, this.motorcycle);

            this.raceEntry = new RaceEntry();
            this.raceEntry.AddRider(this.rider);

            Assert.AreEqual(expectedCounter, this.raceEntry.Counter);
        }

        [Test]
        public void TestIfAddRiderWorksCorrectly()
        {
            string expectedResult = "Rider RiderName added in race.";
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            this.riderName = "RiderName";
            this.rider = new UnitRider(this.riderName, this.motorcycle);

            this.raceEntry = new RaceEntry();
            

            Assert.AreEqual(expectedResult, this.raceEntry.AddRider(this.rider));
        }

        [Test]
        public void TestAddRiderWithNullRider()
        {
            this.rider = null;
            this.raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }

        [Test]
        public void TestAddRiderWithExistingRider()
        {
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            this.riderName = "RiderName";
            this.rider = new UnitRider(this.riderName, this.motorcycle);
            this.raceEntry = new RaceEntry();

            this.raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }

        [Test]
        public void TestIfCalculateWorksCorrectly()
        {
            double expectedAverageHorsePower = 10;
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            this.raceEntry = new RaceEntry();

            for (int i = 0; i < 2; i++)
            {
                this.rider = new UnitRider($"RiderName{i}", this.motorcycle);
                this.raceEntry.AddRider(rider);
            }

            Assert.AreEqual(expectedAverageHorsePower, this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void TestCalculateWithFewerThanMinParticipants()
        {
            this.riderName = "RiderName";
            this.model = "Model";
            this.horsePower = 10;
            this.cubicCentimeters = 10.0;
            this.motorcycle = new UnitMotorcycle(model, horsePower, cubicCentimeters);
            this.raceEntry = new RaceEntry();
            this.rider = new UnitRider(this.riderName, this.motorcycle);
            this.raceEntry.AddRider(this.rider);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }
    }
}