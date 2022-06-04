using System.ComponentModel.DataAnnotations;
namespace AspGraduateProjAdminPan.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Ener Valid Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "minimum password length is 3 ! ")]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
