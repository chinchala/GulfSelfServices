using System;

namespace SelfServices.Core.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage)
        {

        }
    }
}