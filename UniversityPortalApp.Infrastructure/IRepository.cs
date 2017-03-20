using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UniversityPortalApp.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll { get; }
        T InsertOrEdit(T entity);
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Delete(int id);
        void DeleteAll(IEnumerable<T> entities);
    }
}
