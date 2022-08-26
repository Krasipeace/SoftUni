﻿namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                string line = reader.ReadLine();
                int counter = 1;
                var writer = new StreamWriter(outputFilePath);
                while (line != null)
                {
                    writer.WriteLine($"{counter}. {line}");
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}
