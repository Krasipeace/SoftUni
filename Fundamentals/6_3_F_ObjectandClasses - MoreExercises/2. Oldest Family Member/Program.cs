using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                family.AddMemberToFamily(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries));
            }
            Person oldestMember = family.OldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Family
    {
        public List<Person> MembersOfFamily { get; set; } = new List<Person>();
        public Person OldestMember()
        {
            return MembersOfFamily.OrderByDescending(eachMember => eachMember.Age).First();
        }
        public void AddMemberToFamily(string[] memberInfo)
        {
            string name = memberInfo[0];
            int age = int.Parse(memberInfo[1]);

            Person newMember = new Person(name, age);
            MembersOfFamily.Add(newMember);
        }
    }
}
