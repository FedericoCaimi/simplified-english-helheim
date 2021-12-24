using Domain;
using System;

namespace WebApi.Models
{
    public class AuthenticationIn
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AuthenticationIn()
        {
        }

        public User ToEntity() => new User()
        {
            Email = this.Email,
            Password = this.Password,
        };

    }
}