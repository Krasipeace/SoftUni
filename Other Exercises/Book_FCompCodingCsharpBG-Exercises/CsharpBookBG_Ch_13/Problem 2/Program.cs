using System; //correct (  )
using System.Text;

namespace Problem_2 //task 3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter arithmetic expression: ");
            string input = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input.IndexOf(')') == 0)
                {
                    Console.WriteLine("The brackets are incorrect!");

                    return;
                }

                if (input[i] == '(')
                {
                    counter++;
                }
                else if (input[i] == ')')
                {
                    counter--;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("The brackets are correct.");
            }
            else
            {
                Console.WriteLine("The brackets are incorrect!");
            }
        }
    }
}
