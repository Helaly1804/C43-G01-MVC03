using Demo.BusinessLogic.DataTransferObjects.Employee;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService employeeService ,
        ILogger<EmployeeController> logger,
        IWebHostEnvironment environment) : Controller
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
        public IActionResult Create(EmployeeViewModel employee1)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreatedEmployeeDto employee = new CreatedEmployeeDto
                    {
                        Name = employee1.Name,
                        Email = employee1.Email,
                        Address = employee1.Address,
                        PhoneNumber = employee1.PhoneNumber,
                        Age = employee1.Age,
                        Salary = employee1.Salary,
                        IsActive = employee1.IsActive,
                        CreatedBy = employee1.CreatedBy,
                        LastModifiedBy = employee1.LastModifiedBy,
                        DepartmentId = employee1.DepartmentId,
                        Gender = employee1.Gender,
                        EmployeeType = employee1.EmployeeType
                    };
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
            return View(employee1);
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
                    return View(new EmployeeViewModel
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
                        LastModifiedBy = employee.LastModifiedBy,
                        DepartmentId = employee.DepartmentId,
                        Gender = employee.Gender,
                        EmployeeType = employee.EmployeeType
                    });
            }else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id, EmployeeViewModel employee)
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
                        LastModifiedBy = employee.LastModifiedBy,
                        DepartmentId = employee.DepartmentId,
                        Gender = employee.Gender,
                        EmployeeType = employee.EmployeeType
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
        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                try
                {
                    var employee = employeeService.DeleteEmployee(id.Value);
                    if (employee)
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Failed to delete employee");
                }
                catch(Exception ex)               
                {
                    if (environment.IsDevelopment())
                        ModelState.AddModelError("", ex.Message);
                    else
                        logger.LogError(ex.Message);
                }                
            }
            else
               ModelState.AddModelError("", "Invalid data");
            return RedirectToAction("Index");
        }
    }
}
