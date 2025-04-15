using Demo.DataAccess.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        public Department? getById(int id)
        {
            return dbContext.Departments.Find(id);
        }
        public IEnumerable<Department> getAll(bool track = false)
        {
            if (track)
                return dbContext.Departments.ToList();
            else
                return dbContext.Departments.AsNoTracking().ToList();

        }
        public int add(Department department)
        {
            dbContext.Departments.Add(department);
            return dbContext.SaveChanges();
        }
        public int update(Department department)
        {
            dbContext.Departments.Update(department);
            return dbContext.SaveChanges();
        }
        public int delete(Department department)
        {
            dbContext.Departments.Remove(department);
            return dbContext.SaveChanges();
        }
    }
}
