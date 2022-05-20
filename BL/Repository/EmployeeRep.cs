using AspGraduateProjAdminPan.BL.Helper;
using AutoMapper;
using System.IO;
using System.Linq;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;


namespace WebApplication7.BL.Repository

{

    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer dbContainer, IMapper mapper)
        {
            this.dbContainer = dbContainer;
            this.mapper = mapper;
        }


        public void Add(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);

            var cvName = UploadFileHelper.SaveFile(emp.CvDetails, "Docs");
            var photoName = UploadFileHelper.SaveFile(emp.PhotoDetails, "Photos");
            //override data cvname and data photoname
            data.CvName = cvName;
            data.PhotoName = photoName;
            dbContainer.Add(data);
            dbContainer.SaveChanges();
        }

        public void Delete(int id)
        {

            var emp = dbContainer.Employee.Find(id);
            UploadFileHelper.RemoveFile(emp.PhotoName, "Photos");
            UploadFileHelper.RemoveFile(emp.CvName, "Docs");

            dbContainer.Employee.Remove(emp);

            dbContainer.SaveChanges();
        }

        public void Edit(EmployeeVM dpt)
        {


            var data = mapper.Map<Employee>(dpt);


            dbContainer.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContainer.SaveChanges();


        }
        EmployeeVM CustomVm(Employee v)
        {

            return mapper.Map<EmployeeVM>(v);
            //  x.DistrictId = v.District.Name;


        }
        public IQueryable<EmployeeVM> Get()
        {


            return dbContainer.Employee.Select(a => new EmployeeVM() { Name = a.Name, Address = a.Address, DistrictId = a.District.Id, Email = a.Email, Salary = a.Salary, DepId = a.DepId, IsActive = a.IsActive, Id = a.Id, HireDate = a.HireDate, DistrictName = a.District.Name, PhotoName = a.PhotoName, CvName = a.CvName, });
        }

        public EmployeeVM GetById(int id)
        {


            var data = dbContainer.Employee.Where(a => a.Id == id).Select(a => new EmployeeVM() { Name = a.Name, Address = a.Address, DistrictId = a.District.Id, Email = a.Email, Salary = a.Salary, DepId = a.DepId, IsActive = a.IsActive, Id = a.Id, HireDate = a.HireDate, DistrictName = a.District.Name, PhotoName = a.PhotoName, CvName = a.CvName }).FirstOrDefault();
            return mapper.Map<EmployeeVM>(data);
        }
    }
}
