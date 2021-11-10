using System;
using System.Collections.Generic;

namespace Domain
{
    public class Skill : DomainEntity
    {
        public string Name {get; set; }
        public string Description { get; set; }


        public override bool Equals(object obj)
        {
            var skill = obj as Skill;
            return skill != null &&
                   Name == skill.Name;
        }
    }
}