using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        int Create(T entity);
        T Read(int id);
        IList<T> Read(Expression<Func<T, bool>> predicate);
        int Update(T entity);
        int Delete(T entity);
        int Delete(int id);
    }
}
