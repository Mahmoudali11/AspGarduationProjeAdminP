using AspGraduateProjAdminPan.BL.Interface;
using AspGraduateProjAdminPan.BL.Mapping;
using AspGraduateProjAdminPan.BL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;
using WebApplication7.BL.Interface;
using WebApplication7.BL.Repository;
using WebApplication7.DAL.Database;

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
            services.AddControllersWithViews().
                //for localization/globalization.
                AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                //for newtownsoft to help in Json formating.
                .AddDataAnnotationsLocalization().AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            //here apply singletone"or unit of work" using DI
            //create instance for each user... and this is most used
            //=>regester my services
            services.AddScoped<IDepartmentRep, DepartmentRep>();
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();

            services.AddScoped<ICityRep, CityRep>();

            services.AddScoped<IDistrictRep, DistrictRep>();


            //shared instance for all users
            //  services.AddSingleton<DepartmentRep>();
            /////////////////////////////
            //instanced for each request
            //services.AddTransient<DepartmentRep>();
            //////////////////////////////////
            ///
            void regm(AutoMapper.IMapperConfigurationExpression n)
            {
                n.AddProfile(new Mapper());
            }
            /// 
            /// register Mapper 
            services.AddAutoMapper(regm);
            //////register connection string..

            services.AddDbContextPool<DbContainer>(optio => optio.UseSqlServer(Configuration.GetConnectionString("SiteDb")));

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


            /////////////localization////////////////////////

            var supportedCultures = new[] {
                  new CultureInfo("ar-EG"),
                  new CultureInfo("en-US"),
            };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ar-EG"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,

                //override default language which is en-US
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            ///if there areas in our project
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
      


        }
    }
}
