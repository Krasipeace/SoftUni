using System;
using System.Linq;
using System.Text;

namespace _3._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string text = Console.ReadLine();

            string resource = string.Empty;
            string coordinates = string.Empty;

            while (true)
            {
                if (text == "find")
                {
                    break;
                }

                int maxLength = Math.Max(keys.Length, text.Length);
                StringBuilder newText = new StringBuilder(maxLength);

                for (int i = 0; i < maxLength; i++)
                {
                    newText.Append((char)(text[i] - keys[i % keys.Length]));
                }

                int startIndexResource = newText.ToString().IndexOf('&') + 1;
                int lastIndexResource = newText.ToString().IndexOf('&', startIndexResource + 1);
                int resourceLength = lastIndexResource - startIndexResource;

                resource = newText.ToString().Substring(startIndexResource, resourceLength);

                int startIndexCoordinates = newText.ToString().IndexOf('<') + 1;
                int lastIndexCoordinates = newText.ToString().IndexOf('>');
                int coordinatesLength = lastIndexCoordinates - startIndexCoordinates;

                coordinates = newText.ToString().Substring(startIndexCoordinates, coordinatesLength);

                Console.WriteLine($"Found {resource} at {coordinates}");

                text = Console.ReadLine();
            }
        }
    }
}
