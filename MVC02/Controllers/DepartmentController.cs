using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.DepartmenInterface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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


        public IActionResult Details(int? id ,string viewname="Details")
        { 
            var dept = _departmentService.GetById(id);


            if(dept is null)
                return RedirectToAction("NotFound","Home");
           
            return View(viewname,dept);


        
        
        
        }


        public IActionResult Update(int? Id)
        {
            return Details(Id,"Update");


        
        
        }


        [HttpPost]
        public IActionResult Update(int? id,Department department)
        {
            if(department.Id != id.Value )
                return RedirectToAction("NotFound", "Home");


            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));

            
        
        
        
        }  
        
        public IActionResult Delete(int? id)
        {
            var dept = _departmentService.GetById(id);


            if (dept is null)
                return RedirectToAction("NotFound", "Home");


            _departmentService.Delete(dept);
            return RedirectToAction(nameof(Index));

            
        
        
        
        }

    }
}
