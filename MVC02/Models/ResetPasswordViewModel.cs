using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$",
       ErrorMessage = "Password must be at least 6 characters long, with one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Confirm Password ")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
