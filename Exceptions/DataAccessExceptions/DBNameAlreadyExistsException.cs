using System;

namespace Exceptions
{
    [Serializable]
    public class DBNamelreadyExistsException : AlreadyExistsException
    {
        public DBNamelreadyExistsException()
        : base(String.Format("Name already exists in the system")) { }
    }
}
