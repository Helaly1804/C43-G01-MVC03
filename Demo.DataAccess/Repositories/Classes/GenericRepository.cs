using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity? getById(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> getAll(bool track = false)
        {
            if (track)
                return dbContext.Set<TEntity>().Where(x => x.IsDeleted == false).ToList();
            else
                return dbContext.Set<TEntity>().Where(x => x.IsDeleted == false).AsNoTracking().ToList();

        }
        public void add(TEntity department)
        {
            dbContext.Set<TEntity>().Add(department);
        }
        public void update(TEntity department)
        {
            dbContext.Set<TEntity>().Update(department);
        }
        public void delete(TEntity department)
        {
            dbContext.Set<TEntity>().Remove(department);
        }

        public IEnumerable<TEntity> getAll(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
