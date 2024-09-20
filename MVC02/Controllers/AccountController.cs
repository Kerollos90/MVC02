using Company.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MVC02.Models;

namespace MVC02.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager ,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
					var user = await _userManager.FindByEmailAsync(login.Email);

				if (user is not null)
				{
					if (await _userManager.CheckPasswordAsync(user, login.Password))
					{

						var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);

						if (result.Succeeded)
							return RedirectToAction("Index" ,"Home");
					}

					
				}
						ModelState.AddModelError("", "Incorrect Email Or Pasword");
					return View(login);



            
            }

               return View(login);
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

		public new async Task<IActionResult> SignOut()
		{ 
			await _signInManager.SignOutAsync();

			return RedirectToAction("LogIn");
		
		
		}

	}
}
