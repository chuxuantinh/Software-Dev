using System;
using System.Collections.Generic;
using System.Text;

namespace SandBox
{
    public static class Splitter
    {
        public static string[] MySplit(this string content)
        {
            return content.Split(new char[] { ' ', '-' });
        }
    }
}
