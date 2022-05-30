using System;

namespace zad11
{
    class Program
    {
        static void Main(string[] args)
        {
            //11.Напишете програма, която принтира на конзолата равнобедрен триъгълник, като страните му са очертани от символа звездичка "©".

            System.Text.Encoding uTF8 = System.Text.Encoding.UTF8;
            System.Console.OutputEncoding = uTF8;

            char c = '\u00a9';

            Console.WriteLine($"         {c}");
            Console.WriteLine("        © ©");
            Console.WriteLine("       ©   ©");
            Console.WriteLine("      ©     ©");
            Console.WriteLine("     ©       ©");
            Console.WriteLine("    ©         ©");
            Console.WriteLine("   ©           ©");
            Console.WriteLine("  ©             ©");
            Console.WriteLine(" ©               ©");
            Console.WriteLine("© © © © © © © © © ©");

        }
    }
}