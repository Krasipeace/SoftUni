namespace CollectionOfPeople
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class PeopleCollection : IPeopleCollection
    {
        private Dictionary<string, Person> peopleByEmail;
        private Dictionary<string, SortedSet<Person>> peopleByEmailDomain;
        private Dictionary<(string name, string town), SortedSet<Person>> peopleByNameAndTown;
        private OrderedDictionary<int, SortedSet<Person>> peopleByAge;
        private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge;

        public PeopleCollection()
        {
            this.peopleByEmail = new Dictionary<string, Person>();
            this.peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
            this.peopleByNameAndTown = new Dictionary<(string, string), SortedSet<Person>>();
            this.peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
            this.peopleByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public int Count => this.peopleByEmail.Count;

        /// <summary>
        /// Add Person to collection if not exist by email - Fast implementation
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(string email, string name, int age, string town)
        {
            if (this.Find(email) != null)
            {
                return false;
            }

            var person = new Person(email, name, age, town);
            this.peopleByEmail.Add(email, person);
            this.peopleByEmailDomain.AppendValueToKey(email.Split('@')[1], person);
            this.peopleByNameAndTown.AppendValueToKey((name, town), person);
            this.peopleByAge.AppendValueToKey(age, person);
            this.peopleByTownAndAge.EnsureKeyExists(town);
            this.peopleByTownAndAge[town].AppendValueToKey(age, person);

            return true;
        }

        /// <summary>
        /// Delete person by email - Fast implementation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Delete(string email)
        {
            var person = this.Find(email);
            if (person == null)
            {
                return false;
            }

            this.peopleByEmailDomain[email.Split("@")[1]].Remove(person);
            this.peopleByNameAndTown[(person.Name, person.Town)].Remove(person);
            this.peopleByAge[person.Age].Remove(person);
            this.peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return this.peopleByEmail.Remove(email);
        }

        /// <summary>
        /// Find person by email - Fast implementation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Person Find(string email)     
            => this.peopleByEmail.ContainsKey(email) 
                ? this.peopleByEmail[email] 
                : null;       

        /// <summary>
        /// Find people by email domain - Fast implementation
        /// </summary>
        /// <param name="emailDomain"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(string emailDomain)
            => this.peopleByEmailDomain.GetValuesForKey(emailDomain);

        /// <summary>
        /// Find people by name and town - Fast implementation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(string name, string town)
            => this.peopleByNameAndTown.GetValuesForKey((name, town));

        /// <summary>
        /// Find people by age range - Fast implementation
        /// </summary>
        /// <param name="startAge"></param>
        /// <param name="endAge"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => this.peopleByAge
                .Range(startAge, true, endAge, true)
                .SelectMany(p => p.Value)
                .OrderBy(p => p.Age);

        /// <summary>
        /// Find people by age range and town - Fast implementation
        /// </summary>
        /// <param name="startAge"></param>
        /// <param name="endAge"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
            => this.peopleByTownAndAge.ContainsKey(town)
                ? this.peopleByTownAndAge[town]
                    .Range(startAge, true, endAge, true)
                    .SelectMany(p => p.Value)
                    .OrderBy(p => p.Age)
                : Enumerable.Empty<Person>();
    }
}
