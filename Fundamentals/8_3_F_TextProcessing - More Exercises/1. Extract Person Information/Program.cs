using System;

namespace _1._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string eachLine = Console.ReadLine();

                int nameStartIndex = eachLine.IndexOf('@') + 1;
                int nameLastIndex = eachLine.IndexOf('|');

                int ageStartIndex = eachLine.IndexOf('#') + 1;
                int ageLastIndex = eachLine.IndexOf('*');

                int lengthOfName = nameLastIndex - nameStartIndex;
                int lengthOfAge = ageLastIndex - ageStartIndex;

                string name = eachLine.Substring(nameStartIndex, lengthOfName);
                string age = eachLine.Substring(ageStartIndex, lengthOfAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
