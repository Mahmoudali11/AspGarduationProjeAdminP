using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;
using AutoMapper;

namespace WebApplication7.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //  private DbContainer db = new DbContainer();
        public DepartmentRep(DbContainer db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IQueryable<DepartmentVM> Get()
        {
            IQueryable<DepartmentVM> data = GetAllDepartment(); return data;
        }

        private IQueryable<DepartmentVM> GetAllDepartment()
        {
            return db.Department.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }

        public DepartmentVM GetById(int id)
        {
            DepartmentVM data = GetDepartment(id);
            return data;
        }

        private DepartmentVM GetDepartment(int id)
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
        }

        public void Add(DepartmentVM dpt)
        {
            //manual Mapping
            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;

            var d=mapper.Map<Department>(dpt);

            db.Department.Add(d);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        { ///Manula Mapping
            //var newData = db.Department.Find(dpt.Id);

            //newData.DepartmentName = dpt.DepartmentName;
            //newData.DepartmentCode = dpt.DepartmentCode;

            ///using auto mapper

         var   newData=mapper.Map<Department>(dpt);
            //modified using Id"Primary key" of Entiti 
            db.Entry(newData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var x = db.Department.Find(id);
            db.Department.Remove(x);
            db.SaveChanges();
        }
    }

   
}
