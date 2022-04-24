using System.ComponentModel.DataAnnotations;
using System;
namespace WebApplication7.Models
{
    public class EmployeeVM
    {


        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        public int DepId { get; set; }

        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage ="email address is reqiured")]
        public string Email { get; set; }
        public string DistrictId { get; set; }


    }
}
