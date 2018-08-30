using System.Collections.Generic;

namespace Blog.Core
{
    public interface IRepository<T, U>
    {
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T GetById(U id);
        List<T> List();
    }
}