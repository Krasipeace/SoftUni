using System; //roman to arabic numbers
using System.Collections.Generic;
using System.Linq;

namespace Problem_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter roman number: ");
            char[] arr = Console.ReadLine().ToArray();

            int sum = 0;
            Dictionary<char, short> romanNumerics = new Dictionary<char, short>();
            romanNumerics.Add('M', 1000);
            romanNumerics.Add('C', 100);
            romanNumerics.Add('L', 50);
            romanNumerics.Add('X', 10);
            romanNumerics.Add('V', 5);
            romanNumerics.Add('I', 1);
            romanNumerics.Add('m', 1000);
            romanNumerics.Add('c', 100);
            romanNumerics.Add('l', 50);
            romanNumerics.Add('x', 10);
            romanNumerics.Add('v', 5);
            romanNumerics.Add('i', 1);

            int arabic = 0;

            for (int i = 0; i < arr.Count(); i++)
            {
                if (!romanNumerics.ContainsKey(arr[i]))
                {
                    Console.WriteLine($"Error! Such number ({arr[i]}) doesn't exist in Roman Numerics.");

                    return;
                }
                    

                if (i == arr.Count() - 1)
                {
                    arabic += romanNumerics[arr[i]];
                }
                else
                {
                    if (romanNumerics[arr[i + 1]] > romanNumerics[arr[i]])
                    {
                        arabic -= romanNumerics[arr[i]];
                    }
                    else
                    {
                        arabic += romanNumerics[arr[i]];
                    }
                }
            }
            Console.WriteLine($"Arabic number: {arabic}");
        }
    }
}
