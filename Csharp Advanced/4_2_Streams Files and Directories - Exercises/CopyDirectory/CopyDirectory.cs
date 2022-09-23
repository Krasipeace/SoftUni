namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            foreach (string dirPath in Directory.GetDirectories(inputPath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(inputPath, outputPath));
            }

            foreach (string newPath in Directory.GetFiles(inputPath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(inputPath, outputPath), true);
            }
        }
    }
}
