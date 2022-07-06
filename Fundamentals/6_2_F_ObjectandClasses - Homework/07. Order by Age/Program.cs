using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public override string ToString() => $"{Name} with ID: {ID} is {Age} years old.";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<Person> people = new List<Person>();

            while (command[0] != "End")
            {
                var person = new Person(command[0], command[1], int.Parse(command[2]));
                people.Add(person);

                command = Console.ReadLine().Split();
            }

            people.OrderBy(a => a.Age).ToList().ForEach(person => Console.WriteLine(person));
        }
    }
}
