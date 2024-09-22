using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format Email")]

        public string Email { get; set; }
    }
}
