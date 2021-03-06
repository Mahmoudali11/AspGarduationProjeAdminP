using System.Linq;
using WebApplication7.Models;

namespace WebApplication7.BL.Interface
{
    public interface IDepartmentRep
    {
        /// <summary>
        /// you may use unity of work like generic repos.
        /// </summary>
        /// <returns></returns>
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetById(int id);
        void Add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);

    }
}
