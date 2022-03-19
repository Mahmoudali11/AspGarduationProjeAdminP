using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication7.BL.Interface;
using WebApplication7.BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Database;
using Microsoft.EntityFrameworkCore;
using AspGraduateProjAdminPan.BL.Mapping;

namespace WebApplication7
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //this refers to appsettings json file 
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            /////////=>register controllers and views.
            services.AddControllersWithViews();
            //here apply singletone"or unit of work" using DI
            //create instance for each user... and this is most used
            //=>regester my services
            services.AddScoped<IDepartmentRep,DepartmentRep>();
            //shared instance for all users
            //  services.AddSingleton<DepartmentRep>();
            /////////////////////////////
            //instanced for each request
            //services.AddTransient<DepartmentRep>();
            //////////////////////////////////
            ///
            /// 
            /// 
            /// register Mapper 
               services.AddAutoMapper(x=>x.AddProfile(new Mapper()));
            //////register connection string..
            
            services.AddDbContextPool<DbContainer>(optio=>optio.UseSqlServer(Configuration.GetConnectionString("SiteDb")));
            
            //////
           ////

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
