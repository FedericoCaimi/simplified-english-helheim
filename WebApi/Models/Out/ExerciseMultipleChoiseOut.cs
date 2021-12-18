using System.Collections.Generic;
using Domain;

namespace WebApi.Models
{
    public class ExerciseMultipleChoiseOut
    {
        public int Id { get; set; }
        public Course Course {get; set; }
        public SubSection SubSection { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<Question> Questions {get; set; }
        public bool Optional { get; set; }

        public ExerciseMultipleChoiseOut(ExerciseMultipeChoise exercise)
        {
            Id = exercise.Id;
            Course = exercise.Course;
            SubSection = exercise.SubSection;
            Title = exercise.Title;
            Text = exercise.Text;
            Questions = exercise.Questions;
            Optional = exercise.Optional;
        }

    }
}