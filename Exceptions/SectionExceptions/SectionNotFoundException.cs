using System;

namespace Exceptions
{
    [Serializable]
    public class SectionNotFoundException : NotFoundException
    {
        public SectionNotFoundException()
        : base(String.Format("Section Id not found")) { }
    }
}
