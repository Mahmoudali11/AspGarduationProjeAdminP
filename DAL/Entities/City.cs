using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspGraduateProjAdminPan.DAL.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<District> District { get; set; }
        public int CountryId { get; set; }



        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
