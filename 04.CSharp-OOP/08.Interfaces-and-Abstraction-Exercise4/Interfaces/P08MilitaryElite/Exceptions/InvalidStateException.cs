using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string ExceptionMessage = "Invalid mission state!";

        public InvalidStateException() : base(ExceptionMessage)
        {
        }

        public InvalidStateException(string message) : base(message)
        {
        }
    }
}
