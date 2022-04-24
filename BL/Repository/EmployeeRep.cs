using System.Linq;
using WebApplication7.BL.Interface;
using WebApplication7.Models;
using WebApplication7.DAL.Entities;
using AspGraduateProjAdminPan.BL.Mapping;
using WebApplication7.DAL.Database;
using AutoMapper;
using System;


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

            var emp = dbContainer.Employee.Find(id);

            dbContainer.Employee.Remove(emp);

            dbContainer.SaveChanges();
         }

        public void Edit(EmployeeVM dpt)
        {


            var data = mapper.Map<Employee>(dpt);


            dbContainer.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContainer.SaveChanges();


         }
       EmployeeVM  CustomVm(Employee v)
        {

           return mapper.Map<EmployeeVM>(v);
          //  x.DistrictId = v.District.Name;
            

        }
        public IQueryable<EmployeeVM> Get() {
            

            return dbContainer.Employee.Select(a =>new EmployeeVM() { Name=a.Name,Address=a.Address,DistrictId=a.District.Name,Email=a.Email,Salary=a.Salary,DepId=a.DepId,IsActive=a.IsActive,Id=a.Id,HireDate=a.HireDate});
         }

        public EmployeeVM GetById(int id)
        {


       var data=     dbContainer.Employee.Where(a=>a.Id==id).FirstOrDefault();
            return mapper.Map<EmployeeVM>(data);
         }
    }
}
