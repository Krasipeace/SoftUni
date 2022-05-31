using System;

namespace zad5
{
    class Program
    {
        static void Main(string[] args)
        {
            //5.Декларирайте променлива от тип char и присвоете като стойност символа който има Unicode код 72
            //(използвайте калкулатора на Windows за да намерите шестнайсетичното представяне на 72).

            char numSymbol = '\u0072';

            Console.WriteLine(numSymbol);
        }
    }
}