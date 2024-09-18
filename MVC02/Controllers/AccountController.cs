using Company.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(SignUpViewModel signUp)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = signUp.Email.Split("@")[0],
                    Email = signUp.Email,
                    FirstName = signUp.FirstName,
                    LastName = signUp.LastName,
                    IsActive = true


                };

                var result = await _userManager.CreateAsync(user, signUp.Password);

                    if(result.Succeeded)
                    return RedirectToAction("SignIn");


                foreach (var e in result.Errors)
                    ModelState.AddModelError("",e.Description);
            
            }

            return View(signUp);
        }



		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel signUp)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = signUp.Email.Split("@")[0],
					Email = signUp.Email,
					FirstName = signUp.FirstName,
					LastName = signUp.LastName,
					IsActive = true


				};

				var result = await _userManager.CreateAsync(user, signUp.Password);

				if (result.Succeeded)
					return RedirectToAction("LogIn");


				foreach (var e in result.Errors)
					ModelState.AddModelError("", e.Description);

			}

			return View(signUp);
		}
	}
}
