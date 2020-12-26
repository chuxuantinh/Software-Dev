using System;
using System.IO;
using System.IO.Compression;

namespace P06ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipFile = @"..\..\..\myZip.zip";
            var file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
                
            }
            ZipFile.ExtractToDirectory(zipFile, @"..\..\");

        }
    }
}
