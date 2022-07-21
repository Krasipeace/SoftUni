using System;
using Problem_7.Examples;

namespace Problem_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }



    public class Cat
    {
        // Field name
        private string name;

        // Field color
        private string color;

        public string Name
        {
            // Getter of the property "Name"
            get
            {
                return this.name;
            }
            // Setter of the property "Name"
            set

            {
                this.name = value;
            }
        }

        public string Color
        {
            // Getter of the property "Color"
            get
            {
                return this.color;
            }

            // Setter of the property "Color"
            set
            {
                this.color = value;
            }
        }

        // Default constructor
        public Cat()
        {
            this.name = "Unnamed";

            this.color = "gray";
        }

        // Constructor with parameters
        public Cat(string name, string color)
        {
            this.name = name;

            this.color = color;
        }

        // Method SayMiau
        public void SayMiau()
        {
            Console.WriteLine("Cat {0} said: MEOWWWW!", name);
        }

    }

    public class Sequence
    {
        // Static field, holding the current sequence value
        private static int currentValue = 0;
        // Intentionally deny instantiation of this class
        private Sequence()
        {

        }

        // Static method for taking the next sequence value
        public static int NextValue()
        {
            currentValue++;

            return currentValue;
        }

    }
}
