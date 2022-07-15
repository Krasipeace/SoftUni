using System;

namespace _3._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int lastBackslash = (input.LastIndexOf('\\')) + 1;
            int indexDot = input.IndexOf('.');

            int lengthOfFileName = indexDot - lastBackslash;

            string fileName = input.Substring(lastBackslash, lengthOfFileName);
            string fileExtension = input.Substring(indexDot + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
