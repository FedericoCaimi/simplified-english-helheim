using System;
using System.Collections.Generic;

namespace DataAccess.Interface
{
    public interface IRepository<T> : IDisposable
    {
        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Save();

    }
}
