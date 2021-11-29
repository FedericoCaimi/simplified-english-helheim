using Domain;

namespace DataAccess.Interface
{
    public interface ISectionRepository : IRepository<Section>
    {
         bool Exists(string name);
    }
}
