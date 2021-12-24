using System;
using System.Collections.Generic;
using Domain;
using BusinessLogic.Interface;
using DataAccess.Interface;
using System.Linq;
using Exceptions;

namespace BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private IUserRepository Repository;
        public UserLogic(IUserRepository repository)
        {
            this.Repository = repository;
        }

        public User Create(User user)
        {
            User newUser = new User()
            {
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
            };
            Repository.Add(newUser);
            Repository.Save();
            return newUser;
        }

        public User Get(int id)
        {
            return Repository.Get(id);
        }

        public IEnumerable<User> GetAll() => Repository.GetAll();

        public void Remove(int id)
        {
            User userFinded = Repository.Get(id);
            Repository.Remove(userFinded);
            Repository.Save();
        }

        public User Update(int id, User user)
        {
            if (id != user.Id) throw new IncorrectParamException("Id and object id doesnt match");

            User userToUpdate = this.Repository.Get(id);

            userToUpdate.Name = user.Name;
            if(!String.IsNullOrEmpty(user.Password)){
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
            }
            userToUpdate.Phone = user.Phone;

            Repository.Update(userToUpdate);
            Repository.Save();
            return user;
        }
    }
}