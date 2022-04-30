using System.ComponentModel.DataAnnotations;


namespace WebApplication7.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name is req")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "code is req")]
        [MaxLength(3, ErrorMessage = "max lenth is 3 characters")]
        public string DepartmentCode { get; set; }

    }
}
