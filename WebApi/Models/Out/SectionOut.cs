using Domain;

namespace WebApi.Models
{
    public class SectionOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SectionOut(Section section)
        {
            Id = section.Id;
            Name = section.Name;
            Description = section.Description;
        }

    }
}