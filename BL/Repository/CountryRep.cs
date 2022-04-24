﻿using AspGraduateProjAdminPan.Models;
using AspGraduateProjAdminPan.BL.Interface;
using System.Linq;
using WebApplication7.DAL.Database;
using AutoMapper;

namespace AspGraduateProjAdminPan.BL.Repository
{
    public class CountryRep : ICountryRep
    {

        private readonly DbContainer dbContainer;
        private readonly IMapper mapper;

        public CountryRep(DbContainer dbContainer, IMapper mapper)
        {
            this.dbContainer = dbContainer;
            this.mapper = mapper;
        }

 


        public IQueryable<CountryVM> Get()
        {



            return dbContainer.Country.Select(a => mapper.Map<CountryVM>(a));
        }

        public CountryVM GetById(int id)
        {


            var data = dbContainer.Employee.Where(a => a.Id == id).FirstOrDefault();
            return mapper.Map<CountryVM>(data);

        }
    } }