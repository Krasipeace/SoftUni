namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] fileDataSize = File.ReadAllBytes(sourceFilePath);
            if (fileDataSize.Length % 2 == 0)
            {
                byte[] dataPartOne = new byte[fileDataSize.Length / 2];
                byte[] dataPartTwo = new byte[fileDataSize.Length / 2];

                for (int i = 0; i < dataPartOne.Length; i++)
                {
                    dataPartOne[i] = fileDataSize[i];
                }

                for (int j = fileDataSize.Length / 2; j < fileDataSize.Length; j++)
                {
                    dataPartTwo[j] = fileDataSize[j];
                }

                File.WriteAllBytes(partOneFilePath, dataPartOne);
                File.WriteAllBytes(partTwoFilePath, dataPartTwo);
            }
            else
            {
                byte[] dataPartOne = new byte[(fileDataSize.Length / 2) + 1];
                byte[] dataPartTwo = new byte[fileDataSize.Length / 2];

                for (int i = 0; i < dataPartOne.Length; i++)
                {
                    dataPartOne[i] = fileDataSize[i];
                }

                for (int j = (fileDataSize.Length / 2) + 1; j < fileDataSize.Length; j++)
                {
                    dataPartTwo[j] = fileDataSize[j];
                }

                File.WriteAllBytes(partOneFilePath, dataPartOne);
                File.WriteAllBytes(partTwoFilePath, dataPartTwo);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] dataPartOne = File.ReadAllBytes(partOneFilePath);
            byte[] dataPartTwo = File.ReadAllBytes(partTwoFilePath);
            byte[] mergedFile = new byte[dataPartOne.Length + dataPartTwo.Length];

            for (int i = 0; i < dataPartOne.Length; i++)
            {
                mergedFile[i] = dataPartOne[i];
            }

            for (int j = dataPartOne.Length; j < mergedFile.Length; j++)
            {
                mergedFile[j] = dataPartTwo[j];              
            }

            File.WriteAllBytes(joinedFilePath, mergedFile);
        }
    }
}