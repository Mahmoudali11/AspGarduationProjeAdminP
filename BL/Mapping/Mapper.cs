using AspGraduateProjAdminPan.DAL.Entities;
using AspGraduateProjAdminPan.Models;
using AutoMapper;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;
namespace AspGraduateProjAdminPan.BL.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //here i injected the modelevm and entities
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
            CreateMap<CityVM, City>();
            CreateMap<City, CityVM>();
            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();
            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();










        }
    }
}
