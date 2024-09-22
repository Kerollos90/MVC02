using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Is Required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]

        public string Email { get; set; }
        [Required(ErrorMessage ="password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long, with one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }

        [Compare(nameof(Password),ErrorMessage ="Confirm Password ")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Required To Agree")]
        public bool IsAgree { get; set; }

    }
}
