using System;

namespace zad7
{
    class Program
    {
        static void Main(string[] args) 
        {
            //7.Декларирайте две променливи от тип string със стойности "Hello" и "World".
            //Декларирайте променлива от тип object. Присвоете на тази променлива стойността, която се получава от конкатенацията на двете стрингови променливи
            //(добавете интервал, ако е необходимо). Отпе­чатайте променливата от тип object.

            string wordFirst = "Hello";
            string wordSecond = "World";
            object sentenceWords = wordFirst + " " + wordSecond;
            Console.WriteLine(sentenceWords);
        }
    }
}