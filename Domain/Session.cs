using System;

namespace Domain
{
    public class Session
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateLogged { get; set; }
        public bool IsDeleted { get; set;}
        public Session() : base() { }
    }
}