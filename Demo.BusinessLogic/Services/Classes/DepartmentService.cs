using Demo.BusinessLogic.DataTransferObjects.Department;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = departmentRepository.getAll();
            return departments.Select(d => d.ToDepartmentDto());
        }
        public DepartmentDetailsDto? GetDepartmentDetails(int id)
        {
            var department = departmentRepository.getById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }
        public int AddDepartment(CreatedDepartmentDto department)
        {
            return departmentRepository.add(department.ToEntity());
        }
        public int UpdateDepartment(UpdatedDepartmentDto department)
        {
            return departmentRepository.update(department.ToEntity());
        }
        public int DeleteDepartment(int id)
        {
            var department = departmentRepository.getById(id);
            if (department is null)
                throw new ArgumentNullException(nameof(department));
            return departmentRepository.delete(department);
        }
    }
}
