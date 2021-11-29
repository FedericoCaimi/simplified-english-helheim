using System;

namespace Domain
{
    public abstract class DomainEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set;}
    }
}
