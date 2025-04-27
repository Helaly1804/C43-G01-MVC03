using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public int add(TEntity department)
        {
            dbContext.Set<TEntity>().Add(department);
            return dbContext.SaveChanges();
        }
        public int update(TEntity department)
        {
            dbContext.Set<TEntity>().Update(department);
            return dbContext.SaveChanges();
        }
        public int delete(TEntity department)
        {
            dbContext.Set<TEntity>().Remove(department);
            return dbContext.SaveChanges();
        }
    }
}
