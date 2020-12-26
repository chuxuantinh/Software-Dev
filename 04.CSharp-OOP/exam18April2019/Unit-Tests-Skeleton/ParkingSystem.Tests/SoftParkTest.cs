namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark park;

        [SetUp]
        public void Setup()
        {
            this.park = new SoftPark();
        }

        [Test]
        public void TryParkOnInvalidParkSpotShouldThrow()
        {
            string expectedMessage = "Parking spot doesn't exists!";
            var exception = Assert.Throws<ArgumentException>(() => park.ParkCar("A0", null));
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test]
        public void TryParkOnTakenSpotShouldThrow()
        {
            this.park.ParkCar("A1", new Car("Make", "RN"));

            Assert.Throws<ArgumentException>(() => this.park.ParkCar("A1", new Car(string.Empty, string.Empty)));
        }

        [Test]
        public void TryParkSameCarShouldThrow()
        {
            Car car = new Car("Make", "RN");
            this.park.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() => this.park.ParkCar("A2", car));
        }

        [Test]
        public void ParkWithValidCarOnValidSpotShouldReturnExpectedMessage()
        {
            Car car = new Car("Make", "RN");
            string actualResult = this.park.ParkCar("A1", car);
            string expectedResult = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TryRemoveOnInvalidParkSpotShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("A0", null));
        }

        [Test]
        public void TryRemoveNonExistingCarFromParkingSpotShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => this.park.RemoveCar("A1", new Car(string.Empty, string.Empty)));
        }

        [Test]
        public void RemoveValidCarFromValidParkingSpotShouldReturnMessage()
        {
            Car car = new Car("Make", "RN");
            this.park.ParkCar("A1", car);

            string actualResult = this.park.RemoveCar("A1", car);
            string expectedResult = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ConstructorShouldInitializeAllParkingSpots()
        {
            int actualCount = this.park.Parking.Count;
            int expectedCount = 12;

            Assert.That(actualCount, Is.EqualTo(expectedCount));

        }
    }
}