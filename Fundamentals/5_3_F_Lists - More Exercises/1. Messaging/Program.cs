using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Messaging
{
    internal class Program
    {
        //Ще ви бъде даден списък с числа и низ. За всеки елемент от списъка трябва да изчислите сумата от неговите цифри и да вземете елемента,
        //съответстващ на този индекс от текста. Ако индексът е по-голям от дължината на текста, започнете да броите от началото (така че винаги да имате валиден индекс).
        //След като получите този елемент от текста, трябва да премахнете знака, който сте взели от него (така че за следващия индекс текстът ще бъде с един безсимволен).

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int index = CalculateIndex(currentNumber);
                char currentChar = CalculateChar(index, message);

                Console.Write(currentChar);

                int realIndex = CalculateRealIndex(index, message);
                string newMessage = message.Remove(realIndex, 1);
                message = newMessage;
            }
            Console.WriteLine();
        }

        static int CalculateRealIndex(int index, string message)
        {
            int countIndex = 0;

            for (int i = 0; i < index; i++)
            {
                countIndex++;
                if (countIndex == message.Length)
                {
                    countIndex = 0;
                }
            }
            return countIndex;
        }

        static char CalculateChar(int index, string message)
        {
            int countIndex = 0;

            for (int i = 0; i < index; i++)
            {
                countIndex++;

                if (countIndex == message.Length)
                {
                    countIndex = 0;
                }
            }
            char currentChar = message[countIndex];
            return currentChar;
        }

        static int CalculateIndex(int number)
        {
            int index = 0;
            while (number > 0)
            {
                int currentNumber = number % 10;
                index += currentNumber;
                number /= 10;
            }
            return index;
        }
    }
}