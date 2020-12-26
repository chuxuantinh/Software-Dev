namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private string name = "Name";
        private int capacity = 2;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship(name, capacity);
        }

        [Test]
        public void TestAstronaut()
        {
            Astronaut a = new Astronaut("A", 15.6);
            Assert.AreEqual("A", a.Name);
            Assert.AreEqual(15.6, a.OxygenInPercentage);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(this.name, this.spaceship.Name);
            Assert.AreEqual(this.capacity, this.spaceship.Capacity);
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void TestAdd()
        {
            this.spaceship.Add(new Astronaut("Name", 12.5));
            Assert.AreEqual(1, this.spaceship.Count);
        }

        [Test]
        public void TestName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.spaceship = new Spaceship("", 1);
            }
            );
        }

        [Test]
        public void TestNameNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.spaceship = new Spaceship(null, 1);
            }
            );
        }

        [Test]
        public void TestCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.spaceship = new Spaceship("Name", -1);
            }
            );
        }

        [Test]
        public void TestAddAstronaut()
        {
            this.spaceship.Add(new Astronaut("Name", 12.5));
            this.spaceship.Add(new Astronaut("Name2", 12.5));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("Name3", 12.5));
            });
        }

        [Test]
        public void TestAddExists()
        {
            this.spaceship.Add(new Astronaut("Name", 12.5));
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("Name", 12.5));
            });
        }

        [Test]
        public void TestRemove()
        {
            this.spaceship.Add(new Astronaut("Name", 12.5));
            Assert.IsTrue(this.spaceship.Remove("Name"));
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void TestRemoveFalse()
        {
            this.spaceship.Add(new Astronaut("Name", 12.5));
            Assert.IsFalse(this.spaceship.Remove("Name2"));
            Assert.AreEqual(1, this.spaceship.Count);
        }
    }
}