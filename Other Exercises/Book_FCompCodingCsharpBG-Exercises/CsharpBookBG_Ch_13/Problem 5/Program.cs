using System; //add * to text if its < length(20);
using System.Text;

namespace Problem_5 //task 7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine();
            int textLength = text.Length;
            const int MAX_LENGHT = 20;

            if (textLength > MAX_LENGHT)
            {
                Console.WriteLine("Error, text has more than 20 symbols!");

                return;
            }

            int specialLength = MAX_LENGHT - textLength; //ex. 5 >> ***** at the end 
            StringBuilder addStars = new StringBuilder(text);

            for (int i = 0; i < specialLength; i++)
            {
                addStars.Append('*');
            }

            Console.WriteLine($"New Text: {addStars}");

        }
    }
}
