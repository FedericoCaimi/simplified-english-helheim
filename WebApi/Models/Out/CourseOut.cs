using Domain;

namespace WebApi.Models
{
    public class CourseOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CourseOut(Course course)
        {
            Id = course.Id;
            Name = course.Name;
            Description = course.Description;
        }

    }
}