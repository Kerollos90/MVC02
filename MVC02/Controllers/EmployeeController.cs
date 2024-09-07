using Company.Data.Entity;
using Company.Service.Interface.DepartmenInterface;
using Company.Service.Interface.EmployeeInterface;
using Company.Service.Interface.EmployeeInterface.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace MVC02.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService ,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string SearchInp)
        {
            //ViewBag.message = "Hello from employee index (viewbag)";
            //ViewData["test message"]= "Hello from employee index(viewdata)";
            //TempData["test temp message"] = "Hello from employee index (temp)";



            IEnumerable<EmployeeDto> emp = new List<EmployeeDto>();
            if (string.IsNullOrWhiteSpace(SearchInp))
                emp = _employeeService.GetAll();
            else
                emp = _employeeService.GetEmployeeByName(SearchInp);


            return View(emp);
        }

        public IActionResult Create()
        {


                ViewBag.Department = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));


                }

                ModelState.AddModelError("Employee Error", "Validation Error");
                return View(employee);





            }
            catch (Exception ex)
            {
                ModelState.TryAddModelError("Employee Error ", ex.Message);
                return View(employee);

            }
        }


        public IActionResult Details(int? id, string viewtable = "Details")
        {
            var emp = _employeeService.GetById(id);
            return View(viewtable, emp);


        }

        [HttpGet]
        public IActionResult Update(int id)
        {


            return Details(id, "Update");



        }


        [HttpPost]
        public IActionResult Update(int? id, EmployeeDto employee)
        {

            if (employee.Id != id.Value)
                return RedirectToAction("NotFound", "Home");

            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));



        }

        public IActionResult Delete(EmployeeDto employee, int? id)
        {
            if (employee.Id != id.Value)
                return RedirectToAction("NotFound", "Home");

           
            _employeeService.Delete(employee);
            
            return RedirectToAction(nameof(Index));




        }

    }
}
