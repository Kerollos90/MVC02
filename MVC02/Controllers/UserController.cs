using Company.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Models;
using System.Drawing.Text;

namespace MVC02.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ApplicationUser> _logger;

        public UserController(UserManager<ApplicationUser> userManager, ILogger<ApplicationUser> logger)
        {

            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string SearchInp)
        {
            List<ApplicationUser> users;

            if (string.IsNullOrEmpty(SearchInp))
                users = await _userManager.Users.ToListAsync();

            else
                users = await _userManager.Users
                              .Where(x => x.NormalizedEmail.Trim().Contains(SearchInp.Trim().ToUpper()))
                              .ToListAsync();




            return View(users);
        }




        public async Task<IActionResult> Details(string id, string viewname = "Details")
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            if (viewname == "Update")
            {
                var viewmodel = new UpdatedUserModelView
                {
                    Id = user.Id,
                    UserName = user.UserName



                };
                return View(viewname, viewmodel);
            }

            return View(viewname, user);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");

        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdatedUserModelView applicationUser)
        {

            if (id != applicationUser.Id)
                return RedirectToAction("NotFound", "Home");

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _userManager.FindByIdAsync(id);

                    if (userId == null)
                        return RedirectToAction("NotFound", "Home");



                    userId.UserName = applicationUser.UserName;
                    userId.NormalizedUserName = applicationUser.UserName.ToUpper();

                    var result = await _userManager.UpdateAsync(userId);

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










            return View();

        }


    }
}
