namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;
    using _02.LegionSystem.Models;
    using Wintellect.PowerCollections;

    public class Legion : IArmy
    {
        private OrderedSet<IEnemy> _entitiesByAttackSpeed;
        private OrderedSet<IEnemy> _entitiesByHealth;

        public Legion()
        {
            this._entitiesByAttackSpeed = new OrderedSet<IEnemy>();
            this._entitiesByHealth = new OrderedSet<IEnemy>((x, y) => y.Health - x.Health);
        }

        public int Size => this._entitiesByAttackSpeed.Count;

        public bool Contains(IEnemy enemy)
        {
            return this._entitiesByAttackSpeed.Contains(enemy);
        }

        public void Create(IEnemy enemy)
        {
            this._entitiesByAttackSpeed.Add(enemy);
            this._entitiesByHealth.Add(enemy);
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this._entitiesByAttackSpeed[i].AttackSpeed == speed)
                {
                    return this._entitiesByAttackSpeed[i];
                }
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var from = new Enemy(speed, 0);

            return this._entitiesByAttackSpeed.RangeFrom(from, false).ToList();
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();
            return this._entitiesByAttackSpeed.GetLast();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return this._entitiesByHealth.ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var to = new Enemy(speed, 0);

            return this._entitiesByAttackSpeed.RangeTo(to, false).ToList();
        }

        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();
            return this._entitiesByAttackSpeed.GetFirst();
        }

        public void ShootFastest()
        {
            this.EnsureNotEmpty();
            var toRemove = this._entitiesByAttackSpeed.RemoveLast();
            this._entitiesByHealth.Remove(toRemove);
        }

        public void ShootSlowest()
        {
            this.EnsureNotEmpty();
            var toRemove = this._entitiesByAttackSpeed.RemoveFirst();
            this._entitiesByHealth.Remove(toRemove);
        }

        private void EnsureNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
