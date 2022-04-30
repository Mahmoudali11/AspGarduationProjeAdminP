using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspGraduateProjAdminPan.DAL.Entities
{
    [Table(name: "Country")]
    public class Country
    {



        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> City { get; set; }
    }


}

