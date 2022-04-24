 using Microsoft.EntityFrameworkCore;
using System;
using AspGraduateProjAdminPan.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace WebApplication7.DAL.Database
{
    public class DbContainer : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { set; get; }
        public DbSet<District> District { get; set; }
        //this override onConfiguring method..
        public DbContainer(DbContextOptions options):base(options)
        {

        }
         //this is not best practice as client my change server so cant
        //do it unless call developer so web use appsetting that can be changet after publishing
        //project file to server.
        //to  achieve that we  use DBContext constructor and pass option arg "Connection string"
        //to that we  use DBContext constructo and pass option arg "Connection string"
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database = SharpDb ; integrated security = true");
        //}

    }
}
