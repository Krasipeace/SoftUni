using System;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();

            string command = Console.ReadLine();
            while (command != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = string.Empty;

                if (tokens.Length > 2)
                {
                    gender = tokens[2];
                }

                switch (command)
                {
                    case "Cat":
                        {
                            Cat cat = new Cat(name, age, gender);
                            output.AppendLine(cat.ToString());
                            break;
                        }
                    case "Dog":
                        {
                            Dog dog = new Dog(name, age, gender);
                            output.AppendLine(dog.ToString());
                            break;
                        }
                    case "Frog":
                        {
                            Frog frog = new Frog(name, age, gender);
                            output.AppendLine(frog.ToString());
                            break;
                        }
                    case "Tomcat":
                        {
                            Tomcat tomcat = new Tomcat(name, age);
                            output.AppendLine(tomcat.ToString());
                            break;
                        }
                    case "Kitten":
                        {
                            Kitten kitten = new Kitten(name, age);
                            output.AppendLine(kitten.ToString());
                            break;
                        }
                    default:
                        throw new ArgumentException("Invalid input!");                       
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}
