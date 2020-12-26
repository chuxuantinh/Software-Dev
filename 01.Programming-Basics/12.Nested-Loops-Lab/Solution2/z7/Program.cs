using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z7
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialFolderPath = @"C:\temp";
            var rootLevelFolders = Directory.GetDirectories(initialFolderPath);

            for (int currDirIndex = 0; currDirIndex < rootLevelFolders.Length; currDirIndex++)
            {
                Console.WriteLine($"----{rootLevelFolders[currDirIndex]}----");
                var subFolders = Directory.GetDirectories(rootLevelFolders[currDirIndex]);
                for (int currSubDirIndex = 0; currSubDirIndex < subFolders.Length; currSubDirIndex++)
                {
                    var fileNames = Directory.GetFiles(subFolders[currSubDirIndex]);
                    for (int fileNameIndex = 0; fileNameIndex < fileNames.Length; fileNameIndex++)
                    {
                        Console.WriteLine(fileNames[fileNameIndex]);
                    }

                    Console.WriteLine(subFolders[currSubDirIndex]);
                }
            }

            Console.WriteLine(rootLevelFolders);
        }
    }
}
