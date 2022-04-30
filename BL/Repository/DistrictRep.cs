
using AspGraduateProjAdminPan.BL.Interface;
using AspGraduateProjAdminPan.Models;
using AutoMapper;
using System.Linq;
using WebApplication7.DAL.Database;

namespace AspGraduateProjAdminPan.BL.Repository
{
    public class DistrictRep : IDistrictRep
    {

        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public DistrictRep(DbContainer dbContainer, IMapper mapper)
        {
            this.dbContainer = dbContainer;
            this.mapper = mapper;
        }




        public IQueryable<DistrictVM> Get()
        {



            return dbContainer.District.Select(a => new DistrictVM { Name = a.Name, Id = a.Id, CityId = a.CityId });
        }

        public DistrictVM GetById(int id)
        {


            var data = dbContainer.District.Where(a => a.Id == id).FirstOrDefault();
            return mapper.Map<DistrictVM>(data);

        }
    }
}

