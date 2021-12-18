using System;
using System.Collections.Generic;

namespace Domain
{
    public class SubSection : DomainEntity
    {
        public string Name {get; set; }
        public string Description { get; set; }
        public Section Section {get; set; }


        public override bool Equals(object obj)
        {
            var subSection = obj as SubSection;
            return subSection != null &&
                   Name == subSection.Name;
        }
    }
}