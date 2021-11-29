using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class SectionIn
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SectionIn()
        {
        }

        public Section ToEntity() => new Section()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description
        };

    }
}