using System;
using System.Collections.Generic;
using Domain;

namespace BusinessLogic.Interface
{
    public interface IAuthenticationLogic
    {
        Session Login(User user);
        void Logout(Guid userId);
        bool IsLoggedIn(Guid token);
        bool IsAuthorized(Guid token, List<string> rols);
        bool IsLoggedInAndAuthorized(Guid token, string rol);
        IEnumerable<Session> GetAll();
        Session Get(Guid id);
    }
}