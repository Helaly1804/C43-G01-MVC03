using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        int add(TEntity entity);
        int delete(TEntity entity);
        IEnumerable<TEntity> getAll(bool track = false);
        TEntity? getById(int id);
        int update(TEntity entity);
    }
}
