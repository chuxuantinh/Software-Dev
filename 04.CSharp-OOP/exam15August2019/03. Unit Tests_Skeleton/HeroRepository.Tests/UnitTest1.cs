using NUnit.Framework;
using System;
using System.Collections.Generic;

//namespace HeroRepository.Tests
//{
    public class Tests
    {
        private HeroRepository hr;
        private string name;
        private int level;

        [SetUp]
        public void Setup()
        {
            this.hr = new HeroRepository();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual(0, this.hr.Heroes.Count);
        }

        [Test]
        public void TestCreate()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Assert.AreEqual(1, this.hr.Heroes.Count);
        }

        [Test]
        public void TestCreateWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.hr.Create(null));
        }

        [Test]
        public void TestCreateWithExisting()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Assert.Throws<InvalidOperationException>(() => this.hr.Create(hero));
        }

        [Test]
        public void TestRemove()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Assert.IsTrue(this.hr.Remove(this.name));
            Assert.AreEqual(0, this.hr.Heroes.Count);
        }

        [Test]
        public void TestRemoveWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.hr.Remove(string.Empty));
        }

        [Test]
        public void TestRemoveWithWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => this.hr.Remove("  "));
        }

        [Test]
        public void TestGetHeroWithHighestLevel()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Hero hero2 = new Hero("Name2", 2);
            this.hr.Create(hero2);
            Assert.AreEqual(hero2, this.hr.GetHeroWithHighestLevel());
        }

        [Test]
        public void TestGetHero()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Assert.AreEqual(hero, this.hr.GetHero(this.name));
        }

        [Test]
        public void TestGetHeroReturnsNull()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Assert.IsNull(this.hr.GetHero("Name2"));
        }

        [Test]
        public void TestHeroes()
        {
            this.name = "Name";
            this.level = 1;
            Hero hero = new Hero(this.name, this.level);
            this.hr.Create(hero);
            Hero hero2 = new Hero("Name2", 2);
            this.hr.Create(hero2);
            List<Hero> expectedResult = new List<Hero>() { hero, hero2};
            CollectionAssert.AreEqual(expectedResult, this.hr.Heroes);
        }
    }
//}