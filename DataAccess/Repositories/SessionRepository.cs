using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain;
using Exceptions;
using DataAccess.Interface;
using System.Collections.Generic;

namespace DataAccess
{
    public class SessionRepository : ISessionRepository
    {
        protected DbContext Context { get; set; }
        public SessionRepository(DbContext context)
        {
            this.Context = context;
        }
        public Session Get(Guid id)
        {
            Session session = Context.Set<Session>().FirstOrDefault(x => x.Id == id);
            if (session == null) throw new DBKeyNotFoundException();
            return session;
        }

        public void Add(Session session)
        {
            if (exists(session.Id)) throw new DBKeyAlreadyExistsException();
            Context.Set<Session>().Add(session);
        }

        public void Remove(Session session)
        {
            if (!exists(session.Id)) throw new DBKeyNotFoundException();
            Context.Set<Session>().Remove(session);
        }

        public void Update(Session entity)
        {
            if (!exists(entity.Id)) throw new DBKeyNotFoundException();
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Session> GetAll()
        {
            return Context.Set<Session>();
        }

        public bool exists(Guid id)
        {
            return Context.Set<Session>().FirstOrDefault(x => x.Id == id) != null;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposingValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposingValue)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }
        }
        #endregion
    }
}