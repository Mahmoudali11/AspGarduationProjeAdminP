using System.ComponentModel.DataAnnotations;

namespace AspGraduateProjAdminPan.Models
{
    public class RolesVM
    {
        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set; }
        public string Id { get; set; }
    }
}
