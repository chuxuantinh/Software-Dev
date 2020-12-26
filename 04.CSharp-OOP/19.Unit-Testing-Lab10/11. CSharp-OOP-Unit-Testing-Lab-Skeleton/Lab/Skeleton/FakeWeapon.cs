using Skeleton.Contracts;
using System;

namespace Skeleton
{
    public class FakeWeapon : IWeapon
    {
        private int attackPoints;

        public int AttackPoints => throw new NotImplementedException();

        public int DurabilityPoints => throw new NotImplementedException();

        public void Attack(ITarget target)
        {
            target.TakeAttack(this.attackPoints);
        }
    }
}
