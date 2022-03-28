using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
 
namespace WebApplication7.DAL.Entities
{
    [Table("Emp")]
    public class Employee
    {


        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Address { get; set; }
        public int DepId { get; set; }
       
        
        [ForeignKey("DepId")]
        public Department Department  { get; set; }
        
        public double Salary { get; set; }
        public  DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
