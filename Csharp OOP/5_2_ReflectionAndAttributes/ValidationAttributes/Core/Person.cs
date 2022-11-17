namespace ValidationAttributes.Core
{
    using ValidationAttributes.Models;

    public class Person
    {
        public Person(string name, int age)
        {
            FullName = name;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }

        [MyRange(12,90)]
        public int Age { get; set; }
    }
}
