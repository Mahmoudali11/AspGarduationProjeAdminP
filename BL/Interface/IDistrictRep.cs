using System.Collections.Generic;
using AspGraduateProjAdminPan.Models;
using System.Linq;

namespace AspGraduateProjAdminPan.BL.Interface
{
    public interface IDistrictRep
    {
        IQueryable<DistrictVM> Get();
      DistrictVM GetById(int id);
        /*  void Add(CityVMVM dpt);
          void Edit(CityVMVM dpt);
          void Delete(int id);*/

    }
}
