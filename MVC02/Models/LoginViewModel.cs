using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}
