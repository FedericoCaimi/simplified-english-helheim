using Domain;

namespace WebApi.Models
{
    public class SkillOut
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public SkillOut(Skill section)
        {
            Id = section.Id;
            Name = section.Name;
            Description = section.Description;
        }

    }
}