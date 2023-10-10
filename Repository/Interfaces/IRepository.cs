using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        int Create(T entity);
        T Read(int id);
        IList<T> Read(Expression<Func<T, bool>> predicate);
        int Update(T entity);
        int Delete(T entity);
    }
}
