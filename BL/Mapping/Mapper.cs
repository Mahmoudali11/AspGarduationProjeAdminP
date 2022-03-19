using AutoMapper;
using WebApplication7.Models;
using WebApplication7.DAL.Entities;
namespace AspGraduateProjAdminPan.BL.Mapping
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            //here i injected the modelevm and entities
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

        }
    }
}
