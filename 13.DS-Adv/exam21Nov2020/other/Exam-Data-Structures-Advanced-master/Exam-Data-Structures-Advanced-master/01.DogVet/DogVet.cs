namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogs;
        private Dictionary<string, Owner> owners;
        private Dictionary<Breed, HashSet<Dog>> byBreed;
        private Dictionary<int, HashSet<Dog>> byAge;

        public DogVet()
        {
            this.dogs = new Dictionary<string, Dog>();
            this.owners = new Dictionary<string, Owner>();
            this.byBreed = new Dictionary<Breed, HashSet<Dog>>();
            this.byAge = new Dictionary<int, HashSet<Dog>>();
        }

        public int Size => this.dogs.Count;

        public void AddDog(Dog dog, Owner owner)
        {

            if (this.Contains(dog))
            {
                throw new ArgumentException();
            }

            if (this.owners.ContainsKey(owner.Id) && this.owners[owner.Id].Dogs.ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            dog.Owner = owner;
            this.dogs[dog.Id] = dog;

            owner.Dogs.Add(dog.Name, dog);
            this.owners[owner.Id] = owner;

            this.byBreed.AddValueToKey(dog.Breed, dog);
            this.byAge.AddValueToKey(dog.Age, dog);
        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.owners[ownerId].Dogs.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return this.owners[ownerId].Dogs[name];                
        }

        public Dog RemoveDog(string name, string ownerId)
        {

            Dog dog = this.GetDog(name, ownerId);

            Dog temp = dog;
            this.owners[ownerId].Dogs.Remove(dog.Name);
            this.byBreed.RemoveValueFromKey(dog.Breed, dog);
            this.byAge.RemoveValueFromKey(dog.Age, dog);

            this.dogs.Remove(dog.Id);

            return temp;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.owners[ownerId].Dogs.Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (!this.byBreed.ContainsKey(breed))
            {
                throw new ArgumentException();
            }

            IEnumerable<Dog> query = this.byBreed[breed];

            return query;
        }

        public void Vaccinate(string name, string ownerId)
        {
            Dog dog = this.GetDog(name, ownerId);

            dog.Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            Dog dog = this.GetDog(oldName, ownerId);

            Owner owner = this.owners[ownerId];
            owner.Dogs.Remove(dog.Name);

            dog.Name = newName;

            owner.Dogs[newName] = dog;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            if (!this.byAge.ContainsKey(age))
            {
                throw new ArgumentException();
            }

            IEnumerable<Dog> query = this.byAge[age];

            return query;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            IEnumerable<Dog> query = this.byAge.Keys
                .Where(k => k >= lo && k <= hi)
                .SelectMany(k => this.byAge[k])
                .ToArray();

            return query;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            IEnumerable<Dog> query = this.byAge.Keys
                .SelectMany(k => this.byAge[k])
                .OrderBy(d => d.Age)
                .ThenBy(d => d.Name)
                .ThenBy(d => d.Owner.Name)
                .ToArray();

            return query;
        }
    }
}