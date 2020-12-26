//using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person;
        private List<Person> persons;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfPersonConstructorWorksCorrectly()
        {
            long expectedId = 12;
            string expectedName = "Pesho";

            Person person = new Person(12, "Pesho");

            Assert.AreEqual(expectedId, person.Id);
            Assert.AreEqual(expectedName, person.UserName);
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            int expectedCount = 1;
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };

            this.database = new ExtendedDatabase(persons);

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingMoreThan16Persons()
        {
            Person[] persons = { new Person(1, "Pesho") };

            this.database = new ExtendedDatabase(persons);

            for (long i = 2; i <= 16; i++)
            {
                this.database.Add(new Person(i, $"Pesho{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Pesho17")));
        }

        [Test]
        public void TestAddingSameUsername()
        {
            Person[] persons = { new Person(1, "Pesho") };

            this.database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(17, "Pesho")));
        }

        [Test]
        public void TestAddingSameId()
        {
            Person[] persons = { new Person(1, "Pesho") };

            this.database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.database.Add(new Person(1, "Pesho2")));
        }

        [Test]
        public void TestAddRangeWithMoreThan16Persons()
        {
            this.persons = new List<Person>();
            for (long i = 1; i <= 17; i++)
            {
                persons.Add(new Person(i, $"Pesho{i}"));
            }
            Person[] personsArray = persons.ToArray();

            Assert.Throws<ArgumentException>(() => this.database = new ExtendedDatabase(personsArray));
        }

        [Test]
        public void TestIfRemoveWorksCorrectly()
        {
            int expectedCount = 1;

            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Pesho2")
            };

            this.database = new ExtendedDatabase(persons);

            this.database.Remove();

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestRemovingWhenEmpty()
        {
            Person[] persons = { new Person(1, "Pesho") };

            this.database = new ExtendedDatabase(persons);
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void TestIfFindByUsernameWorksCorrectly()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.AreEqual(this.person, this.database.FindByUsername(this.person.UserName));
        }

        [Test]
        public void TestFindByUsernameWithEmptyName()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(""));
        }

        [Test]
        public void TestFindByUsernameWithNonExisting()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Gosho"));
        }

        [Test]
        public void TestIfFindByIdWorksCorrectly()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.AreEqual(this.person, this.database.FindById(this.person.Id));
        }

        [Test]
        public void TestFindByIdWithNegativeId()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void TestFindByIdWithNonExisting()
        {
            this.person = new Person(1, "Pesho");
            Person[] persons = { this.person };
            this.database = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.database.FindById(2));
        }
    }
}