using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess.Interface
{
    public interface ISessionRepository: IDisposable
    {
         void Add(Session entity);

        void Remove(Session entity);

        void Update(Session entity);

        IEnumerable<Session> GetAll();

        Session Get(Guid id);

        void Save();
    }
}
