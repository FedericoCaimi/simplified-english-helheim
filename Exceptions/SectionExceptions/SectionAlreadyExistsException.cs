using System;

namespace Exceptions
{
    [Serializable]
    public class SectionAlreadyExistsException : AlreadyExistsException
    {
        public SectionAlreadyExistsException()
        : base(String.Format("Section already exists in the system")) { }
    }
}
