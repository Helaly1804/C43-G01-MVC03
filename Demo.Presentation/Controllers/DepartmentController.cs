using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Services;
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
                        departmentService.AddDepartment(department);
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
    }
}
