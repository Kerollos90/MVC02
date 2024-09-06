﻿using Company.Data.Entity;
using Company.Service.Interface.EmployeeInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace MVC02.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var emp = _employeeService.GetAll();
            return View(emp);
        }

        public IActionResult Create()
        {



            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
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


        public IActionResult Details(int? id,string viewtable="Details") 
        {
            var emp =_employeeService.GetById(id);
            return View(viewtable,emp);
        
        
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
             

            return Details(id,"Update");

        
        
        }


        [HttpPost]
        public IActionResult Update(int? id, Employee employee)
        {
            
            if (employee.Id !=id.Value)
                return RedirectToAction("NotFound","Home");

            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));
            


        }

        public IActionResult Delete(Employee employee, int? id)
        {
            if (employee.Id != id.Value)
                return RedirectToAction("NotFound", "Home");

            _employeeService.Delete(employee);  
            return RedirectToAction(nameof(Index));




        }

    }
}