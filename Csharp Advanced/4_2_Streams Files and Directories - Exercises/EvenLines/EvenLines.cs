namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string[] specialSymbols = { "-", ",", ".", "!", "?" };
            StreamReader reader = new StreamReader(inputFilePath);
            string consoleOutput = string.Empty;

            using (reader)
            {
                int lineCounter = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (lineCounter % 2 == 0)
                    {                        
                        foreach (var charr in specialSymbols)
                        {
                            line = line.Replace(charr, "@");
                        }
                        consoleOutput += $"{string.Join(" ", line.Split().Reverse())}\n";
                    }
                    lineCounter++;
                }
            }

            return consoleOutput;
        }
    }
}
