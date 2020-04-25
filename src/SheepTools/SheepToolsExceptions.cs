using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SheepTools
{
    [Serializable]
    public class SheepToolsException : Exception
    {
        public SheepToolsException()
        {
        }

        public SheepToolsException(string message) : base(message)
        {
        }

        public SheepToolsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SheepToolsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
