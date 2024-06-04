namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            inputFolderPath = "./";
            string[] files = Directory.GetFiles(inputFolderPath);
            SortedDictionary<string, List<FileInfo>> dictionary = new SortedDictionary<string, List<FileInfo>>();

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dictionary.ContainsKey(fileInfo.Extension))
                {
                    dictionary.Add(fileInfo.Extension, new List<FileInfo>());
                }
                dictionary[fileInfo.Extension].Add(fileInfo);
            }

            var orderedExtensions = dictionary.OrderByDescending(x => x.Value.Count);

            StringBuilder sb = new StringBuilder();

            foreach (var extensionFiles in orderedExtensions)
            {
                sb.AppendLine(extensionFiles.Key);
                var orderedFiles = extensionFiles.Value.OrderByDescending(x => x.Length);

                foreach (var file in orderedFiles)
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
