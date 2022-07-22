using System; //  <upcase> to UPPER_LETTERS </upcase>
using System.Text.RegularExpressions;

namespace Problem_4 //task 6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any text: ");
            string text = Console.ReadLine();

            Regex regex = new Regex(@"<upcase>(.*?)</upcase>");
            Console.WriteLine(regex.Replace(text, m => m.Groups[1].ToString().ToUpper()));
        }
    }
}
