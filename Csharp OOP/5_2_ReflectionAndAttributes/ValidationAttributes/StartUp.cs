namespace ValidationAttributes
{
    using System;
    using ValidationAttributes.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Henry", 77);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
