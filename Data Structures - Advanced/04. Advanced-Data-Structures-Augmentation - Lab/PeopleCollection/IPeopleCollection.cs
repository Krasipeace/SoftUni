namespace CollectionOfPeople
{
    using System.Collections.Generic;

    public interface IPeopleCollection
    {
        bool Add(string email, string name, int age, string town);
        int Count { get; }
        Person Find(string email);
        bool Delete(string email);
        IEnumerable<Person> FindPeople(string emailDomain);
        IEnumerable<Person> FindPeople(string name, string town);
        IEnumerable<Person> FindPeople(int startAge, int endAge);
        IEnumerable<Person> FindPeople(int startAge, int endAge, string town);
    }
}
