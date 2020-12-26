using System;
using System.IO;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileName = "Input.txt";
            string outputFile = "Output.txt";
            string filePath = Path.Combine(path, fileName);
            using (var reader = new StreamReader(filePath))
            {
                int count = 0;
                string line = reader.ReadLine();
                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {
                    while (line != null)
                    {
                        line = $"{++count}. {line}";
                        Console.WriteLine(line);
                        writer.WriteLine(line);
                        
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
