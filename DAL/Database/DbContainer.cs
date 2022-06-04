using AspGraduateProjAdminPan.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication7.DAL.Entities;

namespace WebApplication7.DAL.Database
{
    public class DbContainer : IdentityDbContext
    {
        /// <summary>
        /// here i ll replace DBContect with IdentiyDbcontext to create uerr table("Identification")
        /// and create tables of security in database like users table...
        /// </summary>
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { set; get; }
        public DbSet<District> District { get; set; }
        //this override onConfiguring method..
        public DbContainer(DbContextOptions options) : base(options)
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
