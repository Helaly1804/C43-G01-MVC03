using Demo.DataAccess.Models.EmployeeModel;
using Demo.DataAccess.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public string Gender { get; set; } = string.Empty;
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; } = string.Empty;
        public int Age { get; set; }
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }
    }
}
