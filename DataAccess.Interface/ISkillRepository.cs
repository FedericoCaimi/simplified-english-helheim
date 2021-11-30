using Domain;

namespace DataAccess.Interface
{
    public interface ISkillRepository : IRepository<Skill>
    {
         bool Exists(string name);
    }
}
