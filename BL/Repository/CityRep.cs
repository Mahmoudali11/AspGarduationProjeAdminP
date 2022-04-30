
using AspGraduateProjAdminPan.BL.Interface;
using AspGraduateProjAdminPan.Models;
using AutoMapper;
using System.Linq;
using WebApplication7.DAL.Database;

namespace AspGraduateProjAdminPan.BL.Repository
{
    public class CityRep : ICityRep
    {

        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public CityRep(DbContainer dbContainer, IMapper mapper)
        {
            this.dbContainer = dbContainer;
            this.mapper = mapper;
        }




        public IQueryable<CityVM> Get()
        {



            return dbContainer.City.Select(a => new CityVM { Id = a.Id, Name = a.Name, CountryId = a.CountryId });
        }

        public CityVM GetById(int id)
        {


            var data = dbContainer.City.Where(a => a.Id == id).FirstOrDefault();
            return mapper.Map<CityVM>(data);

        }
    }
}

