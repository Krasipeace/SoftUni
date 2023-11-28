namespace CollectionOfPeople
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Person : IComparable<Person>
    {
        public Person(string email, string name, int age, string town)
        {
            this.Email = email;
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)       
            => this.Email.CompareTo(other.Email);        
    }
}
