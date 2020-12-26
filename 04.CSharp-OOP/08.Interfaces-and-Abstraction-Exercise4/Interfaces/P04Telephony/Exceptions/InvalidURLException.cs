using System;
using System.Collections.Generic;
using System.Text;

namespace P04Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string ExceptionMessage = "Invalid URL!";

        public InvalidURLException() : base(ExceptionMessage)
        {
            
        }


        public InvalidURLException(string message) : base(message)
        {
        }
    }
}
