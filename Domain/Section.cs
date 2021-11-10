using System;
using System.Collections.Generic;

namespace Domain
{
    public class Section : DomainEntity
    {
        public string Name {get; set; }
        public string Description { get; set; }


        public override bool Equals(object obj)
        {
            var section = obj as Section;
            return section != null &&
                   Name == section.Name;
        }
    }
}