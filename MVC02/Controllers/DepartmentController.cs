using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.DepartmenInterface;
using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var department = _departmentService.GetAll();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        
        
        
        }





        [HttpPost]
        public IActionResult Create(Department department) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));

                }

                ModelState.AddModelError("Department Error", "Validation Error");
                return View(department);


            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("Department Error", ex.Message);
                return View(department);
               
            
            }
        
        }

    }
}
