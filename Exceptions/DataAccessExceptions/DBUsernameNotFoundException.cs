using System;

namespace Exceptions
{
    [Serializable]
    public class DBNameNotFoundException : NotFoundException
    {
        public DBNameNotFoundException()
        : base(String.Format("Name not found")) { }
    }
}
