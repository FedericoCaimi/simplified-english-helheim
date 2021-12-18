using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class SubSectionIn
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section {get; set; }

        public SubSectionIn()
        {
        }

        public SubSection ToEntity() => new SubSection()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Section = this.Section
        };

    }
}