using System;

namespace Exceptions
{
    [Serializable]
    public class SectionNamelreadyExistsException : AlreadyExistsException
    {
        public SectionNamelreadyExistsException()
        : base(String.Format("Section name already exists in the system")) { }
    }
}
