using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExc
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message)
            :base(message)
        {

        }
    }
}
