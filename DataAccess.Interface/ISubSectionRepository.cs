using Domain;

namespace DataAccess.Interface
{
    public interface ISubSectionRepository : IRepository<SubSection>
    {
         bool Exists(string name);
    }
}
