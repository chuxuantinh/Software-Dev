using System;
using System.Collections.Generic;
using System.Text;

namespace P08MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string ExceptionMessage = "You cannot finish already completed mission!";

        public InvalidMissionCompletionException() : base(ExceptionMessage)
        {
        }

        public InvalidMissionCompletionException(string message) : base(message)
        {
        }
    }
}
