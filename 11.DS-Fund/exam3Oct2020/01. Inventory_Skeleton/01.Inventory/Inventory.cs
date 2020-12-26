namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> _entities;

        public Inventory()
        {
            this._entities = new List<IWeapon>();
        }

        public int Capacity => this._entities.Count;

        public void Add(IWeapon weapon)
        {
            this._entities.Add(weapon);
        }

        public void Clear()
        {
            this._entities.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.GetById(weapon.Id) != null;
        }

        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this._entities[i];

                if (current.Category == category)
                {
                    current.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            int index = this._entities.IndexOf(weapon);
            this.ValidateEntity(index);

            if (ammunition <= weapon.Ammunition)
            {
                this._entities[index].Ammunition -= ammunition;
                return true;
            }

            return false;
        }

        public IWeapon GetById(int id)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var currentEntity = this._entities[i];

                if (currentEntity.Id == id)
                {
                    return currentEntity;
                }
            }

            return null;
        }

        public IEnumerator<IWeapon> GetEnumerator()
        {
            return this._entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            int index = this._entities.IndexOf(weapon);
            this.ValidateEntity(index);

            this._entities[index].Ammunition += ammunition;

            if (this._entities[index].Ammunition > weapon.MaxCapacity)
            {
                this._entities[index].Ammunition = weapon.MaxCapacity;
            }

            return this._entities[index].Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            IWeapon found = this.GetById(id);

            if (found == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            this._entities.Remove(found);
            return found;
        }

        public int RemoveHeavy()
        {
            return this._entities.RemoveAll(e => e.Category == Category.Heavy);
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(this._entities);
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>(this.Capacity);
            int lowerBoundIndex = (int)lower;
            int upperBoundIndex = (int)upper;

            for (int i = 0; i < this.Capacity; i++)
            {
                var entity = this._entities[i];
                int entityCategoryIndex = (int)entity.Category;

                if (entityCategoryIndex >= lowerBoundIndex && entityCategoryIndex <= upperBoundIndex)
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int indexOfFirst = this._entities.IndexOf(firstWeapon);
            int indexOfSecond = this._entities.IndexOf(secondWeapon);
            this.ValidateEntity(indexOfFirst);
            this.ValidateEntity(indexOfSecond);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                var temp = this._entities[indexOfFirst];
                this._entities[indexOfFirst] = this._entities[indexOfSecond];
                this._entities[indexOfSecond] = temp;
            }
        }

        private void ValidateEntity(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
