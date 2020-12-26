namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        List<Dog> dogs = new List<Dog>();
        Dictionary<string, Dictionary<string, Dog>> byOwnerId = new Dictionary<string, Dictionary<string, Dog>>();
        Dictionary<Breed, HashSet<Dog>> byBreed = new Dictionary<Breed, HashSet<Dog>>();
        Dictionary<int, HashSet<Dog>> byAge = new Dictionary<int, HashSet<Dog>>();
        // SortedDictionary<int, SortedDictionary<string, SortedDictionary<string, List<Dog>>>> ordered = new SortedDictionary<int, SortedDictionary<string, SortedDictionary<string, List<Dog>>>>();
        // not used

        public int Size { get => dogs.Count; }

        public void AddDog(Dog dog, Owner owner)
        {
            if (dogs.Any(d => d.Id == dog.Id))
            {
                throw new ArgumentException();
            }

            if (!byOwnerId.ContainsKey(owner.Id))
            {
                byOwnerId[owner.Id] = new Dictionary<string, Dog>();
            }

            if (byOwnerId[owner.Id].ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }
            dog.Owner = owner;
            // owner.Dogs.Add(dog.Name, dog); //you don't use it. maybe with Dictionary<OwnwerId, Owner> 
            byOwnerId[owner.Id].Add(dog.Name, dog);

            if (!byBreed.ContainsKey(dog.Breed))
            {
                byBreed[dog.Breed] = new HashSet<Dog>();
            }
            byBreed[dog.Breed].Add(dog);

            if (!byAge.ContainsKey(dog.Age))
            {
                byAge[dog.Age] = new HashSet<Dog>();
            }
            byAge[dog.Age].Add(dog);

            dogs.Add(dog);
        }

        public bool Contains(Dog dog)
        {
            return dogs.Contains(dog);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!byOwnerId.ContainsKey(ownerId))//?
            {
                throw new ArgumentException();
            }

            if (!byOwnerId[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }

            return byOwnerId[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            // Check if the given Owner and Dog exists

            if (!this.byOwnerId.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            if (!this.byOwnerId[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }
            var dogToRemove = GetDog(name, ownerId);

            dogs.Remove(dogToRemove);

            byOwnerId[ownerId].Remove(name);
            if (byOwnerId[ownerId].Count == 0)
            {
                byOwnerId.Remove(ownerId);
            }

            byBreed[dogToRemove.Breed].Remove(dogToRemove);
            if (byBreed[dogToRemove.Breed].Count == 0)
            {
                byBreed.Remove(dogToRemove.Breed);
            }

            byAge[dogToRemove.Age].Remove(dogToRemove);
            if (byAge[dogToRemove.Age].Count == 0)
            {
                byAge.Remove(dogToRemove.Age);
            }

            return dogToRemove;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!byOwnerId.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }
            return byOwnerId[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            if (!byBreed.ContainsKey(breed) || byBreed[breed].Count == 0)
            {
                throw new ArgumentException();
            }
            return byBreed[breed];
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!byOwnerId.ContainsKey(ownerId) || !byOwnerId[ownerId].ContainsKey(name))//?
            {
                throw new ArgumentException();
            }

            byOwnerId[ownerId][name].Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!byOwnerId.ContainsKey(ownerId) || !byOwnerId[ownerId].ContainsKey(oldName))//?
            {
                throw new ArgumentException();
            }
            var dog = byOwnerId[ownerId][oldName];
            dog.Name = newName;
            byOwnerId[ownerId].Remove(oldName);
            byOwnerId[ownerId].Add(newName, dog);
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            if (!byAge.ContainsKey(age))
            {
                throw new ArgumentException();
            }

            return byAge[age];
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            return dogs.Where(d => lo <= d.Age && d.Age <= hi).ToList();
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            return dogs.OrderBy(d => d.Age).ThenBy(d => d.Name).ThenBy(d => d.Owner.Name).ToList();
            //return ordered.Values.SelectMany(d => d.Values).SelectMany(dog => dog.Values).Select(dogs => dogs).ToList();
        }
    }
}