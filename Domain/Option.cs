using System;
using System.Collections.Generic;

namespace Domain
{
    public class Option : DomainEntity
    {
        public string Text {get; set; }
        public Boolean IsCorrect { get; set; }


        public override bool Equals(object obj)
        {
            var option = obj as Option;
            return option != null &&
                   Text == option.Text;
        }
    }
}