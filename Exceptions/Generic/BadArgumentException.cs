using System;

namespace Exceptions
{
    [Serializable]
    public abstract class BadArgumentException : Exception
    {
        public BadArgumentException(string message = "")
        : base(String.Format(message)) { }
    }
}
