using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attack = 2;
        private int durability = 2;
        private int health = 20;
        private int experience = 20;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(attack, durability);
            this.dummy = new Dummy(health, experience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe Durabiblity doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
