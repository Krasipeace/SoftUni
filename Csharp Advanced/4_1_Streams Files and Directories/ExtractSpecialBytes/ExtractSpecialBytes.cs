namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractSpecialBytes //unfinished
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using StreamReader streamReader = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            var bytesList = new List<String>();
            var stringBuilder = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                bytesList.Add(streamReader.ReadLine());
            }

            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    stringBuilder.AppendLine(Convert.ToString(item, 16));
                }
            }

            using StreamWriter output = new StreamWriter(outputPath);
            output.WriteLine(stringBuilder.ToString().Trim().ToUpper());         
        }
    }
}
