using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;

namespace WebApplication7.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;

        //  private DbContainer db = new DbContainer();
        public DepartmentRep(DbContainer db)
        {
            this.db = db;
        }
        public IQueryable<DepartmentVM> Get()
        {
            var data = db.Department.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
            return data;
        }

        public DepartmentVM GetById(int id)
        {
            var data = db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
            return data;
        }

        public void Add(DepartmentVM dpt)
        {
            // Mapping
            Department d = new Department();
            d.DepartmentName = dpt.DepartmentName;
            d.DepartmentCode = dpt.DepartmentCode;

            db.Department.Add(d);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {
            var OldData = db.Department.Find(dpt.Id);

            OldData.DepartmentName = dpt.DepartmentName;
            OldData.DepartmentCode = dpt.DepartmentCode;

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
