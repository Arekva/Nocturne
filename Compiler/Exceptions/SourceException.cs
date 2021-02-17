using System;

namespace Nocturne
{
    public class SourceException : Exception
    {
        public SourceException(string message) : base(message) {}
        public SourceException(string message, Exception innerException) : base(message, innerException) {}
    }
}