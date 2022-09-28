using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person peter = new Person();
            peter.Name = "Peter";
            peter.Age = 20;
            Console.WriteLine(peter.Name);
            Console.WriteLine(peter.Age);

            Person george = new Person();
            george.Name = "George";
            george.Age = 18;
            Console.WriteLine(george.Name);
            Console.WriteLine(george.Age);

            Person jose = new Person();
            jose.Name = "Jose";
            jose.Age = 43;
            Console.WriteLine(jose.Name);
            Console.WriteLine(jose.Age);
        }
    }

    public class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
    }
}
