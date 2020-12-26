using System;
using System.IO.Compression;

namespace P06ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picFolderPath = ".";
            string targetPath = "../../../result.zip";
            ZipFile.CreateFromDirectory(picFolderPath, targetPath);
            ZipFile.ExtractToDirectory(targetPath, "../../");
        }
    }
}
