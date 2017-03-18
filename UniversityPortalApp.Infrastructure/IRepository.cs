using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityPortalApp.Core;

namespace UniversityPortalApp.Infrastructure
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll { get; }
        T InsertOrEdit(T entity);
        T GetById(int id);
        void Delete(int id);
        void DeleteAll(IEnumerable<T> entities);
    }
}
