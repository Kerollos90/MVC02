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
    }
}
