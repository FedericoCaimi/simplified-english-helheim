using Domain;

namespace WebApi.Models
{
    public class SubSectionOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section {get; set; }

        public SubSectionOut(SubSection section)
        {
            Id = section.Id;
            Name = section.Name;
            Description = section.Description;
            Section = section.Section;
        }

    }
}