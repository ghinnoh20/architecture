using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Implementations
{
    public class SchoolRepository<T> : ISchoolRepository<T> where T : class
    {
        private readonly SchoolContext _context;
        private DbSet<T> _entity;

        public SchoolRepository(SchoolContext testContext)
        {
            _context = testContext;
            _entity = _context.Set<T>();
        }

        public int Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Add(entity);

            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Remove(entity);

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = (T)Activator.CreateInstance(typeof(T));
            entity.GetType().GetProperty("Id").SetValue(entity, id);

            _context.Attach(entity);

            _context.Entry(entity).Property("IsActive").CurrentValue = false;

            return _context.SaveChanges();
        }

        public T Read(int id)
        {
            return _entity.Find(id);
        }

        public IList<T> Read(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate).ToList();
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return _context.SaveChanges();
        }
    }
}
