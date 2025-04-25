using Demo.BusinessLogic.DataTransferObjects.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);
        public EmployeeDetailsDto? GetEmployeeDetails(int id);
        public int AddEmployee(CreatedEmployeeDto employee);
        public int UpdateEmployee(UpdatedEmployeeDto employee);
        public bool DeleteEmployee(int id);
    }
}
