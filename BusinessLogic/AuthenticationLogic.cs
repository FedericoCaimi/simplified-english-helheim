using System.Collections;
using System;
using System.Collections.Generic;
using Domain;
using DataAccess.Interface;
using BusinessLogic.Interface;
using Exceptions;

namespace BusinessLogic
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        private ISessionRepository SessionRepository { get; set; }
        private IUserRepository UserRepository { get; set; }

        public AuthenticationLogic(ISessionRepository sessionRepository)
        {
            this.SessionRepository = sessionRepository;
        }

        public AuthenticationLogic(ISessionRepository sessionRepository, IUserRepository adminRepository)
        {
            this.SessionRepository = sessionRepository;
            this.UserRepository = adminRepository;
        }

        public Session Login(User user)
        {
            if (user.Email == null || user.Password == null)
            {
                throw new IncorrectParamException("Email and password is needed to login");
            }
            var DBuser = UserRepository.GetByEmail(user.Email);
            if (!isCorrectLogin(DBuser, user))
            {
                throw new IncorrectLoginException();
            }
            var newSession = new Session
            {
                UserId = DBuser.Id,
                DateLogged = DateTime.Now,
            };

            SessionRepository.Add(newSession);
            SessionRepository.Save();
            return newSession;
        }

        private bool isCorrectLogin(User DBuser, User user)
        {
            return (DBuser.Email == user.Email && DBuser.Password == user.Password);
        }

        public void Logout(Guid token)
        {
            if (token == Guid.Empty)
            {
                throw new IncorrectParamException("Invalid token");
            }
            var session = SessionRepository.Get(token);
            SessionRepository.Remove(session);
            SessionRepository.Save();
        }

        public IEnumerable<Session> GetAll() => SessionRepository.GetAll();

        public Session Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new IncorrectParamException("Invalid id");
            }                
            return SessionRepository.Get(id);
        }

        public bool IsLoggedIn(Guid token)
        {
            var session = SessionRepository.Get(token);
            var loggedOutToken = session.IsDeleted;
            var dueDate = session.DateLogged.AddHours(6);
            var validToken = DateTime.Now < dueDate;
            return !loggedOutToken && validToken;
        }

        public bool IsAuthorized(Guid token, List<string> rols)
        {
            var session = SessionRepository.Get(token);
            var user = UserRepository.Get(session.UserId);
            return rols.Contains(user.Rol);
        }

        public bool IsLoggedInAndAuthorized(Guid token, string rol)
        {
            var session = SessionRepository.Get(token);
            var loggedOutToken = session.IsDeleted;
            var dueDate = session.DateLogged.AddHours(6);
            var validToken = DateTime.Now < dueDate;
            if(!loggedOutToken && validToken){
                var user = UserRepository.Get(session.UserId);
                return rol == user.Rol;
            }
            return !loggedOutToken && validToken;
        }
    }
}