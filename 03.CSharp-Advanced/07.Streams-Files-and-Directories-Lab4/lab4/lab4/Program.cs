using System;
using System.IO;
using System.Text;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileName = "Input.txt";
            string filePath = Path.Combine(path, fileName);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251")))
            {
                int count = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
