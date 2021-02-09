using System;

namespace SelfServices.Core.Common.Exceptions
{
    public class CheckLimitException : Exception
    {
        private const string DefaultErrorCode = "reservationError";
        public string Code { get; }
        public CheckLimitException(string errorMessage) : base(errorMessage)
        {
            Code = extractErrorCode(errorMessage);
        }

        private string extractErrorCode(string errorMessage)
        {
            if (errorMessage.Contains("Unauthorized request  : IP") || errorMessage.Contains("NOT RESPONSE") || errorMessage.Contains("UNDEFINED ERROR"))
                return "internalError";
            return DefaultErrorCode;
        }
    }
}