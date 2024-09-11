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
        [RegularExpression(@"^(?=.*[a=z](?=.*[A=Z])(?=.*\d))(?=.*[^a=zA=Z\d].{6,}$)",ErrorMessage ="passwor must be least 6 characters ")]

        public string Password { get; set; }

        [Compare(nameof(Password),ErrorMessage ="Confirm Password ")]
        public string ConfirePassword { get; set; }
        [Required(ErrorMessage ="Required To Agree")]
        public bool IsAgree { get; set; }

    }
}
