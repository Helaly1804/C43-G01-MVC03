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
    public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
    {
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = unitOfWork.DepartmentRepository.getAll();
            return departments.Select(d => d.ToDepartmentDto());
        }
        public DepartmentDetailsDto? GetDepartmentDetails(int id)
        {
            var department = unitOfWork.DepartmentRepository.getById(id);
            return department is null ? null : department.ToDepartmentDetailsDto();
        }
        public int AddDepartment(CreatedDepartmentDto department)
        {
            unitOfWork.DepartmentRepository.add(department.ToEntity());
            return unitOfWork.SaveChanges();
        }
        public int UpdateDepartment(UpdatedDepartmentDto department)
        {
            unitOfWork.DepartmentRepository.update(department.ToEntity());
            return unitOfWork.SaveChanges();
        }
        public int DeleteDepartment(int id)
        {
            var department = unitOfWork.DepartmentRepository.getById(id);
            if (department is null)
                throw new ArgumentNullException(nameof(department));
            unitOfWork.DepartmentRepository.delete(department);
            return unitOfWork.SaveChanges();
        }
    }
}
