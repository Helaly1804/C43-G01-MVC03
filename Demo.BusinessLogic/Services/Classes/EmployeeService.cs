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
    public class EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper) : IEmployeeService
    {
        public int AddEmployee(CreatedEmployeeDto employee)
        {
            return employeeRepository.add(mapper.Map<CreatedEmployeeDto, Employee>(employee));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = employeeRepository.getById(id);
            if (employee is null)
                return false;
            else
            { 
                employee.IsDeleted = true;
                return employeeRepository.update(employee) > 0 ? true : false;
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = employeeRepository.getAll(withTracking);
            return mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDetailsDto? GetEmployeeDetails(int id)
        {
            var employee = employeeRepository.getById(id);
            if (employee is null)
                return null;
            else
                return mapper.Map<Employee, EmployeeDetailsDto>(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            return employeeRepository.update(mapper.Map<UpdatedEmployeeDto, Employee>(employee));
        }
    }
}
