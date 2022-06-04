using System.ComponentModel.DataAnnotations;
namespace AspGraduateProjAdminPan.Models
{
    public class RegisterationVM
    {
        [Required(ErrorMessage ="Email required")]
        [EmailAddress(ErrorMessage ="Ener Valid Email!")]
        public string   Email { get; set; }
        [Required(ErrorMessage ="Password required!")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage ="minimum password length is 3 ! ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "minimum password length is 3 ! ")]
        [Compare("Password",ErrorMessage ="Passwords are mismatch!")]
        //Display  data annotation used for ui to display props as you want in UI
        [Display(Name ="Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
