using System;

namespace ExecutionControllerCore
{
    internal class ExecutionControllerException : Exception
    {
        public ExecutionControllerException()
        {
        }

        public ExecutionControllerException(string message) : base(message)
        {
        }

        public ExecutionControllerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}