using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string ExceptionMessage = "Invalid Level type!";

        public InvalidLevelTypeException() : base(ExceptionMessage)
        {
        }

        public InvalidLevelTypeException(string message) : base(message)
        {
        }
    }
}
