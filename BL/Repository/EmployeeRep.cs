using System.Linq;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using WebApplication7.DAL.Entities;
using AspGraduateProjAdminPan.BL.Mapping;
using WebApplication7.DAL.Database;
using AutoMapper;
namespace WebApplication7.BL.Repository

{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer dbContainer,IMapper mapper)
        {
            this.dbContainer = dbContainer;
            this.mapper = mapper;
        }
      

        public void Add(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);


            dbContainer.Add(data);
            dbContainer.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(EmployeeVM dpt)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<EmployeeVM> Get() {



            return dbContainer.Employee.Select(a=>mapper.Map<EmployeeVM>(a));
         }

        public EmployeeVM GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
