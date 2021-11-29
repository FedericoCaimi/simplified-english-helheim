using Domain;

namespace DataAccess.Interface
{
    public interface ICourseRepository : IRepository<Course>
    {
         bool Exists(string name);
    }
}
