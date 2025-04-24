using Demo.BusinessLogic.DataTransferObjects.Department;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto department);
        int DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentDetails(int id);
        int UpdateDepartment(UpdatedDepartmentDto department);
    }
}