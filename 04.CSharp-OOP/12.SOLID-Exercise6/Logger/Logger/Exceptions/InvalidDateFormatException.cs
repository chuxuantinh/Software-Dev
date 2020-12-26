using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string ExceptionMessage = "Invalid DateTime format!";

        public InvalidDateFormatException() : base(ExceptionMessage)
        {
        }

        public InvalidDateFormatException(string message) : base(message)
        {
        }

        public InvalidDateFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
