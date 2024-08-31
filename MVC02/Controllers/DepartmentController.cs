﻿using Company.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MVC02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var department = _departmentRepository.GetAll();
            return View(department);
        }
    }
}