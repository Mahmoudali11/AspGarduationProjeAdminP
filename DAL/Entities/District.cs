using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication7.DAL.Entities;
namespace AspGraduateProjAdminPan.DAL.Entities

{
    [Table("District")]
    public class District
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
