using System.Linq;
using WebApplication7.Models;
namespace WebApplication7.BL.Interface

{
    public interface IEmployeeRep
    {

        IQueryable<EmployeeVM> Get();
        EmployeeVM GetById(int id);
        void Add(EmployeeVM dpt);
        void Edit(EmployeeVM dpt);
        void Delete(int id);

    }
}
