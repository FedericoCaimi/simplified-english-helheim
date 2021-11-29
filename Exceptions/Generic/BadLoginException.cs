using System;

namespace Exceptions
{
    [Serializable]
    public abstract class BadLoginException : Exception
    {
        public BadLoginException(string message = "")
        : base(String.Format(message)) { }
    }
}
