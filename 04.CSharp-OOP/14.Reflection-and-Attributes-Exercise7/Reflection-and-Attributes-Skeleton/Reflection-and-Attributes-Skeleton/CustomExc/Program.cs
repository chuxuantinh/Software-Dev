using System;

namespace CustomExc
{
    public class Program
    {
        static void Main(string[] args)
        {
            throw new MyCustomException("");
        }
    }
}
