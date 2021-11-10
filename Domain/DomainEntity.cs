using System;

namespace Domain
{
    public abstract class DomainEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set;}
    }
}
