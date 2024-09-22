﻿using Company.Data.Entity;
using Company.Repository.Interfaces;
using Company.Service.Interface.DepartmenInterface;
using Company.Service.Interface.DepartmenInterface.Dto;
using Company.Service.Interface.EmployeeInterface.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace MVC02.Controllers
{
    [Authorize]
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
            TempData.Keep("test temp message");
            return View(department);
        }

        [HttpGet]
        public IActionResult Create() 
        {

            return View();
        
        
        
        }





        [HttpPost]
        public IActionResult Create(DepartmentDto department) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);

                    TempData["test temp message"] = "Hello from employee index";
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
        public IActionResult Update(int? id,DepartmentDto department)
        {
            if(department.Id != id.Value )
                return RedirectToAction("NotFound", "Home");


            _departmentService.Update(department);
            return RedirectToAction(nameof(Index));

            
        
        
        
        }  
        
        public IActionResult Delete(int id,DepartmentDto department)
        {
           


            if (department.Id !=id)
                return RedirectToAction("NotFound", "Home");



            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));

            
        
        
        
        }

    }
}
