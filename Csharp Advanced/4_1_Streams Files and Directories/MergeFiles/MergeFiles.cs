namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstFileReader = new StreamReader(firstInputFilePath);
            var secondFileReader = new StreamReader(secondInputFilePath);
            var outputWriter = new StreamWriter(outputFilePath);

            using (outputWriter)
            {
                using (firstFileReader)
                {
                    using (secondFileReader)
                    {
                        string line1 = null;
                        string line2 = null;

                        while ((line1 = firstFileReader.ReadLine()) != null)
                        {
                            outputWriter.WriteLine(line1);
                            line2 = secondFileReader.ReadLine();

                            if (line2 != null)
                            {
                                outputWriter.WriteLine(line2);
                            }
                        }
                    }
                }
            }
        }
    }
}
