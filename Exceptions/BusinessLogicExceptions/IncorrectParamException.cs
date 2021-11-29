using System;

namespace Exceptions
{
    [Serializable]
    public class IncorrectParamException : BadArgumentException
    {
        public IncorrectParamException(string message)
        : base(String.Format(message)) { }
    }
}
