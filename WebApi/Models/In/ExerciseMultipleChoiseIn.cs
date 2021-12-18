using System;
using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class ExerciseMultipleChoiseIn
    {
        public int Id { get; set; }
        public Course Course {get; set; }
        public SubSection SubSection { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Question> Questions {get; set; }
        public bool Optional { get; set; }

        public ExerciseMultipleChoiseIn()
        {
        }

        public ExerciseMultipeChoise ToEntity() => new ExerciseMultipeChoise()
        {
            Id = this.Id,
            Course = this.Course,
            SubSection = this.SubSection,
            Title = this.Title,
            Text = this.Text,
            Questions = this.Questions,
            Optional = this.Optional
        };

    }
}