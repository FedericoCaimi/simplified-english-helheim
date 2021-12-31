using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interface;
using Domain;
using Exceptions;

namespace DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
        {
            this.Context = context;
        }
        public User GetByEmail(string mail)
        {
            if (!existsEmail(mail)) throw new DBIncorrectLoginException();
            return Context.Set<User>().FirstOrDefault(x => x.Email == mail);
        }
        public User GetByName(string name)
        {
            if (!existsName(name)) throw new DBNameNotFoundException();
            return Context.Set<User>().FirstOrDefault(x => x.Name == name);
        }
        public bool existsEmail(string mail)
        {
            return Context.Set<User>().FirstOrDefault(x => x.Email == mail) != null;
        }
        
        private bool existsName(string name)
        {
            return Context.Set<User>().FirstOrDefault(x => x.Name == name) != null;
        }
    }
}