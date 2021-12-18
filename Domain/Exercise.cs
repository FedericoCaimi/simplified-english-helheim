using System;
using System.Collections.Generic;

namespace Domain
{
    public class Exercise : DomainEntity
    {
        public Course Course {get; set; }
        public SubSection SubSection { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Optional { get; set; }

        public override bool Equals(object obj)
        {
            var exercise = obj as Exercise;
            return exercise != null &&
                   Course.Id == exercise.Course.Id &&
                   SubSection.Id == exercise.SubSection.Id &&
                   Title == exercise.Title;
        }
    }
}