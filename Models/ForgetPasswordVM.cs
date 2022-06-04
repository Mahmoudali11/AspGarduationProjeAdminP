using System.ComponentModel.DataAnnotations;
namespace AspGraduateProjAdminPan.Models
{
    public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage ="Enter valid an email!")]
        [Required(ErrorMessage ="Email adrees is required")]
        public string Email { get; set; }
    }
}
