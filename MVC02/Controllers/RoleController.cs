using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC02.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleController;
        private readonly ILogger<RoleController> _logger;

        public RoleController(RoleManager<IdentityRole> roleController ,ILogger<RoleController> logger) 
        {
            _roleController = roleController;
            _logger = logger;
        }
        public async  Task<IActionResult> Index()
        {
            var role = await _roleController.Roles.ToListAsync();
            return View(role);
        }


        public IActionResult Create()
        { 
            return View();
        
        
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleController.CreateAsync(role);

                if(result.Succeeded)
                    return RedirectToAction("Index");

                foreach (var item in result.Errors)
                    _logger
                        .LogError(item.Description);
            }
                    return View(role);
        }
    }
}

