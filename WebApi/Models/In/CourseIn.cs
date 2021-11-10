using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class CourseIn
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CourseIn()
        {
        }

        public Course ToEntity() => new Course()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description
        };

    }
}