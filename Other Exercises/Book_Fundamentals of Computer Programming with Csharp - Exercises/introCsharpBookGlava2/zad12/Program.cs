using System;

namespace zad12
{
    class Program
    {
        static void Main(string[] args)
        {
            //12.Фирма, занимаваща се с маркетинг, иска да пази запис с данни на нейните служители.
            //Всеки запис трябва да има следната характе­ристика – първо име, фамилия, възраст, пол (‘м’ или ‘ж’) и уникален номер на служителя(27560000 до 27569999).
            //Декларирайте необходи­мите променливи, нужни за да се запази информацията за един служи­тел, като използвате подходящи типове данни и описателни имена.

            Console.Write("First Name: ");
            string nameFirst = Console.ReadLine();
            Console.Write("Last Name: ");
            string nameSecond = Console.ReadLine();
            Console.Write("Age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("Gender (M/F): ");
            char gender = char.Parse(Console.ReadLine());
            Console.Write("Worker Number (27560000 - 27569999): ");
            long workerNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("name: " + nameFirst);
            Console.WriteLine("family: " + nameSecond);
            Console.WriteLine("age: " + age);
            Console.WriteLine("gender: " + gender);
            if (workerNumber >= 27560000 && workerNumber <= 27569999)
            {
                Console.WriteLine("Worker Number: " + workerNumber);
            }
            else
            {
                Console.WriteLine("No worker exists with such number!");                
            }

        }
    }
}