using System;

namespace FinancialDocument.Domain.Exceptions
{
    public class FinancialValidationException : Exception
    {
        public FinancialValidationException(string message): base(message)
        {
            //
        }

        public FinancialValidationException(string message, Exception innerException): base(message, innerException)
        {
            //
        }
    }

    public class FinancialInternalException : Exception
    {
        public FinancialInternalException(string message) : base(message)
        {
            //
        }

        public FinancialInternalException(string message, Exception innerException) : base(message, innerException)
        {
            //
        }
    }

    public class FinancialNotFoundException : Exception
    {
        public FinancialNotFoundException(string message) : base(message)
        {
            //
        }

        public FinancialNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            //
        }
    }
}
