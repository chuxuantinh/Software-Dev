using System;
using System.IO;
using System.Text;

namespace P04
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileOneName = "FileOne.txt";
            string fileTwoName = "FileTwo.txt";
            string outputFile = "Output.txt";
            string fileOnePath = Path.Combine(path, fileOneName);
            string fileTwoPath = Path.Combine(path, fileTwoName);
            using (var readerOne = new StreamReader(fileOnePath))
            {
                using (var readerTwo = new StreamReader(fileTwoPath))
                {
                    
                    string[] one = readerOne.ReadToEnd().Split(Environment.NewLine);
                    string[] two = readerTwo.ReadToEnd().Split(Environment.NewLine);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Math.Min(one.Length, two.Length); i++)
                    {
                        sb.AppendLine(one[i]);
                        sb.AppendLine(two[i]);
                    }
                    using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                    {
                        writer.Write(sb);
                    }
                }

            }
        }
    }
}
