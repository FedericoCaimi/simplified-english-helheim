using System;

namespace Exceptions
{
    [Serializable]
    public abstract class NotFoundException : Exception
    {
        public NotFoundException(string message = "")
        : base(String.Format(message)) { }
    }
}
