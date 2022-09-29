using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person = new Person();
            Person person2 = new Person(age)
            {
                Age = age
            };
            Person person3 = new Person(name, age)
            {
                Name = name,
                Age = age
            };

            Console.WriteLine($"{person.Name} {person.Age}");
            Console.WriteLine($"{person2.Name} {person2.Age}");
            Console.WriteLine($"{person3.Name} {person3.Age}");

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person ()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person (int age)
        {
            Name = "No name";
            Age = age;
        }
        public Person (string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
