using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes("Hello GZIP")))
            {
                using (FileStream fs = new FileStream("test.gz", FileMode.Create))
                {
                    using (GZipStream gz = new GZipStream(fs, CompressionLevel.Optimal))
                    {
                        ms.CopyTo(fs);
                    }
                }
            }
        }
    }
}
