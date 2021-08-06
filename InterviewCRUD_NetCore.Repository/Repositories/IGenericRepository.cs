using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InterviewCRUD_NetCore.Repository.Repositories
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}
