using System;

namespace zad8
{
    class Program
    {
        static void Main(string[] args)
        {
            //8. Декларирайте две променливи от тип string и им присвоете стойности "Hello" и "World".
            //Декларирайте променлива от тип object и и присвоете стойността на конкатенацията на двете променливи от тип string (не изпускайте интервала по средата).
            //Декларирайте трета променлива от тип string и я инициализирайте със стойността на променливата от тип object ( трябва да използвате type casting).

            string wordFirst = "Hello";
            string wordSecond = "World";
            object words = String.Format(wordFirst + " " + wordSecond);
            string wordsResult = (string)words;

            Console.WriteLine(wordsResult);
        }
    }
}
