using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string ExceptionMessage = "Invalid corps!";

        public InvalidCorpsException() : base(ExceptionMessage)
        {

        }

        public InvalidCorpsException(string message) : base(message)
        {
        }
    }
}
