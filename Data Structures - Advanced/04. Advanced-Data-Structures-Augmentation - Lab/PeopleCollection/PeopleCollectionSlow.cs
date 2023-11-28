namespace CollectionOfPeople
{
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleCollectionSlow : IPeopleCollection
    {
        private List<Person> people;

        public PeopleCollectionSlow()
        {
            this.people = new List<Person>();
        }

        public int Count => this.people.Count;

        /// <summary>
        /// Add Person to collection if not exist by email - Slow implementation
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        public bool Add(string email, string name, int age, string town)
        {
            if (this.Find(email) != null)
            {
                return false;
            }

            var person = new Person(email, name, age, town);
            this.people.Add(person);

            return true;
        }

        /// <summary>
        /// Delete person by email - Slow implementation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Delete(string email)
            => this.people.Remove(this.Find(email));

        /// <summary>
        /// Find person by email - Slow implementation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Person Find(string email)
            => this.people.FirstOrDefault(p => p.Email == email);

        /// <summary>
        /// Find People by email domain - Slow implementation
        /// </summary>
        /// <param name="emailDomain"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(string emailDomain)
            => this.people
                .Where(p => p.Email.EndsWith($"@{emailDomain}"))
                .OrderBy(p => p.Email);

        /// <summary>
        /// Find people by name and town - Slow implementation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(string name, string town)
            => this.people
                .Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);

        /// <summary>
        /// Find people by age range - Slow implementation
        /// </summary>
        /// <param name="startAge"></param>
        /// <param name="endAge"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);

        /// <summary>
        /// Find people by age range and town - Slow implementation
        /// </summary>
        /// <param name="startAge"></param>
        /// <param name="endAge"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
            => this.people
                .Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);
    }
}
