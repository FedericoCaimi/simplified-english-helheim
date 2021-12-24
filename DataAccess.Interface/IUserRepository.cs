using Domain;

namespace DataAccess.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string mail);
        User GetByName(string Name);
    }
}