using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void add(TEntity entity);
        void delete(TEntity entity);
        IEnumerable<TEntity> getAll(bool track = false);
        IEnumerable<TEntity> getAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? getById(int id);
        void update(TEntity entity);
    }
}
