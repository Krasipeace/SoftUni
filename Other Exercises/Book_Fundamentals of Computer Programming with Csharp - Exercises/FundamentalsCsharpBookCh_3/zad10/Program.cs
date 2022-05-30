using System;

namespace zad10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //10.   Напишете програма, която приема за вход четирицифрено число във формат abcd  (например числото 2011) и след това извършва следните действия върху него:
            //-Пресмята сбора от цифрите на числото(за нашия пример 2 + 0 + 1 + 1 = 4).
            //- Разпечатва на конзолата цифрите в обратен ред: dcba(за нашия пример резултатът е 1102).
            //- Поставя последната цифра, на първо място: dabc(за нашия пример резултатът е 1201).
            //- Разменя мястото на втората и третата цифра: acbd(за нашия пример резултатът е 2101).

            Console.Write("Enter a number with 4 digits and enjoy the Magic!: ");
            int inputNumber = int.Parse(Console.ReadLine());

            int digitFour = inputNumber % 10;
            int numberFour = inputNumber / 10;

            int digitThree = numberFour % 10;
            int numberThree = numberFour / 10;

            int digitTwo = numberThree % 10;
            int numberTwo = numberThree / 10;

            int digitOne = numberTwo % 10;
            int numberOne = numberTwo / 10;

            int digitSum = digitOne + digitTwo + digitThree + digitFour;
            Console.WriteLine(digitSum);

            Console.WriteLine($"{digitFour}{ digitThree}{ digitTwo}{ digitOne}");
            Console.WriteLine($"{digitFour}{digitOne}{digitTwo}{digitThree}");
            Console.WriteLine($"{digitOne}{digitThree}{digitTwo}{ digitFour}");

        }
    }
}
