using System;

namespace Exceptions
{
    [Serializable]
    public class IncorrectLoginException : BadLoginException
    {
        public IncorrectLoginException()
        : base(String.Format("Email or password are incorrect")) { }
    }
}
