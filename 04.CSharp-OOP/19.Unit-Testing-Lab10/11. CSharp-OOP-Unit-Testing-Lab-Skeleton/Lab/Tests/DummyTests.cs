using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health = 20;
        private int experience = 10;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(health, experience);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(15), "Dummy doesn't lose health after attack.");
        }

        [Test]
        public void DeadDummyCantBeAttacked()
        {
            dummy.TakeAttack(20);

            Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesXP()
        {
            dummy.TakeAttack(20);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(10), "Dead dummy doesn't give experience.");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            dummy.TakeAttack(15);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
