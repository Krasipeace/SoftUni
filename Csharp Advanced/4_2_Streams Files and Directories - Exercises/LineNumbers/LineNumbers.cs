namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] allTextLines = File.ReadAllLines(inputFilePath);
            int lineCounter = 1;
            foreach (var (currentLine, letterCount, signsCount) in from currentLine in allTextLines
                                                                       let letterCount = currentLine.Count(char.IsLetter)
                                                                       let puncSignsCount = currentLine.Count(char.IsPunctuation)
                                                                       select (currentLine, letterCount, puncSignsCount))
            {
                File.AppendAllText(outputFilePath, $"Line {lineCounter}: {currentLine} ({letterCount})({signsCount})\n");
                lineCounter++;
            }
        }
    }
}
