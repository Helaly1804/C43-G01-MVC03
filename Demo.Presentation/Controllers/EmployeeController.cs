using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService) : Controller
    {
        public IActionResult Index()
        {
            var employees = employeeService.GetAllEmployees();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = employeeService.AddEmployee(employee);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Failed to create employee");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
                ModelState.AddModelError("", "Invalid data");
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details([FromRoute]int? id)
        {
            if (id.HasValue) 
            {
            var employee = employeeService.GetEmployeeDetails(id.Value);
            if (employee == null) return NotFound();
            else return View(employee);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var employee = employeeService.GetEmployeeDetails(id.Value);
                if (employee == null) return NotFound();
                else
                    return View(new EmployeeEditViewModel
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Address = employee.Address,
                        PhoneNumber = employee.PhoneNumber,
                        Age = employee.Age,
                        Salary = employee.Salary,
                        IsActive = employee.IsActive,
                        CreatedBy = employee.CreatedBy,
                        LastModifiedBy = employee.LastModifiedBy
                    });
            }else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id, EmployeeEditViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = employeeService.UpdateEmployee(new UpdatedEmployeeDto
                    {
                        Id = id,
                        Name = employee.Name,
                        Email = employee.Email,
                        Address = employee.Address,
                        PhoneNumber = employee.PhoneNumber,
                        Age = employee.Age,
                        Salary = employee.Salary,
                        IsActive = employee.IsActive,
                        CreatedBy = employee.CreatedBy,
                        LastModifiedBy = employee.LastModifiedBy
                    });
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Failed to update employee");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
                ModelState.AddModelError("", "Invalid data");
            return View(employee);
        }

    }
}
