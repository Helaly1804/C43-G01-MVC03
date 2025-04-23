using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
using Demo.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService departmentService ,
        ILogger<DepartmentController> _logger
        ,IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var departments = departmentService.GetAllDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = departmentService.AddDepartment(department);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        ModelState.AddModelError("", "The Department can't be created");
                }
                catch(Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError("", ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            else
                ModelState.AddModelError("", "The model is not valid");

            return View(department);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var department = departmentService.GetDepartmentDetails(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            else
            {
                var department = departmentService.GetDepartmentDetails(id.Value);
                if (department == null)
                    return NotFound();
                else
                    return View(new DepartmentEditViewModel
                    {
                        Id = department.Id,
                        Name = department.Name,
                        Code = department.Code,
                        Description = department.Description,
                        CreatedOn = department.CreatedOn
                    });               
            }
        }
        [HttpPost]
        public IActionResult Edit([FromRoute]int id,DepartmentEditViewModel department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedDepartment = new UpdatedDepartmentDto
                    {
                        Id = id,
                        Name = department.Name,
                        Code = department.Code,
                        Description = department.Description
                    };
                    int result = departmentService.UpdateDepartment(updatedDepartment);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        ModelState.AddModelError("", "The Department can't be updated");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError("", ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            else
                ModelState.AddModelError("", "The model is not valid");
            return View(department);
        }
    }
}
