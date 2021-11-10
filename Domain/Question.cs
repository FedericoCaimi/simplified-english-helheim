using System;
using System.Collections.Generic;

namespace Domain
{
    public class Question: DomainEntity
    {
        public string Text {get; set; }
        public List<Option> Option { get; set; }

        public override bool Equals(object obj)
        {
            var question = obj as Question;
            return question != null &&
                   Text == question.Text;
        }
    }
}