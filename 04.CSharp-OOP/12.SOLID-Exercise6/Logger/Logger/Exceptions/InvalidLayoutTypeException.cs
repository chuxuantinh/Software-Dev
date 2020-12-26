using System;

namespace Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string ExceptionMessage = "Invalid Layout type!";

        public InvalidLayoutTypeException() : base(ExceptionMessage)
        {
        }

        public InvalidLayoutTypeException(string message) : base(message)
        {
        }
    }
}
