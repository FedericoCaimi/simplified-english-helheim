using System;

namespace Exceptions
{
    [Serializable]
    public class DBKeyNotFoundException : NotFoundException
    {
        public DBKeyNotFoundException()
        : base(String.Format("Id not found")) { }
    }
}
