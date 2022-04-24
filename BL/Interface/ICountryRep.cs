using System.Collections.Generic;
using AspGraduateProjAdminPan.Models;
using System.Linq;

namespace AspGraduateProjAdminPan.BL.Interface
{
    public interface ICountryRep
    {
        IQueryable<CountryVM> Get();
        CountryVM GetById(int id);
      /*  void Add(CountryVM dpt);
        void Edit(CountryVM dpt);
        void Delete(int id);*/

    }
}
