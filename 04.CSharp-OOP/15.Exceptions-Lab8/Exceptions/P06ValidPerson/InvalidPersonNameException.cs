using System;
using System.Collections.Generic;
using System.Text;

namespace P06ValidPerson
{
    public class InvalidPersonNameException : Exception
    {
        private const string ExceptionMessage = "The name contains special characters or digits";

        public InvalidPersonNameException()
            :base(ExceptionMessage)
        {
        }

        public InvalidPersonNameException(string message) : base(message)
        {
        }
    }
}
