namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private readonly Dictionary<string, Dog> dogs;
        private readonly Dictionary<string, Dictionary<string, Dog>> ownersDogsByName;

        public DogVet()
        {
            this.dogs = new Dictionary<string, Dog>();
            this.ownersDogsByName = new Dictionary<string, Dictionary<string, Dog>>();
        }

        public int Size
            => this.dogs.Count;

        public bool Contains(Dog dog)
            => this.dogs.ContainsKey(dog.Id);

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.dogs.ContainsKey(dog.Id))
            {
                throw new ArgumentException();
            }

            if (this.ownersDogsByName.ContainsKey(owner.Id) && this.ownersDogsByName[owner.Id].ContainsKey(dog.Name))
            {
                throw new ArgumentException();
            }

            if (!this.ownersDogsByName.ContainsKey(owner.Id))
            {
                this.ownersDogsByName[owner.Id] = new Dictionary<string, Dog>();
            }

            dog.Owner = owner;
            this.ownersDogsByName[owner.Id][dog.Name] = dog;
            this.dogs.Add(dog.Id, dog);
        }


        public Dog GetDog(string name, string ownerId)
        {
            CheckIfOwnerOrDogExistAlready(name, ownerId);

            return this.ownersDogsByName[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            CheckIfOwnerOrDogExistAlready(name, ownerId);

            var dogToRemove = this.ownersDogsByName[ownerId][name];

            this.ownersDogsByName[ownerId].Remove(name);
            this.dogs.Remove(dogToRemove.Id);

            return dogToRemove;
        }

        public void Vaccinate(string name, string ownerId)
        {
            CheckIfOwnerOrDogExistAlready(name, ownerId);

            this.ownersDogsByName[ownerId][name].Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            CheckIfOwnerOrDogExistAlready(oldName, ownerId);

            var dogToRename = this.ownersDogsByName[ownerId][oldName];

            this.ownersDogsByName[ownerId].Remove(oldName);
            this.ownersDogsByName[ownerId][newName] = dogToRename;
            dogToRename.Name = newName;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.ownersDogsByName.ContainsKey(ownerId))
            {
                throw new ArgumentException();
            }

            return this.ownersDogsByName[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var dogsByBreed = this.dogs.Values.Where(d => d.Breed == breed);

            if (!dogsByBreed.Any())
            {
                throw new ArgumentException();
            }

            return dogsByBreed;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var dogsByAge = this.dogs.Values.Where(d => d.Age == age);

            if (!dogsByAge.Any())
            {
                throw new ArgumentException();
            }

            return dogsByAge;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
            => this.dogs.Values
                .Where(d => d.Age >= lo && d.Age <= hi)
                .ToList();

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
            => this.dogs.Values
                .OrderBy(d => d.Age)
                .ThenBy(d => d.Name)
                .ThenBy(d => d.Owner.Name)
                .ToList();

        private void CheckIfOwnerOrDogExistAlready(string name, string ownerId)
        {
            if (!this.ownersDogsByName.ContainsKey(ownerId) || !this.ownersDogsByName[ownerId].ContainsKey(name))
            {
                throw new ArgumentException();
            }
        }
    }
}