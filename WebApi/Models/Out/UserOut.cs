using System;
using Domain;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class UserOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Course Course { get; set; }
        public string Rol { get; set; }
        public bool IsDeleted { get; set; }

        public UserOut(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Phone = user.Phone;
            Course = user.Course;
            Rol = user.Rol;
            IsDeleted = user.IsDeleted;
        }

    }
}