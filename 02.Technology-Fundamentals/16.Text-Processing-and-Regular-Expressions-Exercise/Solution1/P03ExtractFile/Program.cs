using System;

namespace P03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);
            int startIndexOfExtension = file.IndexOf('.') + 1;
            string nameOfFile = file.Substring(0, startIndexOfExtension - 1);
            string extensionOfFile = file.Substring(startIndexOfExtension);
            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {extensionOfFile}");
        }
    }
}
