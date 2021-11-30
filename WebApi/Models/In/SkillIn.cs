using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class SkillIn
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SkillIn()
        {
        }

        public Skill ToEntity() => new Skill()
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description
        };

    }
}