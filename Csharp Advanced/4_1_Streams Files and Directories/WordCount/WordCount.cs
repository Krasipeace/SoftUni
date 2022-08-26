namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount  //unfinished
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var textReader = new StreamReader(textFilePath);
            var wordReader = new StreamReader(wordsFilePath);

            var wordsCounter = new Dictionary<string, int>();

            using (wordReader)
            {
                string line = wordReader.ReadLine();

                while (line != null)
                {
                    string[] lineWords = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < lineWords.Length; i++)
                    {
                        lineWords[i] = lineWords[i].ToLower();

                        if (!(wordsCounter.ContainsKey(lineWords[i])))
                        {
                            wordsCounter.Add(lineWords[i], 0);
                        }
                    }
                    line = wordReader.ReadLine();
                }
            }

            var outputWriter = new StreamWriter(outputFilePath);

            using (textReader)
            {
                string lineText = textReader.ReadLine().ToLower();

                while (lineText != null)
                {
                    string[] lineTextSplited = lineText.Split(new char[] {' ', '\n', '.', '!', '?', '-', ','}, StringSplitOptions.RemoveEmptyEntries);

                    for (int splittedWord = 0; splittedWord < lineTextSplited.Length; splittedWord++)
                    {
                        lineTextSplited[splittedWord] = lineTextSplited[splittedWord].ToLower();

                        if (wordsCounter.ContainsKey(lineTextSplited[splittedWord]))
                        {
                            wordsCounter[lineTextSplited[splittedWord]] += 1;
                        }
                    }

                    lineText = textReader.ReadLine();
                }

                foreach (var kvp in wordsCounter.OrderByDescending(k => k.Value))
                {
                    outputWriter.WriteLine($"{kvp.Key} - {kvp.Value}");  
                }
            }
        }
    }
}
