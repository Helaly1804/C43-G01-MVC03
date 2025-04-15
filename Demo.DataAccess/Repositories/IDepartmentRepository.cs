
namespace Demo.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        int add(Department department);
        int delete(Department department);
        IEnumerable<Department> getAll(bool track = false);
        Department? getById(int id);
        int update(Department department);
    }
}