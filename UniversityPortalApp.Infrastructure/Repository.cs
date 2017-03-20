using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UniversityPortalApp.Core;
using UniversityPortalApp.Data;

namespace UniversityPortalApp.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private UniversityContext context;
        public Repository() { }
        public Repository(UniversityContext _context)
        {
            this.context = _context;
        }
        public IQueryable<T> GetAll
        {
            get
            {
                return this.context.Set<T>();//.ToList();
            }
        }

        public void Delete(int id)
        {
            this.context.Entry<T>(this.GetById(id)).State = System.Data.Entity.EntityState.Deleted;
            this.context.SaveChanges();
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            foreach(var entity in entities)
            {
                this.context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
                this.context.SaveChanges();
            }
        }

        public T GetById(int id)
        {
            return this.context.Set<T>().Where(t => t.Id == id).FirstOrDefault();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where(predicate);
        }

        public T InsertOrEdit(T entity)
        {
            try
            {
                this.context.Entry<T>(entity).State = (entity.Id == default(int)) ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                this.context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return entity;
            }
        }
    }
}
