using System;
using Domain;

namespace WebApi.Models
{
    public class UserIn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public UserIn()
        {
        }

        public User ToEntity() => new User()
        {
            Id = this.Id,
            Name = this.Name,
            Email = this.Email,
            Password = this.Password,
            Phone = this.Phone,
            IsDeleted = this.IsDeleted,
        };

    }
}