using System;

namespace Exceptions
{
    [Serializable]
    public abstract class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message = "")
        : base(String.Format(message)) { }
    }
}
