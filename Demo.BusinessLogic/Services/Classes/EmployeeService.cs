using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork unitOfWork,IMapper mapper) : IEmployeeService
    {
        public int AddEmployee(CreatedEmployeeDto employee)
        {
            unitOfWork.EmployeeRepository.add(mapper.Map<CreatedEmployeeDto, Employee>(employee));
            return unitOfWork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = unitOfWork.EmployeeRepository.getById(id);
            if (employee is null)
                return false;
            else
            { 
                employee.IsDeleted = true;
                unitOfWork.EmployeeRepository.update(employee);
                return unitOfWork.SaveChanges() > 0;
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = unitOfWork.EmployeeRepository.getAll(withTracking);
            return mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(employees);
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(string? employeeSearchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(employeeSearchName))
                return GetAllEmployees();
            else
            {
                employees = unitOfWork.EmployeeRepository.getAll(x => x.Name.ToLower().Contains(employeeSearchName.ToLower()) && x.IsDeleted == false);
                return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            }
        }

        public EmployeeDetailsDto? GetEmployeeDetails(int id)
        {
            var employee = unitOfWork.EmployeeRepository.getById(id);
            if (employee is null)
                return null;
            else
                return mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            unitOfWork.EmployeeRepository.update(mapper.Map<UpdatedEmployeeDto, Employee>(employee));
            return unitOfWork.SaveChanges();
        }
    }
}
