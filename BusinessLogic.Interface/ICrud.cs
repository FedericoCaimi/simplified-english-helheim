using System.Collections.Generic;

namespace BusinessLogic.Interface
{
    public interface ICrud<T>
    {
        T Create(T entity);
        void Remove(int id);
        T Update(int id, T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}