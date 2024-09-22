using Company.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using System.Data;

namespace MVC02.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleController;

        private readonly ILogger<RoleController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleController ,ILogger<RoleController> logger , UserManager<ApplicationUser> userManager ) 
        {
            _roleController = roleController;
            _logger = logger;
            _userManager = userManager;
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
        public async Task<IActionResult> Create(RoleViewModel rolemodel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                   
                    Name = rolemodel.Name
                   



                };
                var result = await _roleController.CreateAsync(role);


                if(result.Succeeded)
                    return RedirectToAction("Index");

                foreach (var item in result.Errors)
                    _logger
                        .LogError(item.Description);
            }
                    return View(rolemodel);
        }

        public async Task<IActionResult> Details(string id, string viewname = "Details")
        {

            var Role = await _roleController.FindByIdAsync(id);

            if (Role == null)
                return NotFound();
            var roleModel = new RoleViewModel
            {
                Id= Role.Id,
                Name = Role.Name




            };


            return View(viewname, roleModel);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");

        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, RoleViewModel RoleModel)
        {

            if (id != RoleModel.Id)
                return RedirectToAction("NotFound", "Home");

            if (ModelState.IsValid)
            {
                try
                {
                    var Role = await _roleController.FindByIdAsync(id);

                    if (Role == null)
                        return RedirectToAction("NotFound", "Home");



                    Role.Name = RoleModel.Name;
                    Role.NormalizedName = RoleModel.Name.ToUpper();

                    

                    var result = await _roleController.UpdateAsync(Role);

                    if (result.Succeeded)
                        return RedirectToAction("Index");

                    foreach (var item in result.Errors)
                        _logger.LogError(item.Description);




                    _logger.LogInformation("Updated Succeeded");

                    return View(nameof(Index));






                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return View(nameof(Index));

                }
            }










            return View(nameof(Index));

        }





        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View();

            var Role = await _roleController.FindByIdAsync(id);
            if (Role == null)
                return View();

            var result = await _roleController.DeleteAsync(Role);
            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var item in result.Errors)
                _logger.LogError(item.Description);





            return RedirectToAction("Index");



        }






        public async Task<IActionResult> AddOrRemoveUsers(string RoleId)
        {
            var role = await _roleController.FindByIdAsync(RoleId);
            if(role is null)
                return RedirectToAction(nameof(NotFound),"Home");

            var users = await _userManager.Users.ToListAsync();

            var UserInRoles = new List<UsersInRolesViewModel>();

            foreach (var user in users)
            {
                var userInRole = new UsersInRolesViewModel
                {
                    Id = user.Id,
                    Name = user.UserName


                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                    userInRole.IsSelected = true;
                else
                    userInRole.IsSelected = false;

                UserInRoles.Add(userInRole);


            }
            





            return View(UserInRoles);
        
        }




    }
}

