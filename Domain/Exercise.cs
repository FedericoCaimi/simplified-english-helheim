using System;
using System.Collections.Generic;

namespace Domain
{
    public class Exercise : DomainEntity
    {
        public Course Course {get; set; }
        public Section Section { get; set; }
        public Skill Skill { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public override bool Equals(object obj)
        {
            var exercise = obj as Exercise;
            return exercise != null &&
                   Course.Id == exercise.Course.Id &&
                   Skill.Id == exercise.Skill.Id &&
                   Title == exercise.Title;
        }
    }
}