using Company.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace MVC02.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager) 
        {
           
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string SearchInp )
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




        public async Task<IActionResult> Details(string id , string viewname ="Details" )
        {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();



            return View(viewname,user);
        }



    }
}
