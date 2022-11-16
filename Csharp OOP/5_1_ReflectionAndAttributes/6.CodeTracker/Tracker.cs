namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (var (method, attr) in from MethodInfo method in methods
                                                where method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute))
                                                let attributes = method.GetCustomAttributes(false)
                                                from AuthorAttribute attribute in attributes
                                                select (method, attribute))
            {
                Console.WriteLine($"{method.Name} is written by {attr.Name}");
            }
        }
    }
}