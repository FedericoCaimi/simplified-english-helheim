using System;

namespace Exceptions
{
    [Serializable]
    public class UserAlreadyExistsException : AlreadyExistsException
    {
        public UserAlreadyExistsException()
        : base(String.Format("User already exists in the system")) { }
    }
}
